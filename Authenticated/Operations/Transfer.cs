/* Classe  : Transfer
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 19/07/2023
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
        private static decimal valueToTransfer;

        internal decimal TransferOperation(CheckingAccount account)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRASNFERÊNCIA
            HeaderTexts.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*');
            PrintText.ColorizeText($"Seu saldo atual: {account.Balance:C}", PrintText.TextColor.DarkGray);
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            string transferDestination = Console.ReadLine()!;
            VerifyAccountToTransfer(transferDestination);
            CheckingAccount accountToTransfer = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);

            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            PrintText.ColorizeText("Digite o valor que deseja transferir: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            valueToTransfer = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            ConfirmAction();
            account.Transfer(accountToTransfer, valueToTransfer);
            PrintText.ColorizeText($"Valor transferido da conta!\nValor atualizado: {account.Balance:C} | Valor na conta recebedora: {accountToTransfer.Balance:C}", PrintText.TextColor.DarkYellow);
            PrintTextAnimations.TreeDotsAnimation(1000);
            return valueToTransfer;
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

        private static void ConfirmAction()
        {
            int confirmation;
            PrintText.ColorizeText("Confirma a operação?\n |0| NÃO  -  |1| SIM\n[>] ", PrintText.TextColor.White, 0);
            while (!int.TryParse(Console.ReadLine(), out confirmation))
            {
                PrintText.ColorizeText("[!] Digite uma opção válida!", PrintText.TextColor.DarkRed);
                PrintText.UserInteractionIndicator();
            }

            if (confirmation == 0)
            {
                valueToTransfer = 0m;
                PrintText.ColorizeText("[!] Transferência cancelada.", PrintText.TextColor.Red);
                return;
            }
        }
    }
}