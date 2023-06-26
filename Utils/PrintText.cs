/* Classe  : PrintText
 * Objetivo: Imprime textos na tela. Contém métodos que permitem imprimir textos de forma personalizada utilizando a classe System.Console.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 21/06/2023 (Criação) | Modificação: 26/06/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /// <summary>
    /// Classe <code>PrintText</code>
    /// Contém métodos que permitem imprimir textos de forma personalizada.
    /// </summary>
    internal class PrintText
    {
        #region ColorizeText -- definições responsáveis por definir a cor do texto.
        internal enum TextColor
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
            ConsoleColor consoleColor = ConsoleColor.Gray; // cor padrão, caso não seja reconhecida

            switch (color)
            {
                case (ConsoleColor)TextColor.Black:
                    consoleColor = ConsoleColor.Black;
                    break;
                case (ConsoleColor)TextColor.Blue:
                    consoleColor = ConsoleColor.Blue;
                    break;
                case (ConsoleColor)TextColor.DarkBlue:
                    consoleColor = ConsoleColor.DarkBlue;
                    break;
                case (ConsoleColor)TextColor.DarkCyan:
                    consoleColor = ConsoleColor.DarkCyan;
                    break;
                case (ConsoleColor)TextColor.DarkGray:
                    consoleColor = ConsoleColor.DarkGray;
                    break;
                case (ConsoleColor)TextColor.DarkGreen:
                    consoleColor = ConsoleColor.DarkGreen;
                    break;
                case (ConsoleColor)TextColor.DarkMagenta:
                    consoleColor = ConsoleColor.DarkMagenta;
                    break;
                case (ConsoleColor)TextColor.DarkRed:
                    consoleColor = ConsoleColor.DarkRed;
                    break;
                case (ConsoleColor)TextColor.DarkYellow:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;
                case (ConsoleColor)TextColor.Gray:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case (ConsoleColor)TextColor.Green:
                    consoleColor = ConsoleColor.Green;
                    break;
                case (ConsoleColor)TextColor.Red:
                    consoleColor = ConsoleColor.Red;
                    break;
                case (ConsoleColor)TextColor.White:
                    consoleColor = ConsoleColor.White;
                    break;
                case (ConsoleColor)TextColor.Yellow:
                    consoleColor = ConsoleColor.Yellow;
                    break;
            }

            Console.ForegroundColor = consoleColor;
        }
        private static void ResetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void SetLineBreak(sbyte lineBreak)
        {
            for (int i = 0; i < lineBreak; i++)
            {
                Console.WriteLine();
            }
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
        /// <param name="lineBreak">Indica se e quantas vezes o texto sofrerá quebras de linhas. 0 = sem quebra de linha.</param>
        internal static void ColorizeText(string? text1, TextColor color1, string? text2, TextColor color2, string? text3, TextColor color3, string? text4, TextColor color4, string? text5, TextColor color5, sbyte lineBreak)
        {
            // Definir a cor do texto 1
            SetTextColor((ConsoleColor)color1);
            Console.Write(text1);
            SetTextColor((ConsoleColor)color2);
            Console.Write(text2);
            SetTextColor((ConsoleColor)color3);
            Console.Write(text3);
            SetTextColor((ConsoleColor)color4);
            Console.Write(text4);
            SetTextColor((ConsoleColor)color5);
            Console.Write(text5);
            // Realizar quebra de linha, determinada pelo valor que o programador define na declaração do método.
            SetLineBreak(lineBreak);
        }
        internal static void ColorizeText(string? text1, TextColor color1, string? text2, TextColor color2, string? text3, TextColor color3, string? text4, TextColor color4, sbyte lineBreak)
        {
            SetTextColor((ConsoleColor)color1);
            Console.Write(text1);
            SetTextColor((ConsoleColor)color2);
            Console.Write(text2);
            SetTextColor((ConsoleColor)color3);
            Console.Write(text3);
            SetTextColor((ConsoleColor)color4);
            Console.Write(text4);
            SetLineBreak(lineBreak);
        }
        internal static void ColorizeText(string? text1, TextColor color1, string? text2, TextColor color2, string? text3, TextColor color3, sbyte lineBreak)
        {
            SetTextColor((ConsoleColor)color1);
            Console.Write(text1);
            SetTextColor((ConsoleColor)color2);
            Console.Write(text2);
            SetTextColor((ConsoleColor)color3);
            Console.Write(text3);
            SetLineBreak(lineBreak);
        }
        internal static void ColorizeText(string? text1, TextColor color1, string? text2, TextColor color2, sbyte lineBreak)
        {
            SetTextColor((ConsoleColor)color1);
            Console.Write(text1);
            SetTextColor((ConsoleColor)color2);
            Console.Write(text2);
            SetLineBreak(lineBreak);
        }
        internal static void ColorizeText(string? text, TextColor color, sbyte lineBreak)
        {
            SetTextColor((ConsoleColor)color);
            Console.Write(text);
            SetLineBreak(lineBreak);
            ResetTextColor(); //Define a cor padrão do terminal para Cinza, caso o método ColorizeText não esteja sendo utilizado.
        }
        #endregion

        /// <summary>
        /// Método <code>DecorateTitleText</code>
        /// Insere uma decoração em volta do texto que é passado como um argumento do tipo char.
        /// </summary>
        /// <param name="text">String que será exibida.</param>
        /// <param name="character">Caractere que será utilizado para criar a decoração entorno do texto.</param>
        internal static void DecorateTitleText(string text, char character)
        {
            int charCount = text.Length;
            string textEffect = string.Empty.PadLeft(charCount, character);
            ColorizeText(textEffect, TextColor.DarkGray, 1);
            ColorizeText(text, TextColor.White, 1);
            ColorizeText(textEffect, TextColor.DarkGray, 1);
        }

        /// <summary>
        /// Método <code>TreeDotsAnimationText</code>
        /// Insere três pontos que vão sendo adicionados após um determinado texto, dando a impressão de que algo está sendo processado.
        /// </summary>
        internal static void TreeDotsAnimationText()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(450);
                ColorizeText(".", TextColor.DarkYellow, 0);
            }
        }

        internal static void AcessingSystemAnimationText(string? text)
        {
            ColorizeText($"\n[i] {text}", TextColor.DarkGray, 0);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(450);
                ColorizeText(".", TextColor.DarkYellow, 0);
            }
        }

        /// <summary>
        /// Método <code>UserInteractionIndicator</code>
        /// Exibe os caracteres [>] indicando que o espaço a seguir é destinado à inserção de dados pelo usuário.
        /// </summary>
        internal static void UserInteractionIndicator()
        {
            ColorizeText("[>] ", TextColor.DarkGray, 0);
        }

        internal static void LineBreak()
        {
            Console.WriteLine();
        }
    }
}