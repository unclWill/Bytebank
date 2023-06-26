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
        public string AuthClientAccountId { get; private set; }
        public string AuthClientCpf { get; private set; }
        public int AuthClientPassword { get; private set; }

        public Authentication(string clientId, string clientCpf, int clientPassword)
        {
            AuthClientAccountId = clientId;
            AuthClientCpf = clientCpf;
            AuthClientPassword = clientPassword;
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
                   AuthClientPassword == otherObj.AuthClientPassword;
        }
        public override int GetHashCode()
        {
            unchecked // Desabilita o overflow da operação
            {
                int hash = 17; // Número primo inicial

                // Combina o hash das propriedades com o hash atual
                hash = hash * 23 + AuthClientAccountId.GetHashCode();
                hash = hash * 23 + AuthClientCpf.GetHashCode();
                hash = hash * 23 + AuthClientPassword.GetHashCode();

                return hash;
            }
        }

        internal static void Authenticate(Authentication authData)
        {
            //---DADOS DE CLIENTE HARDCODED
            Authentication authClient = new Authentication("1020-X", "12345678900", 1234);

            //AuthenticationScreen authScreen = new AuthenticationScreen();
            if (authData.Equals(authClient))
            {
                ValidClientData();
            }
            else
            {
                InvalidClientData();
            }
        }

        private static void ValidClientData()
        {
            PrintText.AcessingSystemAnimationText("Validando os dados da sua conta");
            AuthenticatedScreen.ShowMainMenu();
        }
        private static void InvalidClientData()
        {
            PrintText.AcessingSystemAnimationText("Validando os dados da sua conta");
            PrintText.ColorizeText("\n\n[!] Dados inválidos!", PrintText.TextColor.DarkRed, 1);
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
    }
}