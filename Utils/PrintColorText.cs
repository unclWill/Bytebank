using System;

namespace Bytebank.Utils
{
    /* Classe  : PrintColorText
     * Objetivo: Aplica cores nos textos impressos no console.
     * Autor   : unclWill (williamsilvajdf@gmail.com)
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */

    /// <summary>
    /// Struct PrintColorText, contém os métodos que definem a cor do texto.
    /// Exemplo de uso: PrintColorText.Azul();
    /// </summary>
    readonly internal struct PrintColorText
    {
        /// <summary>
        /// Método Yellow. Define a cor do texto como Amarelo.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lineBreak"></param>
        public static void Yellow(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        public static void Blue(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.DarkBlue);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.DarkBlue);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        public static void White(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.White);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.White);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        public static void Gray(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.Gray);
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.Gray);
                    break;
            }
        }
        public static void DarkGray(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        public static void Green(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.DarkGreen);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.DarkGreen);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        public static void Red(string text, sbyte lineBreak)
        {
            switch (lineBreak)
            {
                case 1:
                    Console.WriteLine(text, Console.ForegroundColor = ConsoleColor.DarkRed);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.Write(text, Console.ForegroundColor = ConsoleColor.DarkRed);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
    }
}