/* Classe  : Deposit
 * Objetivo: Concentrar as operações de depósito na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Deposit
    {
        private static decimal _valueToDeposit;
        internal static decimal DepositOperation(CheckingAccount account)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[+$] DEPÓSITO ", '*', PrintText.TextColor.DarkGreen);
            Operation.ActualBalance(account.Balance);
            PrintText.ColorizeText("Digite o valor que será depositado: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            _valueToDeposit = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            ConfirmAction();
            account.Deposit(_valueToDeposit);
            //
            if (_valueToDeposit == 0)
            {
                Console.WriteLine("[i] Nenhum valor foi depositado.");
            }
            else
            {
                PrintText.ColorizeText($"Valor adicionado à conta!\nValor atualizado: {account.Balance:C}", PrintText.TextColor.DarkGreen);
            }

            PrintTextAnimations.TreeDotsAnimation(1000);
            return _valueToDeposit;
        }

        private static void ConfirmAction()
        {

        }
    }
}