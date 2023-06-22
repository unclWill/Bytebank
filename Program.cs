/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 22/06/2023
 */

using System;
using Bytebank.Utils;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            //
            StartScreenComponents.ShowApplicationWindowTitle();
            StartScreenComponents.ShowBytebankLogo();
            StartScreenComponents.ShowPressKeyToEndDialog();
            //

        }

        public static void ExecuteCommands()
        {

        }

    }
}