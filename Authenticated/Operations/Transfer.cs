/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 23/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Transfer
    {
        private static decimal _valueToTransfer = 0m;

        internal decimal TransferOperation(CheckingAccount account)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            Operation.ActualBalance(account.Balance);
            Operation.VerifyBalance('T', account.Balance);
            //Destino:
            CheckingAccount destination = DefineAccountToTransfer(account);
            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            _valueToTransfer = Operation.ConfirmAction('T');
            account.Transfer(destination, _valueToTransfer);
            Operation.AccountBalanceStatus('T', _valueToTransfer, account.Balance, destination.Balance);
            return _valueToTransfer;
        }

        private void SelfTransferVerificator(string destination, CheckingAccount myAccount)
        {
            if (destination == myAccount.AccountId)
            {
                PrintText.ColorizeText("[!] Não são permitidas transferências onde a origem e o destino são os mesmos,\n" +
                                       "para isso utilize a operação de Depósito.", PrintText.TextColor.Red);
                AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(2000);
            }
        }

        private CheckingAccount DefineAccountToTransfer(CheckingAccount myAccount)
        {
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            string transferDestinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
            SelfTransferVerificator(transferDestinationAccountId, myAccount);
            PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
            int transferDestinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
            CheckingAccount destination = Operation.DefineAccountToDepositOrTransfer(transferDestinationAccountId, transferDestinationBankBranch);
            return destination;
        }
    }
}