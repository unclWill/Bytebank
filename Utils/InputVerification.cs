/* Classe  : InputVerification
 * Objetivo: Realiza as verificação relacionadas aos dados digitados pelo usuário.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 20/07/2023
 */

namespace Bytebank.Utils
{
    internal static class InputVerification
    {
        internal static int VerifyMenuOptionInput()
        {
            int optionNumber;
            while (!int.TryParse(Console.ReadLine(), out optionNumber))
            {
                PrintText.ColorizeText("\n[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInteractionIndicator();
            }
            return optionNumber;
        }
    }
}