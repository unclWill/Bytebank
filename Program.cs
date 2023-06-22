/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 22/06/2023
 */

using System;
using Bytebank.Utils;
using Bytebank.Authentication;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            //Diálogos da tela inicial.
            StartScreenComponents.ShowStartScreen();
            //Ações para usuário autenticado.
            ExecuteCommands();
            //Finalizar a execução.
        }

        public static void ExecuteCommands()
        {

        }

    }
}