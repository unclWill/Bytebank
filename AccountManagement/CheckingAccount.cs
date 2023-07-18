/* Classe  : CurrentAccount
 * Objetivo: Concentra as lógicas da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 18/07/2023
 */

using System;
using System.Text.Json;
using Bytebank.Utils;
using System.Text.Json.Serialization;

namespace Bytebank.AccountManagement
{
    public class CheckingAccount
    {
        private string? _accountId;
        private int _bankBranch;
        private string? _accountHolder;
        private decimal _balance;

        public CheckingAccount()
        {

        }

        //Construtor para criação de contas correntes.
        public CheckingAccount(string accountId, int bankBranch, string accountHolder, decimal balance)
        {
            AccountId = accountId;
            BankBranch = bankBranch;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        //Conta
        public string? AccountId { get; set; }
        //Agência
        public int BankBranch { get; set; }
        //Titular
        public string? AccountHolder { get; set; }
        //Saldo
        public decimal Balance { get; set; }

        internal void Deposit(decimal value)
        {
            Balance += value;
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