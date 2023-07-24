/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 24/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bytebank.AuthenticationComponents
{
    /// <summary>
    /// Classe AuthenticationScreen
    /// <code>Exibe a tela de autenticação de verificando se um Cliente existe no sistema.</code>
    /// </summary>
    internal class AuthenticationScreen
    {
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

        protected internal static void ShowAuthenticationDialog()
        {
            HeaderText.BytebankLogoHeader();
            PrintText.DecoratedTitleText("           AUTENTICAÇÃO           ", '~');
            PrintText.ColorizeText("\n[i] Para acessar a sua conta informe seus dados logo abaixo", PrintText.TextColor.DarkGray);
            //
            Authentication clientAuthData = new Authentication(RequireAccountId(), RequireBankBranch(), RequirePinCode());
            Authentication.Authenticate(clientAuthData);
        }
    }
}