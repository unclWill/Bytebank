/* Classe  : CurrentAccount
 * Objetivo: Concentra as lógicas da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 26/07/2023
 */

using Bytebank.Utils;

namespace Bytebank.AccountManagement
{
    internal class CheckingAccount
    {

        //Construtor para criação de contas correntes, onde já são passados os dados da conta corrente do cliente.
        public CheckingAccount(string accountId, int bankBranch, string accountHolder, decimal balance)
        {
            AccountId = accountId;
            BankBranch = bankBranch;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        //Construtor vazio para instanciação dos métodos em outras classes.
        public CheckingAccount()
        {

        }

        //Conta
        public string? AccountId { get; set; }
        //Agência
        public int BankBranch { get; set; }
        //Titular
        public string? AccountHolder { get; set; }
        //Saldo
        public decimal Balance { get; set; }

        internal void Deposit(CheckingAccount depositDestination, decimal value)
        {
            if (value <= 0)
            {
                return;
            }
            else
            {
                Balance += value;
                depositDestination.Balance += value;
                //return;
            }
        }

        internal bool Withdraw(decimal value)
        {
            if (Balance <= 0 || value > Balance)
            {
                PrintText.ColorizeText("[!] Não existe saldo disponível para ser sacado!", PrintText.TextColor.Red);
                return false;
            }
            else
            {
                Balance -= value;
                return true;
            }
        }

        internal bool Transfer(CheckingAccount transferDestination, decimal value)
        {
            if (Balance < value)
            {
                PrintText.ColorizeText("[!] O valor da transferência é maior que o saldo disponível!", PrintText.TextColor.Red);
                return false;
            }
            else if (value < 0)
            {
                PrintText.ColorizeText("[!] Não existe saldo disponível para realizar a transferência!", PrintText.TextColor.Red);
                return false;
            }
            else
            {
                Balance -= value;
                transferDestination.Balance += value;
                return true;
            }
        }

        internal void ShowClientAccountOverview()
        {
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            PrintText.ColorizeText($"Conta  : {AccountId}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Agência: {BankBranch}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Titular: {AccountHolder}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Saldo  : {Balance:C}", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
        }

    }
}