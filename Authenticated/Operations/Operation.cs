
using System.Collections;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Operation
    {
        internal static decimal ConfirmAction(decimal value)
        {
            decimal transactionValue = 0m;
            int confirmation;
            PrintText.DecoratedTitleText(" Confirmar operação? ", '-', PrintText.TextColor.DarkRed, 0);
            PrintText.ColorizeText("|0| NÃO  -  |1| SIM\n[>] ", PrintText.TextColor.White, 0);
            while (!int.TryParse(Console.ReadLine(), out confirmation))
            {
                PrintText.ColorizeText("[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInputIndicator();
            }

            switch (confirmation)
            {
                case 0:
                    transactionValue = 0m;
                    PrintText.ColorizeText("[i] Operação cancelada.", PrintText.TextColor.Red);
                    break;
                case 1:
                    transactionValue = value;
                    break;
            }
            return transactionValue;
        }

        internal static void ActualBalance(decimal balance)
        {
            PrintText.DecoratedTitleText($"Seu saldo atual: {balance:C}", '-', PrintText.TextColor.DarkGray);
        }

        internal static void AccountBalanceStatus(char operationType, decimal transactionValue, decimal balance, decimal accountToTransferBalance = 0m)
        {
            switch (operationType)
            {
                case 'D':
                    if (transactionValue == 0m)
                    {
                        Console.WriteLine("[i] Nenhum valor foi depositado.");
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor adicionado à conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'W':
                    if (transactionValue == 0m)
                    {
                        Console.WriteLine("[i] Nenhum valor foi sacado.");
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor sacado da da conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'T':
                    if (transactionValue == 0m)
                    {
                        Console.WriteLine("[i] Nenhum valor foi transferido.");
                    }
                    else
                    {
                        PrintText.ColorizeText($"Valor transferido da conta!\nValor atualizado: {balance:C} | Valor na conta recebedora: {accountToTransferBalance:C}", PrintText.TextColor.DarkYellow);
                    }
                    break;
            }
            PrintTextAnimations.TreeDotsAnimation(1000);
        }
    }
}