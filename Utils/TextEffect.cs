using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /* Classe  : TextEffect
     * Objetivo: Aplica um caractere, definido pelo desenvolvedor, em torno do texto dando um efeito de destaque.
     * Autor   : unclWill (williamsilvajdf@gmail.com) 
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */
    internal static class TextEffect
    {
        public static void ApplyEffect(string texto, char caractere)
        {
            int qtdCaracteres = texto.Length;
            string efeito = string.Empty.PadLeft(qtdCaracteres, caractere);
            PrintColorText.Yellow(efeito);
            PrintColorText.DarkGray(texto);
            PrintColorText.Yellow(efeito);
        }
    }
}