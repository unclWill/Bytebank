/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: DD/MM/AAAA
 */

using System;
using Bytebank.Utils;
using Bytebank.StartScreenComponents;
using Bytebank.AuthenticationComponents;

namespace Bytebank.Authenticated
{
    public class AuthenticatedScreen
    {
        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        protected internal static void ShowMainMenu()
        {
            Console.Clear();
            PrintText.DecorateTitleText("MENU", '-');
            PrintText.ColorizeText("Operações disponíveis neste terminal", PrintText.TextColor.DarkGray, 1);

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