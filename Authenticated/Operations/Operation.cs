/* Classe  : Operation
 * Objetivo: Concentrar os métodos comuns a todas as operações.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 26/07/2023
 */

using System.Collections;
using Bytebank.AccountManagement;
using Bytebank.HARDCODED_DATABASE;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Operation
    {
        internal static decimal ConfirmAction(char operationType)
        {
            decimal transactionValue = 0m;

            switch (operationType)
            {
                case 'D':
                    PrintText.ColorizeText("\nDigite o valor que deseja depositar", PrintText.TextColor.White);
                    break;
                case 'T':
                    PrintText.ColorizeText("\nDigite o valor que deseja transferir", PrintText.TextColor.White);
                    break;
                case 'W':
                    PrintText.ColorizeText("\nDigite o valor que deseja sacar", PrintText.TextColor.White);
                    break;
            }
            PrintText.UserInputIndicator();
            //---
            decimal valueToTransfer;
            while (!decimal.TryParse(Console.ReadLine()!.Replace('.', ','), out valueToTransfer))
            {
                PrintText.ColorizeText("[!] Por favor, digite corretamente o valor que deseja movimentar", PrintText.TextColor.Red);
                PrintText.UserInputIndicator();
            }
            //---
            PrintText.DecoratedTitleText(" Confirmar operação? ", '-', PrintText.TextColor.DarkRed, 0);
            PrintText.ColorizeText("|0| NÃO  -  |1| SIM", PrintText.TextColor.Red, 2);
            PrintText.UserInputIndicator();
            int confirmation = InputValidation.ValidateMenuOptionInput(0, 1);
            switch (confirmation)
            {
                case 0:
                    transactionValue = 0m;
                    PrintText.ColorizeText("[i] Operação cancelada.", PrintText.TextColor.Red);
                    break;
                case 1:
                    transactionValue = valueToTransfer;
                    break;
            }
            return transactionValue;
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

        internal static void SelfDepositOrTransferVerification(string destination, CheckingAccount clientAccount)
        {
            if (destination == clientAccount.AccountId)
            {
                PrintText.ColorizeText("[!] Não são permitidas movimentações onde a origem e o destino são os mesmos.", PrintText.TextColor.Red);
                AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(2000);
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

        internal static CheckingAccount DefineAccountToDepositOrTransfer(string accountId, int bankBranch)
        {
            RegisteredCheckingAccounts registeredCheckingAccounts = new RegisteredCheckingAccounts();
            var clientsAccountList = registeredCheckingAccounts.CheckingAccounts;
            CheckingAccount destinationAccount = new CheckingAccount();

            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.AccountId is not null && client.AccountId.Equals(accountId) && client.BankBranch == bankBranch)
                    {
                        destinationAccount = client;
                    }
                }
                if (accountId != destinationAccount.AccountId)
                {
                    PrintText.ColorizeText("[!] A conta informada não existe ou foi digitada incorretamente!", PrintText.TextColor.Red);
                    AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1300);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            return destinationAccount;
        }
    }
}