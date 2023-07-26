/* Classe  : Deposit
 * Objetivo: Concentrar as operações de depósito na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 26/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Deposit
    {
        internal void DepositOperation(CheckingAccount clientAccount)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[+$] DEPÓSITO ", '*', PrintText.TextColor.DarkGreen, 0);
            Operation.ActualBalance(clientAccount.Balance);
            //---
            Deposit deposit = new Deposit();
            CheckingAccount destination = deposit.DefineAccountToDeposit(clientAccount);
            //---
            decimal valueToDeposit = Operation.ConfirmAction('D');
            //
            clientAccount.Deposit(destination, valueToDeposit);
            //
            Operation.AccountBalanceStatus('D', valueToDeposit, clientAccount.Balance);
        }

        private CheckingAccount DefineAccountToDeposit(CheckingAccount clientAccount)
        {
            CheckingAccount? destination = null;
            Operation operation = new Operation();

            PrintText.DecoratedTitleText(" ONDE DESEJA REALIZAR O DEPÓSITO? ", '-');
            PrintText.ColorizeText("|1| NA MINHA CONTA\n|2| NA CONTA DE UM TERCEIRO", PrintText.TextColor.Gray);
            PrintText.UserInputIndicator();

            int menuOption = InputValidation.ValidateMenuOptionInput(1, 2);
            if (menuOption == 1)
            {
                destination = operation.DefineAccountToDepositOrTransfer(clientAccount.AccountId!, clientAccount.BankBranch);
            }
            else if (menuOption == 2)
            {
                PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
                string destinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
                PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
                int destinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
                destination = operation.DefineAccountToDepositOrTransfer(destinationAccountId, destinationBankBranch);
            }
            return destination!;
        }
    }
}