
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Operation
    {
        internal static void ConfirmAction(decimal value, string operationContext = "[!] Operação cancelada.")
        {
            int confirmation;
            PrintText.DecoratedTitleText(" Confirmar operação? ", '-', PrintText.TextColor.DarkRed);
            PrintText.ColorizeText("|0| NÃO  -  |1| SIM\n[>] ", PrintText.TextColor.White, 0);
            while (!int.TryParse(Console.ReadLine(), out confirmation))
            {
                PrintText.ColorizeText("[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInteractionIndicator();
            }

            if (confirmation == 0)
            {
                value = 0m;
                PrintText.ColorizeText(operationContext, PrintText.TextColor.Red);
                return;
            }
        }

        internal static void ActualBalance(decimal balance)
        {
            PrintText.ColorizeText($"Seu saldo atual: {balance:C}", PrintText.TextColor.DarkGray);
        }
    }
}