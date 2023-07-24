/* Classe  : RegisteredAuthenticationData
 * Objetivo: Armazenar os dados de autenticação das contas existentes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 24/07/2023
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;

namespace Bytebank.HARDCODED_DATABASE
{
    public class RegisteredAuthenticationData
    {
        private static string? _accountId;
        private static int _bankBranch;

        internal RegisteredAuthenticationData()
        {
            RegisteredAuthData = registeredAuthData;
        }

        internal List<Authentication> RegisteredAuthData { get; }

        internal void GetCheckingAccountInformation(string accountId)
        {
            RegisteredCheckingAccounts accounts = new RegisteredCheckingAccounts();
            var accountsList = accounts.CheckingAccounts;
            foreach (var account in accountsList)
            {
                if (account.AccountId!.Equals(accountId))
                {
                    _accountId = account.AccountId;
                    _bankBranch = account.BankBranch;
                }
            }
        }

        //Lista de dados de autenticação cadastrados.
        private List<Authentication> registeredAuthData = new List<Authentication>()
        {
            { new Authentication(_accountId!, _bankBranch, 1234) },
            { new Authentication(_accountId!, _bankBranch, 4321) },
            { new Authentication(_accountId!, _bankBranch, 2468) },
        };
    }
}