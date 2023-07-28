/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 28/07/2023
 */

/* OBSERVAÇÃO: [ESTE COMENTÁRIO DEVE APARECER NO CABEÇALHO DAS CLASSES Authentication e CheckingAccount]
 *             As classes Authentication e CheckingAccount armazenam dados relacionados à Contas Correntes de clientes do Bytebank.
 *
 *             No entando a classe Authentication se limita a saber apenas os dados necessários para a autenticação do cliente.
 *             Enquanto a classe CheckingAccount conhece apenas os dados úteis para a criação e a consequente movimentação dos recursos de uma Conta Corrente.
 *             
 *             A classe Authentication sabe apenas a ID do cliente (Nº da Conta Corrente);
 *             Sua chave de confirmação (Nº da Agência) que determina que aquela ID é única, pois só pode existir uma Conta Corrente com o mesmo número em cada agência;
 *             E a senha, que é o fator de verificação de que a tentiva de autenticação está sendo realizada pelo titular da conta, já que é uma informação pessoal e que
 *             apenas ele - o titular - deve ter conhecimento.
 *
 *             Já a classe CheckingAccount sabe as mesmas informações que a classe Authentication, exceto a senha do cliente. Pois o seu princípio é definir e manipular os
 *             dados da Conta Corrente dos clientes quando os mesmos já estão autenticados no sistema.
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.Authenticated;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.AccountManagement;

namespace Bytebank.AuthenticationComponents
{
    /// <summary>
    /// Define o que é e como deve ser feita uma autenticação no sistema do Bytebank.
    /// </summary>
    internal class Authentication
    {
        /// <summary>
        /// Construtor da classe Authentication que recebe os dados da Conta Corrente e passa para as propriedades manipularem na tela de autenticação (AuthenticationScreen).
        /// </summary>
        /// <param name="clientAccountId">Recebe o número da Conta Corrente do cliente.</param>
        /// <param name="clientBankBranch">Recebe o número da Agência bancária do cliente.</param>
        /// <param name="clientPinCode">Recebe o código PIN (senha) do cliente.</param>
        public Authentication(string clientAccountId, int clientBankBranch, int clientPinCode)
        {
            AuthClientAccountId = clientAccountId;
            AuthClientBankBranch = clientBankBranch;
            AuthClientPinCode = clientPinCode;
        }

        public string AuthClientAccountId { get; }
        public int AuthClientBankBranch { get; }
        public int AuthClientPinCode { get; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) //Verifica se o objeto é NULO ou diferente do tipo Authentication
            {
                return false;
            }
            Authentication otherObj = (Authentication)obj; //É feita a conversão do objeto otherObj para Authentication, já que a verificação anterior garante que obj é do mesmo tipo.

            return AuthClientAccountId == otherObj.AuthClientAccountId &&
                   AuthClientBankBranch == otherObj.AuthClientBankBranch &&
                   AuthClientPinCode == otherObj.AuthClientPinCode;
        }
        public override int GetHashCode()
        {
            unchecked // Desabilita o overflow da operação
            {
                int hash = 17; // Número primo inicial

                // Combina o hash das propriedades com o hash atual
                hash = hash * 23 + AuthClientAccountId.GetHashCode();
                hash = hash * 23 + AuthClientBankBranch.GetHashCode();
                hash = hash * 23 + AuthClientPinCode.GetHashCode();

                return hash;
            }
            /* #FORMA MAIS SIMPLES:
            return HashCode.Combine(AuthClientAccountId, AuthClientCpf, AuthClientPinCode); */
        }

        /// <summary>
        /// Realiza a Autenticação do cliente no sistema se os dados de entrada forem válidos.
        /// </summary>
        /// <param name="clientAuthInput">Recebe os dados de Autenticação do cliente.</param>
        internal static void Authenticate(Authentication clientAuthInput)
        {
            //Captura o Id da Conta e o número da Agência para realizar o login.
            RegisteredAuthenticationData.GetCheckingAccountInformation(clientAuthInput.AuthClientAccountId, clientAuthInput.AuthClientBankBranch);
            //Captura o Id da Conta para carregar os dados do Cliente.
            RegisteredClients.GetRegisteredClientsInfo(clientAuthInput.AuthClientAccountId);
            //---
            RegisteredAuthenticationData registeredAuthenticationData = new RegisteredAuthenticationData();
            var authDataList = registeredAuthenticationData.RegisteredAuthData;

            foreach (var client in authDataList)
            {
                if (clientAuthInput is not null && clientAuthInput.Equals(client))
                {
                    //Chama o método ValidClientData e passa os dados de Autenticação do cliente para a instanciação da sua Conta Corrente.
                    ValidClientData(clientAuthInput);
                }
            }
            InvalidClientData();
        }

        /// <summary>
        /// Recebe uma conta válida e autenticada para criar a instância desta conta e passar para o construtor da classe AuthenticatedScreen, onde será utilizada para a realização das operações financeiras.
        /// </summary>
        /// <param name="accountId">Recebe o número da Conta Corrente do cliente autenticado.</param>
        /// <param name="bankBranch">Recebe o número da Agência bancária do cliente autenticado.</param>
        /// <returns>Retorna a instância da Conta Corrente do cliente autenticado.</returns>
        private static Client InitializeClientAccount(string accountId, int bankBranch)
        {
            RegisteredClients registeredClients = new RegisteredClients();
            var clientsAccountList = registeredClients.Clients;

            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.CheckingAccount!.AccountId is not null && client.CheckingAccount!.AccountId!.Equals(accountId) && client.CheckingAccount.BankBranch == bankBranch)
                    {
                        return client;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            return null!;
        }

        /// <summary>
        /// Recebe os dados de Autenticação de um cliente que foi autenticado com sucesso, para direcioná-lo para a área logada do sistema (AuthenticatedScreen).
        /// </summary>
        /// <param name="getClientAccountData">Recebe a instância dos dados de Autenticação do cliente.</param>
        private static void ValidClientData(Authentication getClientAccountData)
        {
            PrintText.SetLineBreak(2);
            PrintTextAnimations.AcessingSystemAnimation("Validando os dados da sua conta");
            Client clientAccount = InitializeClientAccount(getClientAccountData.AuthClientAccountId, getClientAccountData.AuthClientBankBranch);
            //Passa os dados da Conta Corrente para o construtor da classe AuthenticatedScreen para que a mesma possa ser utilizada na área logada.
            _ = new AuthenticatedScreen(clientAccount);
        }

        /// <summary>
        /// Método chamado quando os dados de Autenticação do cliente são inválidos.
        /// </summary>
        private static void InvalidClientData()
        {
            PrintText.SetLineBreak(2);
            PrintTextAnimations.AcessingSystemAnimation("Validando os dados da sua conta");
            PrintText.ColorizeText("\n\n[!] Dados inválidos!", PrintText.TextColor.DarkRed);
            Console.Write("\n[i] Digite |1| para tentar novamente ou |2| para voltar à tela inicial\n");
            PrintText.UserInputIndicator();
            int readKeyboard = InputValidation.ValidateMenuOptionInput(1, 2);
            if (readKeyboard == 1)
            {
                _ = new AuthenticationScreen();
            }
            else if (readKeyboard == 2)
            {
                StartScreen.ReturningToStartScreenMessage();
            }
        }
    }
}