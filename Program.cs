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
            //Diálogos da tela inicial.
            StartScreenComponents.ShowApplicationWindowTitle();
            StartScreenComponents.ShowBytebankLogo();
            StartScreenComponents.ShowStartServiceAtTerminalDialog();
            //Ações para usuário autenticado.
            ExecuteCommands();
            //Finalizar a execução.
            StartScreenComponents.ShowPressKeyToEndDialog();
        }

        public static void ExecuteCommands()
        {

        }

    }
}