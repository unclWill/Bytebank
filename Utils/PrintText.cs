/* Classe  : PrintText
 * Objetivo: Imprime textos na tela. Contém métodos que permitem imprimir textos de forma personalizada utilizando a classe System.Console.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | Modificação: 22/06/2023
 */

using System;

namespace Bytebank.Utils
{
    /// <summary>
    /// Classe <c>PrintText</c>, contém os métodos que definem a cor do texto.
    /// Exemplo de uso: PrintText.ColorizeText("String", PrintText.TextColor.Color, 1);
    /// </summary>
    internal class PrintText
    {
        #region ColorizeText -- definições responsáveis por definir a cor do texto.
        public enum TextColor
        {
            Blue,
            DarkGray,
            Gray,
            Green,
            Red,
            White,
            Yellow
        }
        private static void SetTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        private static void ResetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Método <c>ColorizeText</c>, define a cor do texto e a forma como este texto será impresso na tela.
        /// <example>Exemplo de uso: PrintText.ColorizeText("String", PrintText.TextColor.Color, 1);</example>
        /// ---[i] O argumento 1 indica que o texto será impresso utilizando Console.WriteLine (com quebra de linha)
        /// --- [i] O argumento 0 indica que o texto será impresso utilizando Console.Write (sem quebra de linha).
        /// </summary>
        /// <param name="text">String quew será manipulada e impresso.</param>
        /// <param name="color">Cor na qual o texto será impresso.</param>
        /// <param name="lineBreak">Indica se o texto será impresso com ou sem quebra de linha.</param>
        protected internal static void ColorizeText(string? text, TextColor color, sbyte lineBreak)
        {
            switch (color)
            {
                case TextColor.Blue:
                    SetTextColor(ConsoleColor.Blue);
                    break;
                case TextColor.DarkGray:
                    SetTextColor(ConsoleColor.DarkGray);
                    break;
                case TextColor.Gray:
                    SetTextColor(ConsoleColor.Gray);
                    break;
                case TextColor.Green:
                    SetTextColor(ConsoleColor.Green);
                    break;
                case TextColor.Red:
                    SetTextColor(ConsoleColor.Red);
                    break;
                case TextColor.White:
                    SetTextColor(ConsoleColor.White);
                    break;
                case TextColor.Yellow:
                    SetTextColor(ConsoleColor.Yellow);
                    break;
                default:
                    ResetTextColor();
                    return;
            }

            if (lineBreak == 1)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }

            ResetTextColor();
        }
        #endregion
        protected internal static void HighlightTitleText(string text, char character)
        {
            int charCount = text.Length;
            string textEffect = string.Empty.PadLeft(charCount, character);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.Yellow, 1);
            PrintText.ColorizeText(text, PrintText.TextColor.DarkGray, 0);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.Yellow, 1);
        }
    }
}