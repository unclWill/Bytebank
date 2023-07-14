/* Classe  : CurrentAccount
 * Objetivo: Concentra as lógicas da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 14/07/2023
 */

using System;

namespace Bytebank.AccountManagement
{
    public class CurrentAccount
    {
        public CurrentAccount()//no futuro: string accountId, int bankBranch, string accountHolder, double balance
        {

        }

        //Construtor para Autenticação
        public CurrentAccount(string accountId, int bankBranch)
        {
            AccountId = accountId;
            BankBranch = bankBranch;
        }

        //Conta
        public string? AccountId { get; set; }
        //Agência
        public int BankBranch { get; set; }
        //Titular
        public string? AccountHolder { get; set; }
        //Saldo
        public double Balance { get; set; }


    }
}