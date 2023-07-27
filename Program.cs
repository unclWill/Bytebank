/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 27/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.StartScreenComponents;

using System;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            ExecuteCommands();
        }

        public static void ExecuteCommands()
        {
            StartScreen.ShowStartScreen();
        }
    }
}