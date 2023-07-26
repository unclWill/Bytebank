/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 26/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Transfer
    {
        internal static void TransferOperation(CheckingAccount clientAccount)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            clientAccount.ShowActualBalance();
            Operation.VerifyBalance('T', clientAccount.Balance);
            //Destino:
            CheckingAccount destination = DefineAccountToTransfer(clientAccount);
            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            decimal valueToTransfer = Operation.ConfirmAction('T');
            clientAccount.Transfer(destination, valueToTransfer);
            Operation.AccountBalanceStatus('T', valueToTransfer, clientAccount.Balance, destination.Balance);
            //
            AuthenticatedScreen.ShowAuthenticatedMenu();
        }

        private static CheckingAccount DefineAccountToTransfer(CheckingAccount clientAccount)
        {
            Operation operation = new Operation();

            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            string transferDestinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
            Operation.SelfDepositOrTransferVerification(transferDestinationAccountId, clientAccount);
            PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
            int transferDestinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
            CheckingAccount destination = operation.DefineAccountToDepositOrTransfer(transferDestinationAccountId, transferDestinationBankBranch);
            return destination;
        }
    }
}