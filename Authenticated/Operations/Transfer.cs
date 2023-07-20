/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 20/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.HARDCODED_DATABASE;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Transfer
    {
        private static string? _accountId;
        private static int _accountBankBranch;
        private static string? _accountHolder;
        private static decimal _balance;
        private static decimal _valueToTransfer;



        internal decimal TransferOperation(CheckingAccount account)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkBlue);
            Operation.ActualBalance(account.Balance);
            VerifyBalance(account.Balance);
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            string transferDestination = Console.ReadLine()!;
            VerifyAccountToTransfer(transferDestination);
            CheckingAccount accountToTransfer = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);

            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            PrintText.ColorizeText("Digite o valor que deseja transferir: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            decimal valueToTransfer = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            _valueToTransfer = Operation.ConfirmAction(valueToTransfer);
            account.Transfer(accountToTransfer, _valueToTransfer);
            Operation.AccountBalanceStatus('T', _valueToTransfer, _balance, accountToTransfer.Balance);
            PrintTextAnimations.TreeDotsAnimation(1000);
            return _valueToTransfer;
        }

        private static void VerifyBalance(decimal balance)
        {
            if (balance <= 0)
            {
                Console.WriteLine("[!] Você não possui saldo disponível para realizar transferências!");
            }
        }
        private static void VerifyAccountToTransfer(string accountId)
        {
            RegisteredCheckingAccounts rCA = new RegisteredCheckingAccounts();
            var clientsAccountList = rCA.CheckingAccounts;

            //CheckingAccount accountTransferDestination = new CheckingAccount();
            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.AccountId is not null && client.AccountId.Equals(accountId))
                    {
                        _accountId = client.AccountId;
                        _accountBankBranch = client.BankBranch;
                        _accountHolder = client.AccountHolder;
                        _balance = client.Balance;
                    }

                    if (_accountId != accountId)
                    {
                        PrintText.ColorizeText("[!] A conta informada não existe!", PrintText.TextColor.Red);
                        PrintTextAnimations.TreeDotsAnimation(1500);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            //return accountTransferDestination;
        }
    }
}