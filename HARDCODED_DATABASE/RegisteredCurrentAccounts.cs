/* Classe  : RegisteredCurrentAccounts
 * Objetivo: Armazenar as contas correntes registradas no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 18/07/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Bytebank.AccountManagement;

namespace Bytebank.HARDCODED_DATABASE
{
    internal class RegisteredCurrentAccounts
    {
        //Lista de contas correntes cadastradas.
        internal List<CheckingAccount> currentAccounts = new List<CheckingAccount>()
        {
            new CheckingAccount("1010-X", 15, "André Silva", 100m),
            new CheckingAccount("1018-5", 17, "Marisa Santos", 500m),
            new CheckingAccount("8594-6", 16, "Eustáquio Sodré", 1000m),
        };
    }
}