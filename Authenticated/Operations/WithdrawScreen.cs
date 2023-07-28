/* Classe  : WithdrawScreen
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 28/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    /// <summary>
    /// Exibe a tela da operação de Saque.
    /// </summary>
    internal class WithdrawScreen
    {
        /// <summary>
        /// Exibe os diálogos responsáveis por capturar a entrada dos dados fornecidos pelo cliente para a realização da operação de Saque.
        /// </summary>
        /// <param name="clientAccount">Recebe a conta do cliente autenticado no sistema.</param>
        internal static void WithdrawOperation(CheckingAccount clientAccount)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[-$] SAQUE ", '*', PrintText.TextColor.DarkYellow);
            clientAccount.ShowActualBalance();
            Operation.VerifyBalance('W', clientAccount.Balance);
            decimal valueToWithdraw = Operation.InsertValueAndConfirmOperation('W');
            clientAccount.Withdraw(valueToWithdraw);
            Operation.AccountBalanceStatus('W', valueToWithdraw, clientAccount.Balance);
            //
            AuthenticatedScreen.ShowAuthenticatedMenu();
        }
    }
}