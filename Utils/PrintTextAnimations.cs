/* Classe  : PrintTextAnimations
 * Objetivo: Imprime textos que sugerem animação e mudança de estado.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 26/06/2023 (Criação) | Modificação: 26/06/2023
 */

using System;

namespace Bytebank.Utils
{
    internal class PrintTextAnimations : PrintText
    {
        /// <summary>
        /// Método <code>TreeDotsAnimationText</code>
        /// Insere três pontos que vão sendo adicionados após um determinado texto, dando a impressão de que algo está sendo processado.
        /// </summary>
        internal static void TreeDotsAnimation(int timer = 450)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(timer);
                ColorizeText(".", TextColor.DarkYellow, 0);
            }
        }

        internal static void AcessingSystemAnimation(string? text, int timer = 450)
        {
            ColorizeText($"\n[i] {text}", TextColor.DarkGray, 0);
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(timer);
                ColorizeText(".", TextColor.DarkYellow, 0);
            }
        }

        internal static void PercentageOfProgressAnimation(int percentage = 101, int progressRate = 10, int timer = 500)
        {
            for (int i = 0; i < percentage; i += progressRate)
            {
                Thread.Sleep(timer);
                ColorizeText($" {i}%", TextColor.Gray, 0);
                ColorizeText(" Concluído.", TextColor.DarkYellow, 0);
            }
        }
    }
}