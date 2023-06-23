/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 23/06/2023
 */

using System;
using Bytebank.Utils;
using Bytebank.StartScreenComponents;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthenticationScreen
    {
        protected internal static void ShowAuthenticationDialog()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            PrintText.DecorateTitleText(" AUTENTICAÇÃO ", '~');
            //Recebendo o número da conta e validando.
            string clientAccountId = string.Empty;
            while (true)
            {
                PrintText.ColorizeText("\nInforme o número da sua conta   : ", PrintText.TextColor.White, 0);
                clientAccountId = Console.ReadLine()!;

                if (clientAccountId.Length == 6 && clientAccountId.Contains("-") && clientAccountId.EndsWith("X") && int.TryParse(clientAccountId.Substring(0, 4), out _)) // Uso do discard*
                {
                    break;
                }
                else
                {
                    PrintText.ColorizeText("\n[!] Número de conta inválido! O número de conta deve ter a formatação 0000-X.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog("ou digite sua conta novamente: ");
                }
            }
            //Recebendo o número do CPF
            PrintText.ColorizeText("\nInforme o seu CPF (Nºs apenas)  : ", PrintText.TextColor.White, 0);
            string clientCpf = Console.ReadLine()!;

            //Recebendo a senha e validando.
            int clientPassword = 0;
            while (true)
            {
                PrintText.ColorizeText("\nInforme a senha (4 dígitos): ", PrintText.TextColor.White, 0);
                string passwordInput = Console.ReadLine()!;

                if (int.TryParse(passwordInput, out clientPassword) && clientPassword >= 0 && clientPassword <= 9999)
                {
                    if (clientPassword.ToString("D4") == passwordInput)
                    {
                        break; // A saída do loop ocorre quando uma senha válida é fornecida
                    }
                }

                Console.WriteLine("Senha inválida! A senha deve ter 4 dígitos numéricos.");
                Console.WriteLine("Por favor, tente novamente.");
            }

            Authentication clientInfo = new Authentication(clientAccountId, clientCpf, clientPassword);
            Authentication.Authenticate(clientInfo);
        }
    }
}

/* A notação de descarte _ é uma característica introduzida no C# 7.0 que permite ignorar um valor retornado por um método ou uma expressão quando você não está interessado nesse valor. 
 * É útil quando você precisa chamar um método que retorna um valor, mas não precisa usá-lo explicitamente em seu código.
*/