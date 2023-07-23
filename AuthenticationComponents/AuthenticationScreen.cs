/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 23/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthenticationScreen
    {
        private static string RequireAccountId()
        {
            string accountId = AuthInputValidation.ValidateAccountIdInput("Authentication");
            return accountId;
        }
        private static int RequireClientBankBranch()
        {
            int bankBranch = AuthInputValidation.ValidateBankBranchInput("Authentication");
            return bankBranch;
        }
        private static int RequireClientPinCode()
        {
            int pinCode = AuthInputValidation.ValidatePinCodeInput();
            return pinCode;
        }

        protected internal static void ShowAuthenticationDialog()
        {
            HeaderText.BytebankLogoHeader();
            PrintText.DecoratedTitleText("           AUTENTICAÇÃO           ", '~');
            PrintText.ColorizeText("\n[i] Para acessar a sua conta informe seus dados logo abaixo", PrintText.TextColor.DarkGray);

            Authentication clientAuthData = new Authentication(RequireAccountId(), RequireClientBankBranch(), RequireClientPinCode());
            Authentication.Authenticate(clientAuthData);
        }
    }
}