/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.HARDCODED_DATABASE;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Transfer
    {
        private static string? _accountId = string.Empty;
        private static decimal _balance = 0m;
        private static decimal _valueToTransfer = 0m;

        internal decimal TransferOperation(CheckingAccount account)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            Operation.ActualBalance(account.Balance);
            VerifyBalance(account.Balance);
            //
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            string transferDestinationAccountId = InputValidation.ValidateAccountIdInput("Authenticated");
            PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
            int transferDestinationBankBranch = InputValidation.ValidateBankBranchInput("Authenticated");
            //Destino:
            CheckingAccount destination = VerifyAccountToTransfer(transferDestinationAccountId, transferDestinationBankBranch);
            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            PrintText.ColorizeText("Digite o valor que deseja transferir", PrintText.TextColor.White);
            PrintText.UserInputIndicator();
            decimal valueToTransfer = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            _valueToTransfer = Operation.ConfirmAction(valueToTransfer);
            account.Transfer(destination, _valueToTransfer); //<--
            Operation.AccountBalanceStatus('T', _valueToTransfer, _balance, destination.Balance); //<--
            return _valueToTransfer;
        }

        private static void VerifyBalance(decimal balance)
        {
            if (balance <= 0)
            {
                Console.WriteLine("[!] Você não possui saldo disponível para realizar transferências!");
            }
        }
        private static CheckingAccount VerifyAccountToTransfer(string accountId, int bankBranch)
        {
            RegisteredCheckingAccounts registeredCheckingAccounts = new RegisteredCheckingAccounts();
            var clientsAccountList = registeredCheckingAccounts.CheckingAccounts;

            CheckingAccount accountTransferDestination = new CheckingAccount();

            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.AccountId is not null && client.AccountId.Equals(accountId) && client.BankBranch == bankBranch)
                    {
                        accountTransferDestination = client;
                    }
                }

                //if (_accountId != accountId)
                if (accountId != accountTransferDestination.AccountId)
                {
                    PrintText.ColorizeText("[!] A conta informada não existe!", PrintText.TextColor.Red);
                    PrintTextAnimations.TreeDotsAnimation(1500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            return accountTransferDestination;
        }
    }
}