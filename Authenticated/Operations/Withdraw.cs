/* Classe  : Withdraw
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Withdraw
    {
        private static decimal _valueToWithdraw;

        internal static void WithdrawOperation(CheckingAccount account)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[-$] SAQUE ", '*', PrintText.TextColor.DarkYellow);
            Operation.ActualBalance(account.Balance);
            PrintText.ColorizeText("Digite o valor que deseja sacar: ", PrintText.TextColor.White);
            PrintText.UserInputIndicator();
            decimal valueToWithdraw = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            _valueToWithdraw = Operation.ConfirmAction(valueToWithdraw);
            account.Withdraw(_valueToWithdraw);
            Operation.AccountBalanceStatus('W', _valueToWithdraw, account.Balance);
            //return valueToWithdraw;
        }
    }
}