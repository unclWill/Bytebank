/* Classe  : Operation
 * Objetivo: Concentrar os métodos comuns a todas as operações.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 23/07/2023
 */

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
            PrintText.ColorizeText("|0| NÃO  -  |1| SIM", PrintText.TextColor.Red, 2);
            PrintText.UserInputIndicator();

            while (!int.TryParse(Console.ReadLine(), out confirmation) || confirmation < 0 || confirmation > 1)
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

        internal static void VerifyBalance(char operationType, decimal balance)
        {
            switch (operationType)
            {
                case 'W':
                    if (balance <= 0)
                    {
                        PrintText.ColorizeText("[!] Você não possui saldo disponível para realizar saques!", PrintText.TextColor.DarkYellow);
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1500);
                    }
                    break;
                case 'T':
                    if (balance <= 0)
                    {
                        PrintText.ColorizeText("[!] Você não possui saldo disponível para realizar transferências!", PrintText.TextColor.DarkYellow);
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1500);
                    }
                    break;
            }
        }

        internal static void AccountBalanceStatus(char operationType, decimal transactionValue, decimal balance, decimal accountToTransferBalance = 0m)
        {
            switch (operationType)
            {
                case 'D':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi depositado.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor adicionado à conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'W':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi sacado.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor sacado da da conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'T':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi transferido.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"Valor transferido da conta!\nValor atualizado: {balance:C}\nValor na conta recebedora: {accountToTransferBalance:C}", PrintText.TextColor.DarkYellow);
                    }
                    break;
            }
            PrintTextAnimations.TreeDotsAnimation(1000);
        }
    }
}