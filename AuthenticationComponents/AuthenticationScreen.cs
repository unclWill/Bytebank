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
            //Recebendo o número do CPF
            string clientCpf = string.Empty;
            //Recebendo a senha e validando.
            int clientPassword = 0;

            Authentication clientInfo = new Authentication(RequireClientId(clientAccountId), RequireClientCpf(clientCpf), RequireClientPassword(clientPassword));
            Authentication.Authenticate(clientInfo);
        }

        private static string RequireClientId(string clientAccountId)
        {
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
                    StartScreen.EscapeFromScreenDialog("Pressione |", ConsoleKey.Escape, "| para retornar à tela incial ou digite sua conta para tentar novamente: ");
                }
            }
            return clientAccountId;
        }

        private static string RequireClientCpf(string clientCpf)
        {
            PrintText.ColorizeText("\nInforme o seu CPF (Nºs apenas)  : ", PrintText.TextColor.White, 0);
            clientCpf = Console.ReadLine()!;
            return clientCpf;
        }

        private static int RequireClientPassword(int clientPassword)
        {
            while (true)
            {
                PrintText.ColorizeText("\nInforme a senha (4 dígitos)     : ", PrintText.TextColor.White, 0);
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
            return clientPassword;
        }
    }
}

/* A notação de descarte _ é uma característica introduzida no C# 7.0 que permite ignorar um valor retornado por um método ou uma expressão quando você não está interessado nesse valor. 
 * É útil quando você precisa chamar um método que retorna um valor, mas não precisa usá-lo explicitamente em seu código.
*/