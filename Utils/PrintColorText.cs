using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /* Classe  : PrintColorText
     * Objetivo: Aplica cores nos textos impressos no console.
     * Autor   : unclWill (williamsilvajdf@gmail.com)
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */
    internal static class PrintColorText
    {
        public static void Yellow(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkYellow); //Aplica a cor na string texto.
            Console.ForegroundColor = ConsoleColor.Gray;                                 //Reseta o console para a cor cinza (padrão).
        }
        public static void Blue(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkBlue);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void White(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Gray(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.Gray);
        }
        public static void DarkGray(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkGray);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Green(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Red(string texto)
        {
            Console.WriteLine(texto, Console.ForegroundColor = ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}