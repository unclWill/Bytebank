/* Classe  : InputVerification
 * Objetivo: Realiza as verificação relacionadas aos dados digitados pelo usuário.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 23/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.StartScreenComponents;

namespace Bytebank.Utils
{
    internal static class InputValidation
    {
        /// <summary>
        /// Valida as entradas do usuário nos menus que são exibidos no sistema.
        /// </summary>
        /// <param name="minOption">Define o número mínimo de opções que o menu contém.</param>
        /// <param name="maxOption">Define o número máximo de opções que o menu contém.</param>
        /// <returns></returns>
        internal static int ValidateMenuOptionInput(int minOption, int maxOption)
        {
            int optionNumber;
            while (!int.TryParse(Console.ReadLine(), out optionNumber) && optionNumber < minOption || optionNumber > maxOption || optionNumber == 0)
            {
                PrintText.ColorizeText("\n[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInputIndicator();
            }
            return optionNumber;
        }
    }
}