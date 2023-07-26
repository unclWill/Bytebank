/* Classe  : RegisteredCurrentAccounts
 * Objetivo: Armazenar as contas correntes registradas no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 26/07/2023
 */

using System.Collections.Generic;
using Bytebank.Utils;
using System.Text.Json;
using Bytebank.AccountManagement;

namespace Bytebank.HARDCODED_DATABASE
{
    internal class RegisteredCheckingAccounts
    {
        internal RegisteredCheckingAccounts()
        {
            CheckingAccounts = checkingAccounts;
        }

        internal List<CheckingAccount> CheckingAccounts { get; set; }

        //Lista de contas correntes cadastradas.
        private List<CheckingAccount> checkingAccounts = new List<CheckingAccount>()
        {
            new CheckingAccount("1010-X", 15, "André Silva", 100m),
            new CheckingAccount("1018-5", 16, "Marisa Santos", 200m),
            new CheckingAccount("8594-6", 17, "Eustáquio Sodré", 300m),
        };

        internal void LoadFromDatabase(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                checkingAccounts = JsonSerializer.Deserialize<List<CheckingAccount>>(json)!;
            }
            else
            {
                PrintText.ColorizeText("[!] O arquivo não existe!", PrintText.TextColor.DarkRed);
            }
        }

        internal List<CheckingAccount> GetCheckingAccounts()
        {
            return checkingAccounts;
        }

        internal void AddCheckingAccount(CheckingAccount checkingAccount)
        {
            //checkingAccount.DatabaseId = checkingAccounts.Count + 1;
            checkingAccounts.Add(checkingAccount);
        }

        internal void SaveOnDatabase(string path)
        {
            string json = JsonSerializer.Serialize(checkingAccounts);
            File.WriteAllText(path, json);
        }
    }
}