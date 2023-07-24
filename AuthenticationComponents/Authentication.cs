/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 24/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.Authenticated;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.AccountManagement;

namespace Bytebank.AuthenticationComponents
{
    /// <summary>
    /// Classe Authentication
    ///<code>Recebe os dados de entrada com o formato validado e faz a verificação se os mesmos existem na base de dados.</code>
    /// </summary>
    internal class Authentication
    {
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

        internal static void Authenticate(Authentication clientAuthInput)
        {
            RegisteredAuthenticationData registeredAuthenticationData = new RegisteredAuthenticationData();
            var authDataList = registeredAuthenticationData.RegisteredAuthData;

            foreach (var client in authDataList)
            {
                if (clientAuthInput.Equals(client))
                {
                    ValidClientData(clientAuthInput);
                }
            }
            InvalidClientData();

            //-------------------------------------------- OUTRAS FORMAS DE RESOLVER --------------------------------------------
            //#MAIS OTIMIZADO: Utilizando o método Any() - LINQ e expressão lambda -- NÃO REQUER A REESCRITA DO MÉTODO Equals()
            /*if (registeredClients.Any(client => clientAuthInput.Equals(clientAuthInput)))
            {
                ValidClientData(clientAuthInput);
            }
            else
            {
                InvalidClientData();
            }*/
            //-------------------------------------------------------------------------------------------------------------------
        }

        private static void ValidClientData(Authentication getClientAccountData)
        {
            AuthenticatedScreen.GetAccountData(getClientAccountData); //Passa os dados do cliente para a exibição na área logada.
            PrintTextAnimations.AcessingSystemAnimation("Validando os dados da sua conta");
            AuthenticatedScreen.ShowAuthenticatedScreen();
        }
        private static void InvalidClientData()
        {
            PrintTextAnimations.AcessingSystemAnimation("Validando os dados da sua conta");
            PrintText.ColorizeText("\n\n[!] Dados inválidos!", PrintText.TextColor.DarkRed);
            Console.Write("\n[i] Digite |1| para tentar novamente ou |2| para voltar à tela inicial\n");
            PrintText.UserInputIndicator();
            int readKeyboard = int.Parse(Console.ReadLine()!);
            if (readKeyboard == 1)
            {
                AuthenticationScreen.ShowAuthenticationDialog();
            }
            else if (readKeyboard == 2)
            {
                StartScreen.ReturningToStartScreenMessage();
            }
        }

    }
}