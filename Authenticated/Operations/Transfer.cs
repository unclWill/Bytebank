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
        private static decimal _valueToTransfer = 0m;

        internal decimal TransferOperation(CheckingAccount clientAccount)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            Operation.ActualBalance(clientAccount.Balance);
            Operation.VerifyBalance('T', clientAccount.Balance);
            //Destino:
            CheckingAccount destination = DefineAccountToTransfer(clientAccount);
            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            _valueToTransfer = Operation.ConfirmAction('T');
            clientAccount.Transfer(destination, _valueToTransfer);
            Operation.AccountBalanceStatus('T', _valueToTransfer, clientAccount.Balance, destination.Balance);
            return _valueToTransfer;
        }

        private void SelfTransferVerificator(string destination, CheckingAccount clientAccount)
        {
            if (destination == clientAccount.AccountId)
            {
                PrintText.ColorizeText("[!] Não são permitidas transferências onde a origem e o destino são os mesmos,\n" +
                                       "para isso utilize a operação de Depósito.", PrintText.TextColor.Red);
                AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(2000);
            }
        }

        private CheckingAccount DefineAccountToTransfer(CheckingAccount clientAccount)
        {
            Operation operation = new Operation();

            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            string transferDestinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
            SelfTransferVerificator(transferDestinationAccountId, clientAccount);
            PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
            int transferDestinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
            CheckingAccount destination = operation.DefineAccountToDepositOrTransfer(transferDestinationAccountId, transferDestinationBankBranch);
            return destination;
        }
    }
}