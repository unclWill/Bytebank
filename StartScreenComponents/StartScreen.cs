/* Classe  : StartScreenComponents
 * Objetivo: Concentra os métodos personalizados utilizados na tela inicial do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 20/07/2023
 */

using System;
using Bytebank.Utils;
using Bytebank.AuthenticationComponents;
using Bytebank.Authenticated;
using System.Data;

namespace Bytebank.StartScreenComponents
{
    /// <summary>
    /// Classe <code>StartScreenComponents</code>
    /// Concentra os métodos personalizados utilizados na tela inicial do sistema.
    /// </summary>
    internal class StartScreen
    {
        /// <summary>
        /// Exibe os itens que compõe a tela inicial do sistema.
        /// </summary>
        internal static void ShowStartScreen()
        {
            ShowAppWindowTitle();
            HeaderText.BytebankLogoHeader();
            ShowGreetingAndDateTime();
            ShowStartServiceAtTerminalDialog();
        }

        /// <summary>
        /// Método <code>EscapeFromScreenDialog</code>
        /// Diálogo que permite voltar à tela inicial ao pressionar uma determinada tecla.
        /// <code>Retorna uma ConsoleKey para ser usada como controle de execução.</code>
        /// <code>Aceita uma sobrecarga que recebe como parâmetros uma string screenType, que se refere à tela da qual o método irá retornar:
        /// "Authentication" retorna para a tela inicial do terminal;
        /// "Authenticated" retorna para a tela do menu de operações da área logada.</code>
        /// </summary>
        internal static ConsoleKey EscapeFromScreenDialog(string screenType, string? primaryText, ConsoleKey escapeKey, string? secondaryText)
        {
            Console.Write($"\n[i] {primaryText} {escapeKey} {secondaryText}\n");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (screenType)
            {
                case "Authentication":
                    if (keyPressed.Key == escapeKey)
                    {
                        ReturningToStartScreenMessage();
                    }
                    break;
                case "Authenticated":
                    if (keyPressed.Key == escapeKey)
                    {
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage();
                    }
                    break;
            }
            return escapeKey;
        }

        internal static ConsoleKey EscapeFromScreenDialog(string screenType, ConsoleKey escapeKey)
        {
            Console.Write($"\n[i] Pressione |{ConsoleKey.Escape}| para retornar à tela anterior ou pressione qualquer tecla para tentar novamente\n");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (screenType)
            {
                case "Authentication":
                    if (keyPressed.Key == escapeKey)
                    {
                        ReturningToStartScreenMessage();
                    }
                    break;
                case "Authenticated":
                    if (keyPressed.Key == escapeKey)
                    {
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage();
                    }
                    break;
            }
            return escapeKey;
        }

        internal static ConsoleKey EscapeFromTransferScreenDialog(ConsoleKey escapeKey)
        {
            Console.Write($"\n[i] Pressione |{ConsoleKey.Escape}| para retornar à tela anterior ou pressione qualquer tecla para tentar novamente\n");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == escapeKey)
            {
                AuthenticatedScreen.ReturningToAuthenticatedScreenMessage();
            }
            return escapeKey;
        }

        internal static ConsoleKey EscapeFromScreenDialog(ConsoleKey escapeKey)
        {
            Console.Write($"\n[i] Pressione |{ConsoleKey.Escape}| para retornar à tela anterior ou pressione qualquer tecla para tentar novamente\n");
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            if (keyPressed.Key == escapeKey)
            {
                ReturningToStartScreenMessage();
            }
            return escapeKey;
        }

        /// <summary>
        /// Exibe uma mensagem que informa que o sistema está retornando a tela inicial.
        /// </summary>
        internal static void ReturningToStartScreenMessage()
        {
            PrintText.ColorizeText("\n[i] Retornando à tela inicial", PrintText.TextColor.Yellow, 0);
            PrintTextAnimations.TreeDotsAnimation();
            ShowStartScreen();
        }

        /// <summary>
        /// Exibe o logo do Bytebank estilizado com caracteres ASCII.
        /// </summary>

        /// <summary>
        /// Exibe o título da janela.
        /// </summary>
        private static void ShowAppWindowTitle()
        {
            Console.Title = "Bytebank Terminal";
        }

        /// <summary>
        /// Exibe uma saudação e informa data e hora de entrada do usuário no sistema
        /// </summary>
        private static void ShowGreetingAndDateTime()
        {
            DateTime dateTimeNow = DateTime.Now;
            Console.Write("\n\n  Boas vindas ao Terminal do Bytebank!\n");
            Console.Write($"     Acesso em: {dateTimeNow}\n\n");
        }

        /// <summary>
        /// Exibe o diálogo responsável por iniciar um atendimento.
        /// </summary>
        private static void ShowStartServiceAtTerminalDialog()
        {
            PrintText.DecoratedTitleText(" Digite |1| para iniciar o seu atendimento", '-');
            PrintText.ColorizeText("\n|1| ENTRAR NA MINHA CONTA  ", PrintText.TextColor.Gray, 0);
            PrintText.ColorizeText("|2| ENCERRAR TERMINAL\n", PrintText.TextColor.DarkGray);
            PrintText.UserInputIndicator();
            //Lê e valida o campo selectedOption, SE NÃO for um valor inteiro entra no loop, exibe um erro e aguarda uma entrada válida.
            int menuOption = InputValidation.ValidateMenuOptionInput();

            if (menuOption < 1 | menuOption > 2)
            {
                ShowStartScreen();
            }
            else if (menuOption == 1)
            {
                AuthenticationScreen.ShowAuthenticationDialog();
            }
            else if (menuOption == 2)
            {
                ShowAppFinalizationDialog();
            }
        }

        /// <summary>
        /// Exibe o diálogo de finalização do sistema.
        /// </summary>
        private static void ShowAppFinalizationDialog()
        {
            Console.Write("\n[i] Liberando terminal");
            PrintTextAnimations.TreeDotsAnimation();
            Console.Write("\n\n[i] Terminal liberado! Obrigado por utlilizar o Bytebank.\n\n");

            PrintText.ColorizeText("Finalizando ", PrintText.TextColor.DarkGray, 0);
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(500);
                PrintText.ColorizeText("|||", PrintText.TextColor.DarkMagenta, 0);
            }
        }
    }
}