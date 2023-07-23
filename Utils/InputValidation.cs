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
        /// <param name="qtyOfOptions">Define a quantidade de opções que o menu exibe ao usuário. Deve ser passado para controlar de execução.</param>
        /// <returns></returns>
        internal static int ValidateMenuOptionInput(int qtyOfOptions)
        {
            int optionNumber;
            while (!int.TryParse(Console.ReadLine(), out optionNumber) && optionNumber < 0 || optionNumber > qtyOfOptions)
            {
                PrintText.ColorizeText("\n[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInputIndicator();
            }
            return optionNumber;
        }
    }
}