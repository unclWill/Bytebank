/* Classe  : Client
 * Objetivo: Concentra as lógicas de criação de clientes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 28/07/2023
 */

/* OBSERVAÇÕES: A classe Client contém os dados pessoais do titular (AccountHolder) de uma Conta Corrente.
 *              Todo cliente possui, mandatoriamente, uma Conta Corrente (CheckingAccount) associada, que 
 *              deve ser informada no momento da criação do cadastro do cliente no sistema.
 *
 *              O acesso aos dados de uma Conta Corrente devem passar pela instância classe Client. Pois
 *              a Conta Corrente e seus dados, como Nº de Conta e Agência e o próprio Titular, além do Saldo estão contidos no registro do cliente.
 */

using Bytebank.Accounts;
using Bytebank.Utils;

namespace Bytebank.Clients
{
    /// <summary>
    /// Define as caractrísticas de um cliente e as lógicas associadas à sua implementação.
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// Construtor padrão da classe Client com todos os parâmateros que determinam as características de um cliente.
        /// </summary>
        /// <param name="clientId">Recebe o ID único, sequencial, do cliente, como seria na base de dados.</param>
        /// <param name="clientName">Recebe o nome do cliente.</param>
        /// <param name="cpf">Recebe o CPF do cliente.</param>
        /// <param name="profession">Recebe a profissão do cliente.</param>
        /// <param name="dateOfBirth">Recebe a data de nascimento do cliente.</param>
        /// <param name="naturalFrom">Recebe a cidade, o estado e o país de origem do cliente.</param>
        /// <param name="checkingAccount">Recebe a Conta Corrente do cliente.</param>
        internal Client(int clientId, string clientName, string cpf, string profession, DateTime dateOfBirth, string naturalFrom, CheckingAccount checkingAccount)
        {
            ClientId = clientId;
            ClientName = clientName;
            Cpf = cpf;
            Profession = profession;
            DateOfBirth = dateOfBirth;
            NaturalFrom = naturalFrom;
            CheckingAccount = checkingAccount;
        }

        /// <summary>
        /// Construtor vazio da classe Client
        /// </summary>
        internal Client() { }

        internal int ClientId { get; set; }
        internal string? ClientName { get; set; }
        internal string? Cpf { get; set; }
        internal string? Profession { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal string? NaturalFrom { get; set; }
        internal CheckingAccount? CheckingAccount { get; set; }

        /// <summary>
        /// Exibe as informações do titular da conta (AccountHolder).
        /// </summary>
        internal void ShowClientInfo()
        {
            PrintText.ColorizeText("Dados do cliente", PrintText.TextColor.Gray);
            PrintText.ColorizeText($"ID          : {ClientId}", PrintText.TextColor.DarkGray);
            PrintText.ColorizeText($"Titular     : {ClientName}", PrintText.TextColor.White);
            PrintText.ColorizeText($"CPF         : {Cpf}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Profissão   : {Profession}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Nascimento  : {DateOfBirth.Date:dd/MM/yyyy}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Naturalidade: {NaturalFrom}", PrintText.TextColor.White);
            PrintText.SetLineBreak(1);
        }

        internal void UpdateClientData()
        {
            PrintText.ColorizeText("Atualização de dados:", PrintText.TextColor.DarkYellow);

        }
    }
}