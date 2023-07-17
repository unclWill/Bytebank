/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 14/07/2023
 */

using Bytebank.AuthenticationComponents.Authenticated;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;

namespace Bytebank.AuthenticationComponents
{
    public class Authentication
    {
        public string AuthClientAccountId { get; }
        public string AuthClientBankBranch { get; }
        public int AuthClientPinCode { get; }

        public Authentication(string clientId, string clientBankBranch, int clientPinCode)
        {
            AuthClientAccountId = clientId;
            AuthClientBankBranch = clientBankBranch;
            AuthClientPinCode = clientPinCode;
        }

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
            PrintText.UserInteractionIndicator();
            string readKeyboard = Console.ReadLine()!;
            if (readKeyboard == "1")
            {
                AuthenticationScreen.ShowAuthenticationDialog();
            }
            else
            {
                StartScreen.ReturningToStartScreenMessage();
            }
        }

        //Lista de contas cadastradas
        internal static readonly List<Authentication> registeredClients = new()
        {
            { new Authentication("1010-X", "15", 1234) },
            { new Authentication("1018-5", "17", 4321) },
            { new Authentication("8594-6", "16", 2468) },
        };

        internal static void Authenticate(Authentication clientAuthInput)
        {
            //#MEU CÓDIGO: Utilizando o foreach com comparação direta entre o objeto e a lista. 
            //<!> Precisa que os métodos Equals() e GetHashCode() sejam sobrescritos para que compare os contéudos dos objetos e não os objetos em si.
            foreach (var client in registeredClients) //Este trecho do código apresentou comportamentos estranhos!
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
    }
}