/* Classe  : PrintText
 * Objetivo: Imprime textos na tela. Contém métodos que permitem imprimir textos de forma personalizada utilizando a classe System.Console.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | Modificação: 22/06/2023
 */

using System;

namespace Bytebank.Utils
{
    /// <summary>
    /// Classe <code>PrintText</code>
    /// Contém métodos que permitem imprimir textos de forma personalizada.
    /// </summary>
    internal class PrintText
    {
        #region ColorizeText -- definições responsáveis por definir a cor do texto.
        public enum TextColor
        {
            Black,
            Blue,
            DarkBlue,
            DarkCyan,
            DarkGray,
            DarkGreen,
            DarkMagenta,
            DarkRed,
            DarkYellow,
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
        /// Método <code>ColorizeText</code> 
        /// Define a cor do texto e a forma como este texto será impresso na tela.
        /// <example>Exemplo de uso: PrintText.ColorizeText("String", PrintText.TextColor.Color, 1);</example>
        /// <code>O parêmetro 1 indica que o texto será impresso utilizando Console.WriteLine (com quebra de linha)</code>
        /// <code>O parâmetro 0 indica que o texto será impresso utilizando Console.Write (sem quebra de linha).</code>
        /// </summary>
        /// <param name="text">String quew será manipulada e impresso.</param>
        /// <param name="color">Cor na qual o texto será impresso.</param>
        /// <param name="lineBreak">Indica se o texto será impresso com ou sem quebra de linha.</param>
        protected internal static void ColorizeText(string? text, TextColor color, sbyte lineBreak)
        {
            switch (color)
            {
                case TextColor.Black:
                    SetTextColor(ConsoleColor.Black);
                    break;
                case TextColor.Blue:
                    SetTextColor(ConsoleColor.Blue);
                    break;
                case TextColor.DarkBlue:
                    SetTextColor(ConsoleColor.DarkBlue);
                    break;
                case TextColor.DarkCyan:
                    SetTextColor(ConsoleColor.DarkCyan);
                    break;
                case TextColor.DarkGray:
                    SetTextColor(ConsoleColor.DarkGray);
                    break;
                case TextColor.DarkGreen:
                    SetTextColor(ConsoleColor.DarkGreen);
                    break;
                case TextColor.DarkMagenta:
                    SetTextColor(ConsoleColor.DarkMagenta);
                    break;
                case TextColor.DarkRed:
                    SetTextColor(ConsoleColor.DarkRed);
                    break;
                case TextColor.DarkYellow:
                    SetTextColor(ConsoleColor.DarkYellow);
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

        /// <summary>
        /// Método <code>DecorateTitleText</code>
        /// Insere uma decoração em volta do texto que é passado como um argumento do tipo char.
        /// </summary>
        /// <param name="text">String que será exibida.</param>
        /// <param name="character">Caractere que será utilizado para criar a decoração entorno do texto.</param>
        protected internal static void DecorateTitleText(string text, char character)
        {
            int charCount = text.Length;
            string textEffect = string.Empty.PadLeft(charCount, character);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.DarkGray, 1);
            PrintText.ColorizeText(text, PrintText.TextColor.White, 1);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.DarkGray, 1);
        }

        /// <summary>
        /// Método <code>TreeDotsAnimationText</code>
        /// Insere três pontos que vão sendo adicionados após um determinado texto, dando a impressão de que algo está sendio processado.
        /// </summary>
        protected internal static void TreeDotsAnimationText()
        {
            const int millissecondsTimer = 420;
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(millissecondsTimer);
                PrintText.ColorizeText(".", PrintText.TextColor.DarkYellow, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal static void UserInteractionIndicator()
        {
            PrintText.ColorizeText("[>] ", PrintText.TextColor.DarkGray, 0);
        }
    }
}