/* Classe  : RegisteredAuthenticationData
 * Objetivo: Armazenar os dados de autenticação das contas existentes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 28/07/2023
 */

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

        internal static void GetCheckingAccountInformation(string accountId, int bankBranch)
        {
            RegisteredClients clients = new RegisteredClients();
            var clientsList = clients.Clients;
            foreach (var client in clientsList)
            {
                if (client is not null && client.CheckingAccount!.AccountId!.Equals(accountId) && client.CheckingAccount.BankBranch == bankBranch)
                {
                    _accountId = client.CheckingAccount.AccountId;
                    _bankBranch = client.CheckingAccount.BankBranch;
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