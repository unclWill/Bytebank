/* Classe  : TextEffects
 * Objetivo: Aplica um caractere, definido pelo desenvolvedor, em torno do texto dando um efeito de destaque.
 * Autor   : unclWill (williamsilvajdf@gmail.com) 
 * Data    : 21/06/2023 (Criação) | Modificação: 22/06/2023
 */

using System;

namespace Bytebank.Utils
{
    internal static class TextEffects
    {
        public static void ApplyTitleEffect(string text, char character)
        {
            int charCount = text.Length;
            string textEffect = string.Empty.PadLeft(charCount, character);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.Yellow, 1);
            PrintText.ColorizeText(text, PrintText.TextColor.DarkGray, 0);
            PrintText.ColorizeText(textEffect, PrintText.TextColor.Yellow, 1);
        }
    }
}