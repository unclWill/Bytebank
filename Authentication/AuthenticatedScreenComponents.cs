/* Classe  : AuthenticatedScreenComponents
 * Objetivo: Concentra os métodos personalizados utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: DD/MM/AAAA
 */

using System;
using Bytebank.Utils;

namespace Bytebank.Authentication
{
    public class AuthenticatedScreenComponents
    {
        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        protected internal static void ShowMainMenu()
        {
            PrintText.HighlightTitleText("MENU", '-');
            PrintText.ColorizeText("Operações disponíveis neste terminal", PrintText.TextColor.DarkGray, 1);
        }
    }
}