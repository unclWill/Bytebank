/* Classe  : StartScreenComponents
 * Objetivo: Concentra os métodos personalizados utilizados na tela inicial do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 26/06/2023
 */

using System;
using Bytebank.Utils;
using Bytebank.AuthenticationComponents;

namespace Bytebank.StartScreenComponents
{
    /// <summary>
    /// Classe <code>StartScreenComponents</code>
    /// Concentra os métodos personalizados utilizados na tela inicial do sistema.
    /// </summary>
    public class StartScreen
    {
        /// <summary>
        /// Exibe os itens que compõe a tela inicial do sistema.
        /// </summary>
        internal static void ShowStartScreen()
        {
            Console.Clear();
            ShowAppWindowTitle();
            ShowProductOwnerBrand();
            ShowGreetingAndDateTime();
            ShowStartServiceAtTerminalDialog();
        }

        /// <summary>
        /// Método <code>EscapeFromScreenDialog</code>
        /// Diálogo que permite voltar à tela inicial ao pressionar uma determinada tecla.
        /// Retorna uma ConsoleKey para ser usada como controle de execução.
        /// </summary>
        internal static ConsoleKey EscapeFromScreenDialog(string? primaryText, ConsoleKey escapeKey, string? secondaryText)
        {
            Console.Write($"\n[i] {primaryText} {escapeKey} {secondaryText}\n");
            PrintText.UserInteractionIndicator();
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
            PrintText.TreeDotsAnimationText();
            ShowStartScreen();
        }

        /// <summary>
        /// Exibe o logo do Bytebank estilizado com caracteres ASCII.
        /// </summary>
        internal static void ShowProductOwnerBrand()
        {
            string productOwnerBrand = @"
 ______                  _                 _     
(____  \       _        | |               | |    
 ____)  )_   _| |_  ____| | _   ____ ____ | |  _ 
|  __  (| | | |  _)/ _  ) || \ / _  |  _ \| | / )
| |__)  ) |_| | |_( (/ /| |_) | ( | | | | | |< ( 
|______/ \__  |\___)____)____/ \_||_|_| |_|_| \_)
        (____/";
            PrintText.ColorizeText(productOwnerBrand, PrintText.TextColor.DarkMagenta, 1);
        }

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
            PrintText.DecorateTitleText(" Digite |1| para iniciar o seu atendimento", '-');
            PrintText.ColorizeText("\n|1| ENTRAR NA MINHA CONTA  ", PrintText.TextColor.Green, 0);
            PrintText.ColorizeText("|2| ENCERRAR TERMINAL\n", PrintText.TextColor.DarkGreen, 1);
            PrintText.UserInteractionIndicator();
            int selectedOption;
            //Lê e valida o campo selectedOption, SE NÃO for um valor inteiro entra no loop, exibe um erro e aguarda uma entrada válida.
            while (!int.TryParse(Console.ReadLine(), out selectedOption))
            {
                PrintText.ColorizeText("\n[!] Digite uma opção válida! |1| ou |2| \n[>>] ", PrintText.TextColor.DarkRed, 0);
            }

            if (selectedOption < 1 | selectedOption > 2)
            {
                ShowStartScreen();
            }
            else if (selectedOption == 1)
            {
                AuthenticationScreen.ShowAuthenticationDialog();
            }
            else if (selectedOption == 2)
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
            PrintText.TreeDotsAnimationText();
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