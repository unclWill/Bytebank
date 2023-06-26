/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 26/06/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthenticationScreen
    {
        private static string RequireClientId(string clientId)
        {
            while (true)
            {
                PrintText.ColorizeText("\nInforme o número da sua conta   : ", PrintText.TextColor.White, 0);
                clientId = Console.ReadLine()!;

                if (clientId.Length == 6 && clientId.Contains('-') && clientId.EndsWith("X") && int.TryParse(clientId.AsSpan(0, 4), out _)) // Uso do discard*
                {
                    break;
                }
                else
                {
                    PrintText.ColorizeText("\n[!] Número de conta inválido! O número de conta deve ter a formatação 0000-X.\n", PrintText.TextColor.DarkRed, 0);
                    StartScreen.EscapeFromScreenDialog("Pressione |", ConsoleKey.Escape, "| para retornar à tela incial ou digite sua conta para tentar novamente: ");
                }
            }
            return clientId;
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
                PrintText.ColorizeText("\nInforme sua senha (4 dígitos)   : ", PrintText.TextColor.White, 0);
                string passwordInput = Console.ReadLine()!;

                if (int.TryParse(passwordInput, out clientPassword) && clientPassword >= 0 && clientPassword <= 9999)
                {
                    if (clientPassword.ToString("D4") == passwordInput)
                    {
                        break; // A saída do loop ocorre quando uma senha válida é fornecida
                    }
                }

                PrintText.ColorizeText("\n[i] Senha inválida! A senha deve ter 4 dígitos numéricos.", PrintText.TextColor.DarkRed);
                Console.WriteLine("[i] Por favor, tente novamente.");
            }
            return clientPassword;
        }

        protected internal static void ShowAuthenticationDialog()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            Console.WriteLine();
            PrintText.DecorateTitleText("           AUTENTICAÇÃO           ", '~');
            PrintText.ColorizeText("\n[i] Para acessar a sua conta informe seus dados logo abaixo: ", PrintText.TextColor.DarkGray);

            //Recebendo o número da conta e validando.
            string clientAccountId = string.Empty;
            //Recebendo o número do CPF
            string clientCpf = string.Empty;
            //Recebendo a senha e validando.
            int clientPassword = 0;

            Authentication clientInfo = new Authentication(RequireClientId(clientAccountId), RequireClientCpf(clientCpf), RequireClientPassword(clientPassword));
            Authentication.Authenticate(clientInfo);
        }
    }
}

/* A notação de descarte _ é uma característica introduzida no C# 7.0 que permite ignorar um valor retornado por um método ou uma expressão quando você não está interessado nesse valor. 
 * É útil quando você precisa chamar um método que retorna um valor, mas não precisa usá-lo explicitamente em seu código.
*/