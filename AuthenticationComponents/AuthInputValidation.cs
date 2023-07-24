/* Classe  : AuthInputValidation
 * Objetivo: Contém os métodos que realizam as validações no processo de autenticação do usuário no sistema e também na operação de tranferência de recursos financeiros.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 23/07/2023 (Criação) | Modificação: 24/07/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.HARDCODED_DATABASE;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthInputValidation
    {

        /// <summary>
        /// Valida a entrada do número da Conta Corrente do cliente.
        /// </summary>
        /// <param name="validationScreenType">Determina se ao pressionar a tecla Esc o sistema deve retornar para a tela de AUtenticação ou para a tela Autenticada.</param>
        /// <returns>Se o dado for inserido no format correto, retorna o número da Conta Corrente para o porcesso de autenticação.</returns>
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

        /// <summary>
        /// Valida a entrada do número da agência bancária.
        /// </summary>
        /// <param name="validationScreenType">Determina se ao pressionar a tecla Esc o sistema deve retornar para a tela de AUtenticação ou para a tela Autenticada.</param>
        /// <returns>Se o dado for inserido no format correto, retorna o número da agência para o processo de autenticação.</returns>
        internal static int ValidateBankBranchInput(string validationScreenType)
        {
            int clientBankBranchInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme o Nº da Agência", PrintText.TextColor.Gray, " (no formato 00)", PrintText.TextColor.DarkGray);
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

        /// <summary>
        /// Valida a entrada do número da agência bancária.
        /// </summary>
        /// <returns>Se o formato for inserido corretamente, retorna a senha para o processo de autenticação.</returns>
        internal static int ValidatePinCodeInput()
        {
            string pinCodeInput;
            while (true)
            {
                PrintText.ColorizeText("\nInforme sua senha", PrintText.TextColor.Gray, " (4 dígitos numéricos)", PrintText.TextColor.DarkGray);
                PrintText.UserInputIndicator(PrintText.TextColor.DarkGray);
                pinCodeInput = MaskPassword().Trim();
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

        /// <summary>
        /// Aplica uma máscara na senha digitada pelo usuário.
        /// </summary>
        /// <param name="mask">Determina o caractere que será utilizado no mascaramento da senha.</param>
        /// <returns>Retorna os caracteres da senha e exibe os mesmos como o caractere de máscara definido.</returns>
        private static string MaskPassword(char mask = '*')
        {
            string password = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); //Indica que a tecla pressionada não será exibida no console.

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        PrintText.ColorizeText("\b \b", PrintText.TextColor.White, 0); //Apaga o caractere do console.
                    }
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    PrintText.ColorizeText(mask, PrintText.TextColor.DarkMagenta, 0);
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }
    }
}