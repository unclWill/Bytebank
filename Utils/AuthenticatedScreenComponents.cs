using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    public class AuthenticatedScreenComponents
    {
        /// <summary>
        /// Exibe o menu da tela inicial.
        /// </summary>
        protected internal static void ShowMainMenu()
        {
            PrintText.HighlightTitleText("MENU", '-');
            PrintText.ColorizeText("Operações disponíveis neste terminal", PrintText.TextColor.DarkGray, 1);
        }
    }
}