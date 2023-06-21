using System;
using Bytebank.Utils;

/* Classe  : Program
 * Objetivo: Ponto de entrada do programa.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | última edição: MM/DD/AAAA
 */

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            ShowBytebankLogo();

            PrintColorText.Red("Pressione qualquer tecla para finalizar...");
            Console.ReadKey();
        }

        public static void ShowBytebankLogo()
        {
            DateTime dataHoraAtual = DateTime.Now;
            string bytebankLogo = @"
       ______                  _                 _     
      (____  \       _        | |               | |    
       ____)  )_   _| |_  ____| | _   ____ ____ | |  _ 
      |  __  (| | | |  _)/ _  ) || \ / _  |  _ \| | / )
      | |__)  ) |_| | |_( (/ /| |_) | ( | | | | | |< ( 
      |______/ \__  |\___)____)____/ \_||_|_| |_|_| \_)
              (____/";
            PrintColorText.Green(bytebankLogo);
            Console.Write("\n\n");
            Console.Write("            Boas vindas ao Terminal do Bytebank!\n");
            PrintColorText.White($"              Acesso em: {dataHoraAtual}\n\n");
        }

        public static void ShowMainMenu()
        {

        }

        public static void ExecuteCommands()
        {

        }

    }
}