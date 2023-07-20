/* Classe  : InputVerification
 * Objetivo: Realiza as verificação relacionadas aos dados digitados pelo usuário.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 20/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.StartScreenComponents;

namespace Bytebank.Utils
{
    internal static class InputValidation
    {
        internal static int ValidateMenuOptionInput()
        {
            int optionNumber;
            while (!int.TryParse(Console.ReadLine(), out optionNumber))
            {
                PrintText.ColorizeText("\n[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInputIndicator();
            }
            return optionNumber;
        }

        internal static string ValidateAccountIdInput(string validationScreenType)
        {
            string clientIdInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme o Nº da conta", PrintText.TextColor.Gray, " (no formato 0000-X)", PrintText.TextColor.DarkGray);
                PrintText.UserInputIndicator(PrintText.TextColor.DarkGray);
                clientIdInput = Console.ReadLine()!.Trim();
                if (clientIdInput.Length == 6 && clientIdInput.Contains('-') && char.IsLetterOrDigit(clientIdInput[^1]) && int.TryParse(clientIdInput.AsSpan(0, 4), out _))
                {
                    RegisteredAuthenticationData registeredAuthenticationData = new RegisteredAuthenticationData();
                    registeredAuthenticationData.GetCheckingAccountInformation(clientIdInput);//Captura o Id da Conta e o número da Agência para realizar o login.
                    break;
                }
                else
                {
                    PrintText.ColorizeText("\n[!] Número de conta inválido! O número da conta deve ter a formatação 0000-X.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog(validationScreenType, ConsoleKey.Escape);
                }
            }
            return clientIdInput;
        }

        internal static int ValidateBankBranchInput(string validationScreenType)
        {
            int clientBankBranchInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme o Nº da sua Agência", PrintText.TextColor.Gray, " (no formato 00)", PrintText.TextColor.DarkGray);
                PrintText.UserInputIndicator(PrintText.TextColor.DarkGray);
                //if (clientBankBranchInput.Length == 6 && clientBankBranchInput.Contains('-') && clientBankBranchInput.EndsWith('A') && int.TryParse(clientBankBranchInput.AsSpan(0, 4), out _))
                if (!int.TryParse(Console.ReadLine()!.Trim(), out clientBankBranchInput))
                {
                    PrintText.ColorizeText("\n[!] A agência informada não é válida! O número da Agência deve ter a formatação 00.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog(validationScreenType, ConsoleKey.Escape);
                }
                else
                {
                    break;
                }
            }
            return clientBankBranchInput;
        }

        internal static int ValidatePinCodeInput()
        {
            string pinCodeInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme sua senha", PrintText.TextColor.Gray, " (4 dígitos numéricos)", PrintText.TextColor.DarkGray);
                PrintText.UserInputIndicator(PrintText.TextColor.DarkGray);
                pinCodeInput = Console.ReadLine()!.Trim();
                if (int.TryParse(pinCodeInput, out int clientPinCode) && clientPinCode >= 0 && clientPinCode <= 9999)
                {
                    if (clientPinCode.ToString("D4") == pinCodeInput)
                    {
                        break; // A saída do loop ocorre quando uma senha válida é fornecida
                    }
                }
                else
                {
                    PrintText.ColorizeText("\n[!] A senha informada não é válida! A senha deve conter 4 dígitos numéricos.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog(ConsoleKey.Escape);
                }
                //PrintText.ColorizeText("\n[i] Senha inválida! A senha deve ter 4 dígitos numéricos.", PrintText.TextColor.DarkRed);
                //Console.WriteLine("[i] Por favor, tente novamente.");
            }
            return int.Parse(pinCodeInput);
        }
    }
}