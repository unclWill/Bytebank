/* Classe  : StartScreenComponents
 * Objetivo: Concentra os métodos personalizados utilizados na tela inicial do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 23/06/2023
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
        protected internal static void ShowStartScreen()
        {
            Console.Clear();
            ShowApplicationWindowTitle();
            ShowProductOwnerBrand();
            ShowGreetingAndDateTime();
            ShowStartServiceAtTerminalDialog();
        }

        /// <summary>
        /// Exibe o título da janela.
        /// </summary>
        private static void ShowApplicationWindowTitle()
        {
            Console.Title = "Bytebank Terminal";
        }

        /// <summary>
        /// Exibe o logo do Bytebank estilizado com caracteres ASCII.
        /// </summary>
        private static void ShowProductOwnerBrand()
        {
            string productOwnerBrand = @"
 ______                  _                 _     
(____  \       _        | |               | |    
 ____)  )_   _| |_  ____| | _   ____ ____ | |  _ 
|  __  (| | | |  _)/ _  ) || \ / _  |  _ \| | / )
| |__)  ) |_| | |_( (/ /| |_) | ( | | | | | |< ( 
|______/ \__  |\___)____)____/ \_||_|_| |_|_| \_)
        (____/";
            PrintText.ColorizeText(productOwnerBrand, PrintText.TextColor.DarkMagenta, 0);
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
        /// Exibe o diálogo responsável por Iniciar o atendimento ou finalizar o terminal.
        /// </summary>
        private static void ShowStartServiceAtTerminalDialog()
        {
            PrintText.DecorateTitleText(" Digite |1| para iniciar o seu atendimento", '-');
            PrintText.ColorizeText("\n|1| ENTRAR NA MINHA CONTA  ", PrintText.TextColor.Green, 0);
            PrintText.ColorizeText("|2| ENCERRAR TERMINAL\n", PrintText.TextColor.DarkGreen, 1);
            PrintText.UserInteractionIndicator();
            int selectedOption = 0;
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
                AuthenticationScreen authScreen = new AuthenticationScreen();
                AuthenticationScreen.ShowAuthenticationDialog();
            }
            else if (selectedOption == 2)
            {
                Console.Write("\n[i] Liberando terminal");
                PrintText.TreeDotsAnimationText();
                Console.Write("\n\n[i] Terminal liberado! Obrigado por utlilizar o Bytebank.\n\n");
                ShowPressKeyToEndDialog();
            }
        }

        /// <summary>
        /// Exibe o diálogo responsável por finalizar a execução do sistema.
        /// </summary>
        private static void ShowPressKeyToEndDialog()
        {
            PrintText.ColorizeText("Pressione qualquer tecla para finalizar...", PrintText.TextColor.DarkGray, 0);
            Console.ReadKey();
        }
    }
}