/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 27/07/2023
 */

using Bytebank.StartScreenComponents;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            ExecuteCommands();
        }

        private static void ExecuteCommands()
        {
            _ = new StartScreen();
        }
    }
}