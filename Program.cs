using System;
using Bytebank.Utils;

/* Classe  : Program
 * Objetivo: Ponto de entrada do prograna.
 * Data    : 21/06/2023 (Criação) | última edição: MM/DD/AAAA
 */

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {
            ExibirLogo();

            ImprimirTextoColorido.Vermelho("Pressione qualquer tecla para finalizar...");
            Console.ReadKey();
        }

        public static void ExecutarComandos()
        {

        }

        public static void ExibirLogo()
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
            ImprimirTextoColorido.Verde(bytebankLogo); //Exibe o 'logo' do Bytebank em ASCII Art
            Console.Write("\n\n");
            Console.Write("            Boas vindas ao Terminal do Bytebank!\n");
            Console.Write($"              Acesso em: {dataHoraAtual}\n\n");
        }

        public static void ExibirMenuInicial()
        {

        }

    }
}