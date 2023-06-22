/* Classe  : StartScreenComponents
 * Objetivo: Concentra os métodos personalizados utilizados na tela inicial do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: DD/MM/AAAA
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /// <summary>
    /// Classe <code>StartScreenComponents</code>
    /// Concentra os métodos personalizados utilizados na tela inicial do sistema.
    /// </summary>
    public class StartScreenComponents
    {
        /// <summary>
        /// Exibe os itens que compõe a tela inicial do sistema.
        /// </summary>
        protected internal static void ShowStartScreen()
        {
            Console.Clear();
            ShowApplicationWindowTitle();
            ShowBytebankLogo();
            ShowStartServiceAtTerminalDialog();
        }

        /// <summary>
        /// Exibe o título da janela.
        /// </summary>
        protected internal static void ShowApplicationWindowTitle()
        {
            Console.Title = "Bytebank Terminal";
        }

        /// <summary>
        /// Exibe o logo do Bytebank estilizado com caracteres ASCII.
        /// </summary>
        protected internal static void ShowBytebankLogo()
        {
            DateTime dateTimeNow = DateTime.Now;
            string bytebankLogo = @"
 ______                  _                 _     
(____  \       _        | |               | |    
 ____)  )_   _| |_  ____| | _   ____ ____ | |  _ 
|  __  (| | | |  _)/ _  ) || \ / _  |  _ \| | / )
| |__)  ) |_| | |_( (/ /| |_) | ( | | | | | |< ( 
|______/ \__  |\___)____)____/ \_||_|_| |_|_| \_)
        (____/";
            PrintText.ColorizeText(bytebankLogo, PrintText.TextColor.Green, 0);
            Console.Write("\n\n");
            Console.Write("  Boas vindas ao Terminal do Bytebank!\n");
            Console.Write($"  Acesso em: {dateTimeNow}\n\n");
        }

        /// <summary>
        /// Exibe o diálogo responsável por Iniciar o atendimento ou finalizar o terminal.
        /// </summary>
        protected internal static void ShowStartServiceAtTerminalDialog()
        {
            PrintText.HighlightTitleText(" Digite |1| para iniciar o seu atendimento", '-');
            PrintText.ColorizeText("\n|1| ENTRAR NA MINHA CONTA  ", PrintText.TextColor.Green, 0);
            PrintText.ColorizeText("|2| ENCERRAR TERMINAL\n", PrintText.TextColor.DarkGreen, 1);
            int selectedOption;
            //Lê e valida o campo operacaoSelecionada, SE NÃO for um valor inteiro entra no loop, exibe um erro e aguarda uma entrada válida.
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
                //Controla o acesso do usuário ao sistema.
            }
            else if (selectedOption == 2)
            {
                Console.Write("[>] Liberando terminal");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(420);
                    PrintText.ColorizeText(".", PrintText.TextColor.DarkYellow, 0);
                }
                Console.Write("\n\n[>] Terminal liberado! Obrigado por utlilizar o Bytebank.\n\n");
                ShowPressKeyToEndDialog();
            }
        }

        /// <summary>
        /// Exibe o diálogo responsável por finalizar a execução do sistema.
        /// </summary>
        protected internal static void ShowPressKeyToEndDialog()
        {
            PrintText.ColorizeText("Pressione qualquer tecla para finalizar...", PrintText.TextColor.DarkGray, 0);
            Console.ReadKey();
        }
    }
}