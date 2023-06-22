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
    public class StartScreenComponents
    {
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
            Console.Write("            Boas vindas ao Terminal do Bytebank!\n");
            PrintText.ColorizeText($"              Acesso em: {dateTimeNow}\n\n", PrintText.TextColor.White, 0);
        }

        /// <summary>
        /// Exibe o menu da tela inicial.
        /// </summary>
        protected internal static void ShowMainMenu()
        {

        }

        /// <summary>
        /// Exibe o diálogo "Pressione qualquer tecla para finalizar".
        /// </summary>
        protected internal static void ShowPressKeyToEndDialog()
        {
            PrintText.ColorizeText("Pressione qualquer tecla para finalizar...", PrintText.TextColor.DarkGray, 0);
            Console.ReadKey();
        }
    }
}