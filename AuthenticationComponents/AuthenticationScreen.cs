/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 19/07/2023
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
            string accountId = InputValidation.ValidateAccountIdInput("Authentication");
            return accountId;
        }
        private static int RequireClientBankBranch()
        {
            int bankBranch = InputValidation.ValidateBankBranchInput("Authentication");
            return bankBranch;
        }
        private static int RequireClientPinCode()
        {
            int pinCode = InputValidation.ValidatePinCodeInput();
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

/* A notação de descarte _ é uma característica introduzida no C# 7.0 que permite ignorar um valor retornado por um método ou uma expressão quando você não está interessado nesse valor. 
 * É útil quando você precisa chamar um método que retorna um valor, mas não precisa usá-lo explicitamente em seu código.
*/