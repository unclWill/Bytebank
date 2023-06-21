using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.Utils
{
    /* Classe  : InserirEfeitoNoTexto
     * Objetivo: Aplica um caractere, definido pelo desenvolvedor, em torno do texto dando um efeito de destaque.
     * Data    : 21/06/2023 (Criação) | Modificação: DD/MM/AAAA
     */
    internal static class InserirEfeitoNoTexto
    {
        public static void Efeito(string texto, char caractere)
        {
            int qtdCaracteres = texto.Length;
            string efeito = string.Empty.PadLeft(qtdCaracteres, caractere);
            ImprimirTextoColorido.Amarelo(efeito);
            ImprimirTextoColorido.Cinza(texto);
            ImprimirTextoColorido.Amarelo(efeito);
        }
    }
}