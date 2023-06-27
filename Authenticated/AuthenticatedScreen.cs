/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 26/06/2023
 */

using Bytebank.AuthenticationComponents;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.Authenticated
{
    public class AuthenticatedScreen
    {
        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        internal static void ShowAuthenticatedScreen()
        {
            ShowAuthenticatedMenu();
        }

        private static void ShowClientAccountBasicInfo()
        {
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            Authentication authenticatedInfo = new Authentication();
            Console.WriteLine(authenticatedInfo.AuthClientAccountId = "TESTE");
            Console.WriteLine(authenticatedInfo.AuthClientCpf = "12345678900");
            Console.WriteLine(authenticatedInfo.AuthClientPassword);
            Console.WriteLine();
        }

        private static void ShowAuthenticatedMenu()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            PrintText.DecorateTitleText("  TERMINAL DE OPERAÇÕES FINANCEIRAS DO BYTEBANK  ", '~');
            PrintText.SetLineBreak(2);
            //
            ShowClientAccountBasicInfo();
            PrintText.DecorateTitleText(" Operações disponíveis neste terminal ", '-');
            PrintText.ColorizeText("|1| DEPÓSITO\n|2| SAQUE\n|3| TRANSFERÊNCIA", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecorateTitleText("             Área do cliente          ", '-');
            PrintText.ColorizeText("|4| CONSULTAR MEUS DADOS\n|5| CONSULTAR MEU HISTÓRICO FINANCEIRO\n|6| TROCAR MINHA SENHA DE ACESSO", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecorateTitleText("          Finalizar atendimento       ", '-');
            PrintText.ColorizeText("|7| ENCERRAR TERMINAL", PrintText.TextColor.DarkYellow);

            ConsoleKey keyPressed = StartScreen.EscapeFromScreenDialog("Para retornar a tela incial pressione |", ConsoleKey.Enter, "| ou aguarde.");
            if (keyPressed == ConsoleKey.Enter)
            {
                StartScreen.ReturningToStartScreenMessage();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
        }


    }
}