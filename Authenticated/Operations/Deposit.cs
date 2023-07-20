/* Classe  : Deposit
 * Objetivo: Concentrar as operações de depósito na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using System.Runtime.CompilerServices;
using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Deposit
    {
        private static decimal _valueToDeposit;

        internal static void DepositOperation(CheckingAccount account)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[+$] DEPÓSITO ", '*', PrintText.TextColor.DarkGreen, 0);
            Operation.ActualBalance(account.Balance);
            PrintText.ColorizeText("Digite o valor que será depositado: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            decimal valueToDeposit = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            _valueToDeposit = Operation.ConfirmAction(valueToDeposit);
            account.Deposit(_valueToDeposit);
            //
            Operation.AccountBalanceStatus('D', _valueToDeposit, account.Balance);
            PrintTextAnimations.TreeDotsAnimation(1000);
            //return valueToDeposit;
        }
    }
}