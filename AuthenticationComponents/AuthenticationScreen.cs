/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 30/07/2023
 */

using Bytebank.Utils;

namespace Bytebank.AuthenticationComponents.Extensions
{
    /// <summary>
    /// Classe AuthenticationScreen
    /// <code>Exibe a tela de autenticação de verificando se um Cliente existe no sistema.</code>
    /// </summary>
    internal class AuthenticationScreen
    {
        /// <summary>
        /// Construtor padrão da classe AuthenticationScreen.
        /// </summary>
        internal AuthenticationScreen()
        {
            ShowAuthenticationDialog();
        }

        private static string RequireAccountId()
        {
            string accountId = AuthInputValidation.ValidateAccountIdInput("Authentication");
            return accountId;
        }
        private static int RequireBankBranch()
        {
            int bankBranch = AuthInputValidation.ValidateBankBranchInput("Authentication");
            return bankBranch;
        }
        private static int RequirePinCode()
        {
            int pinCode = AuthInputValidation.ValidatePinCodeInput();
            return pinCode;
        }

        private static void ShowAuthenticationDialog()
        {
            HeaderText.BytebankOnlyLogoHeader();
            PrintText.DecoratedTitleText("           AUTENTICAÇÃO           ", '~');
            PrintText.ColorizeText("\n[i] Para acessar a sua conta informe seus dados logo abaixo", PrintText.TextColor.DarkGray);
            //
            Authentication authenticationData = new Authentication(RequireAccountId(), RequireBankBranch(), RequirePinCode());
            Authentication.Authenticate(authenticationData);
        }
    }
}