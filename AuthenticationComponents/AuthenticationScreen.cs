/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 14/07/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthenticationScreen
    {
        private static string RequireClientId(string clientIdInput)
        {
            while (true)
            {
                PrintText.ColorizeText("\nInforme o nº da sua conta\n(no formato 0000-X): ", PrintText.TextColor.White, 0);
                clientIdInput = Console.ReadLine()!.Trim();

                if (clientIdInput.Length == 6 && clientIdInput.Contains('-') && char.IsLetterOrDigit(clientIdInput[^1]) && int.TryParse(clientIdInput.AsSpan(0, 4), out _)) // Uso do discard*
                {
                    break;
                }
                else
                {
                    PrintText.ColorizeText("\n[!] Número de conta inválido! O número de conta deve ter a formatação 0000-X.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog("Pressione |", ConsoleKey.Escape, "| para retornar à tela incial ou digite sua conta para tentar novamente: ");
                }
            }
            return clientIdInput;
        }
        private static string RequireClientBankBranch(string clientBankBranchInput)
        {
            while (true)
            {
                PrintText.ColorizeText("\nInforme o nº da sua Agência\n(no formato 00): ", PrintText.TextColor.White, 0);
                clientBankBranchInput = Console.ReadLine()!.Trim();

                //if (clientBankBranchInput.Length == 6 && clientBankBranchInput.Contains('-') && clientBankBranchInput.EndsWith('A') && int.TryParse(clientBankBranchInput.AsSpan(0, 4), out _))
                if (!int.TryParse(clientBankBranchInput, out _))
                {
                    PrintText.ColorizeText("\n[!] A agência informada não é válida! O número da Agência deve ter a formatação 00.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog("Pressione |", ConsoleKey.Escape, "| para retornar à tela incial ou digite sua agência para tentar novamente: ");
                }
                else
                {
                    break;
                }
            }
            return clientBankBranchInput;
        }
        private static int RequireClientPinCode(int clientPinCode)
        {
            string pinCodeInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme sua senha\n(4 dígitos numéricos): ", PrintText.TextColor.White, 0);
                pinCodeInput = Console.ReadLine()!.Trim();

                if (int.TryParse(pinCodeInput, out clientPinCode) && clientPinCode >= 0 && clientPinCode <= 9999)
                {
                    if (clientPinCode.ToString("D4") == pinCodeInput)
                    {
                        break; // A saída do loop ocorre quando uma senha válida é fornecida
                    }
                }

                PrintText.ColorizeText("\n[i] Senha inválida! A senha deve ter 4 dígitos numéricos.", PrintText.TextColor.DarkRed);
                Console.WriteLine("[i] Por favor, tente novamente.");
            }
            return int.Parse(pinCodeInput);
        }

        protected internal static void ShowAuthenticationDialog()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("           AUTENTICAÇÃO           ", '~');
            PrintText.ColorizeText("\n[i] Para acessar a sua conta informe seus dados logo abaixo: ", PrintText.TextColor.DarkGray);

            string clientAccountId = string.Empty;
            string clientBankBranch = string.Empty;
            int clientPinCode = 0;

            Authentication clientAuthData = new Authentication(RequireClientId(clientAccountId), RequireClientBankBranch(clientBankBranch), RequireClientPinCode(clientPinCode));
            Authentication.Authenticate(clientAuthData);
        }
    }
}

/* A notação de descarte _ é uma característica introduzida no C# 7.0 que permite ignorar um valor retornado por um método ou uma expressão quando você não está interessado nesse valor. 
 * É útil quando você precisa chamar um método que retorna um valor, mas não precisa usá-lo explicitamente em seu código.
*/