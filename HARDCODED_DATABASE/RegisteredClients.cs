/* Classe  : RegisteredClients
 * Objetivo: Armazenar as contas de clientes registradas no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 28/07/2023
 */

using System.Data.Common;
using Bytebank.AccountManagement;

namespace Bytebank.HARDCODED_DATABASE
{
    internal class RegisteredClients
    {
        private static Client? _accountHolder;

        internal RegisteredClients()
        {
            Clients = clients;
        }

        internal List<Client> Clients { get; }

        //Lista de Clientes cadastrados.
        private List<Client> clients = new List<Client>()
        {
            new Client(1,"André Souza","12345678900","Programador", new DateTime(1995,05,25),"Belo Horizonte - MG, Brasil", new CheckingAccount("1010-X", 15, _accountHolder!, 100m)),
            new Client(2,"Marisa Santos","00987654321","Arquiteta", new DateTime(1996,09,17),"Curitiba - PR, Brasil", new CheckingAccount("1018-5", 16, _accountHolder!, 200m)),
            new Client(3,"Carlos Sodré","11223344556","Economista", new DateTime(1970,12,25),"São Paulo - SP, Brasil", new CheckingAccount("8594-6", 17, _accountHolder!, 300m)),
        };

        /// <summary>
        /// Captura o Id da Conta Corrente no momento da Autenticação e compara a qual cliente esse Id está associado
        /// para carregar tanto os dados do Cliente quanto da Conta Corrente que está associado a este Cliente.
        /// </summary>
        /// <param name="accountId">Recebe o Id da Conta Corrente para realizar a comparação.</param>
        internal static void GetRegisteredClientsInfo(string accountId)
        {
            RegisteredClients clients = new RegisteredClients();
            var clientsList = clients.Clients.Where(clients => clients.CheckingAccount!.AccountId!.Equals(accountId))
                                             .Distinct()
                                             .ToList();

            foreach (var client in clientsList)
            {
                _accountHolder = client;
            }
        }
    }
}