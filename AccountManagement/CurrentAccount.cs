/* Classe  : CurrentAccount
 * Objetivo: Concentra as lógicas da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 18/07/2023
 */

using System;

namespace Bytebank.AccountManagement
{
    public class CurrentAccount
    {
        private string? _accountId;
        private int _bankBranch;
        private string? _accountHolder;
        private decimal _balance;

        //Construtor para criação de contas correntes.
        public CurrentAccount(string accountId, int bankBranch, string accountHolder, decimal balance)
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
        public decimal Balance
        {
            get => _balance;

            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    _balance = value;
                }
            }
        }


    }
}