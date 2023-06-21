using System;

namespace Bytebank
{
    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Pressione qualquer tecla para finalizar...");
            Console.ReadKey();
        }

        public static void ExecutarComandos()
        {
        }

        public static void MenuInicial()
        {
            Console.WriteLine("Boas vindas ao Terminal do Bytebank!");

        }

    }

    public static class CorDoTexto
    {
        public static void Amarelo() { Console.ForegroundColor = ConsoleColor.DarkYellow; }
        public static void Azul() { Console.ForegroundColor = ConsoleColor.DarkBlue; }
        public static void Cinza() { Console.ForegroundColor = ConsoleColor.DarkGray; }
        public static void Verde() { Console.ForegroundColor = ConsoleColor.DarkGreen; }
        public static void Vermelho() { Console.ForegroundColor = ConsoleColor.DarkRed; }
    }
}