/* Classe  : Withdraw
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 27/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Withdraw
    {
        internal static void WithdrawOperation(CheckingAccount clientAccount)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[-$] SAQUE ", '*', PrintText.TextColor.DarkYellow);
            clientAccount.ShowActualBalance();
            Operation.VerifyBalance('W', clientAccount.Balance);
            decimal valueToWithdraw = Operation.ConfirmAction('W');
            clientAccount.Withdraw(valueToWithdraw);
            Operation.AccountBalanceStatus('W', valueToWithdraw, clientAccount.Balance);
            //
            AuthenticatedScreen.ShowAuthenticatedMenu();
        }
    }
}