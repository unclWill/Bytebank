/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.HARDCODED_DATABASE;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Transfer
    {
        private static string? _accountId;
        //private static int _accountBankBranch;
        //private static string? _accountHolder;
        private static decimal _balance;
        private static decimal _valueToTransfer;

        internal decimal TransferOperation(CheckingAccount account)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            Operation.ActualBalance(account.Balance);
            VerifyBalance(account.Balance);
            //
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            PrintText.UserInputIndicator();
            string transferDestinationAccountId = InputValidation.ValidateAccountIdInput("Authenticated");
            PrintText.ColorizeText("Digite o número da agência da conta de destino", PrintText.TextColor.White);
            PrintText.UserInputIndicator();
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
        private CheckingAccount VerifyAccountToTransfer(string accountId, int bankBranch)
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
                        /*_accountId = client.AccountId;
                        _accountBankBranch = client.BankBranch;
                        _accountHolder = client.AccountHolder;
                        _balance = client.Balance;*/

                        accountTransferDestination = client;
                    }
                }
                if (_accountId != accountId)
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