using System;

namespace Bytebank.Utils
{
    /* Classe  : TextEffects
     * Objetivo: Aplica um caractere, definido pelo desenvolvedor, em torno do texto dando um efeito de destaque.
     * Autor   : unclWill (williamsilvajdf@gmail.com) 
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */
    readonly internal struct TextEffects
    {
        public static void ApplyEffect(string texto, char caractere)
        {
            int qtdCaracteres = texto.Length;
            string efeito = string.Empty.PadLeft(qtdCaracteres, caractere);
            PrintColoredText.Yellow(efeito, 1);
            PrintColoredText.DarkGray(texto, 1);
            PrintColoredText.Yellow(efeito, 1);
        }
    }
}