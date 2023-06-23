﻿/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: 23/06/2023
 */

using System;
using Bytebank.Utils;
using Bytebank.StartScreenComponents;
using Bytebank.AuthenticationComponents;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            //Diálogos da tela inicial.
            StartScreen.ShowStartScreen();
            //Ações para usuário autenticado.
            ExecuteCommands();
            //Finalizar a execução.
        }

        public static void ExecuteCommands()
        {

        }

    }
}