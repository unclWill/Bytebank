using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /* Classe  : ImprimirTextoColorido
     * Objetivo: Aplica cores nos textos impressos no console.
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */
    internal static class ImprimirTextoColorido
    {
        public static void Amarelo(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkYellow); //Aplica na string texto.
            Console.ForegroundColor = ConsoleColor.Gray;                                 //Reseta o console para a cor cinza.
        }
        public static void Azul(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkBlue);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Branco(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Cinza(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkGray);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Verde(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Vermelho(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}