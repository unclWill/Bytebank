/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 30/06/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.AuthenticationComponents.Authenticated
{
    public class AuthenticatedScreen
    {
        private static string? _accountId;

        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        internal static void ShowAuthenticatedScreen()
        {
            Console.Clear();
            ShowAuthenticatedMenu();
        }

        //Pega como parâmetro o número da conta do cliente no momento que os dados de autenticação são validados na classe Authentication.
        internal static void GetAccountId(Authentication accountId)
        {
            _accountId = accountId.AuthClientAccountId;
        }

        private static void ShowClientAccountBasicInfo()
        {
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            Console.WriteLine($"Conta: {_accountId}");
            PrintText.SetLineBreak();
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