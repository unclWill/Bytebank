/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: DD/MM/AAAA
 */

using Bytebank.Utils;
using Bytebank.Authenticated;
using Bytebank.StartScreenComponents;

namespace Bytebank.AuthenticationComponents
{
    public class Authentication
    {
        //Fields

        //Properties
        public string AuthClientAccountId { get; set; }
        public string AuthClientCpf { get; set; }
        public int AuthClientPassword { get; set; }

        //Constructor
        public Authentication(string clientId, string clientCpf, int clientPassword)
        {
            AuthClientAccountId = clientId;
            AuthClientCpf = clientCpf;
            AuthClientPassword = clientPassword;
        }

        //Methods
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

        protected internal static void Authenticate(Authentication authInfo)
        {
            //---DADOS DE CLIENTE HARDCODED
            Authentication authClient = new Authentication("1020-X", "12345678900", 1234);

            //AuthenticationScreen authScreen = new AuthenticationScreen();
            if (authInfo.Equals(authClient))
            {
                AuthenticatedScreen.ShowMainMenu();
            }
            else
            {
                PrintText.ColorizeText("\n[!] Dados inválidos!", PrintText.TextColor.DarkRed, 1);
                StartScreen.ReturningToStartScreenMessage();
            }
        }

    }
}