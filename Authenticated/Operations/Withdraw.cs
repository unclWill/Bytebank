/* Classe  : Withdraw
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 23/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Withdraw
    {
        private static decimal _valueToWithdraw;

        internal void WithdrawOperation(CheckingAccount account)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[-$] SAQUE ", '*', PrintText.TextColor.DarkYellow);
            Operation.ActualBalance(account.Balance);
            Operation.VerifyBalance('W', account.Balance);
            _valueToWithdraw = Operation.ConfirmAction('W');
            account.Withdraw(_valueToWithdraw);
            Operation.AccountBalanceStatus('W', _valueToWithdraw, account.Balance);
            //return valueToWithdraw;
        }
    }
}