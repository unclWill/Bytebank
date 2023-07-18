/* Classe  : RegisteredCurrentAccounts
 * Objetivo: Armazenar as contas correntes registradas no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 18/07/2023
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Bytebank.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bytebank.AccountManagement;

namespace Bytebank.HARDCODED_DATABASE
{
    internal class RegisteredCheckingAccounts
    {
        //public RegisteredCheckingAccounts()
        //{
        //    CheckingAccounts = checkingAccounts;
        //}

        //[JsonPropertyName("CheckingAccounts")]
        //internal List<CheckingAccount> CheckingAccounts { get; set; }

        //Lista de contas correntes cadastradas.
        internal List<CheckingAccount> checkingAccounts = new List<CheckingAccount>()
        {
            new CheckingAccount("1010-X", 15, "André Silva", 500m),
            new CheckingAccount("1018-5", 17, "Marisa Santos", 750m),
            new CheckingAccount("8594-6", 16, "Eustáquio Sodré", 2000m),
        };

        /*internal List<CheckingAccount> LoadJsonFile()
        {
            string json = File.ReadAllText(@"D:\Development\PROJETOS\_ProjetosDeCursos\Projetos_Alura\FormacaoCSharp\2.0_Aplicando a Orientação a Objetos\Bytebank_Project\Bytebank\bin\Debug\net7.0\REGISTERED_CHECKING-ACCOUNTS.json");

            RegisteredCheckingAccounts registeredAccounts = JsonSerializer.Deserialize<RegisteredCheckingAccounts>(json)!;
            List<CheckingAccount> importedCheckingAccounts = registeredAccounts.CheckingAccounts;

            return importedCheckingAccounts;
        }*/
    }
}