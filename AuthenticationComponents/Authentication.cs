/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 26/06/2023
 */

using Bytebank.Authenticated;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;

namespace Bytebank.AuthenticationComponents
{
    public class Authentication
    {
        //internal static string? _getAccountId;

        public string AuthClientAccountId { get; set; }
        public string AuthClientCpf { get; set; }
        public int AuthClientPinCode { get; set; }

        public Authentication()
        {
            AuthClientAccountId = "";
            AuthClientCpf = "";
            AuthClientPinCode = 0;
        }

        public Authentication(string clientId, string clientCpf, int clientPassword)
        {
            AuthClientAccountId = clientId;
            AuthClientCpf = clientCpf;
            AuthClientPinCode = clientPassword;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) //Verifica se o objeto é NULO ou diferente do tipo Authentication
            {
                return false;
            }
            Authentication otherObj = (Authentication)obj; //É feita a conversão do objeto otherObj para Authentication, já que a verificação anterior garante que obj é do mesmo tipo.

            return AuthClientAccountId == otherObj.AuthClientAccountId &&
                   AuthClientCpf == otherObj.AuthClientCpf &&
                   AuthClientPinCode == otherObj.AuthClientPinCode;
        }
        public override int GetHashCode()
        {
            unchecked // Desabilita o overflow da operação
            {
                int hash = 17; // Número primo inicial

                // Combina o hash das propriedades com o hash atual
                hash = hash * 23 + AuthClientAccountId.GetHashCode();
                hash = hash * 23 + AuthClientCpf.GetHashCode();
                hash = hash * 23 + AuthClientPinCode.GetHashCode();

                return hash;
            }
            /* #FORMA MAIS SIMPLES:
            return HashCode.Combine(AuthClientAccountId, AuthClientCpf, AuthClientPinCode); */

        }

        private static void ValidClientData(Authentication getClientAccountId)
        {
            AuthenticatedScreen.GetAccountId(getClientAccountId);
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

        private static readonly List<Authentication> registeredClients = new()
        {
            { new Authentication("1111-X", "12345678999", 2468) },
            { new Authentication("1020-X", "12345678900", 1234) },
            { new Authentication("1120-X", "00987654321", 4321) },
        };

        internal static void Authenticate(Authentication clientAuthInput)
        {
            //#MEU CÓDIGO: Utilizando o foreach com comparação direta entre o objeto e a lista. 
            //<!> Precisa que os métodos Equals() e GetHashCode() sejam sobrescritos para que compare os contéudos dos objetos e não os objetos em si.
            foreach (var client in registeredClients)
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

            //#MAIS CÓDIGO: Utilizando forearch com comparação direta entre as propriedades do objeto.
            /*foreach (var client in registeredClients)
            {
                if (clientAuthInput.AuthClientAccountId == client.AuthClientAccountId &&
                    clientAuthInput.AuthClientCpf == client.AuthClientCpf &&
                    clientAuthInput.AuthClientPinCode == client.AuthClientPinCode)
                {
                    ValidClientData(client);
                    return;
                }
            }
            InvalidClientData();
            */
            //-------------------------------------------------------------------------------------------------------------------
        }
    }
}