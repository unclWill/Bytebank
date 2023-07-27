/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 27/07/2023
 */

using System.Security.Cryptography.X509Certificates;
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
            //Chama o construtor da classe StartScreen, que exibe a tela inicial do sistema.
            _ = new StartScreen();
        }
    }
}