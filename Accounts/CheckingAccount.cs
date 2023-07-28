/* Classe  : CheckingAccount
 * Objetivo: Concentra as lógicas da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 28/07/2023
 */

/* OBSERVAÇÃO: [ESTE COMENTÁRIO DEVE APARECER NO CABEÇALHO DAS CLASSES Authentication e CheckingAccount]
 *             As classes Authentication e CheckingAccount armazenam dados relacionados à Contas Correntes de clientes do Bytebank.
 *
 *             No entando a classe Authentication se limita a saber apenas os dados necessários para a autenticação do cliente.
 *             Enquanto a classe CheckingAccount conhece apenas os dados úteis para a criação e a consequente movimentação dos recursos de uma Conta Corrente.
 *             
 *             A classe Authentication sabe apenas a ID do cliente (Nº da Conta Corrente);
 *             Sua chave de confirmação (Nº da Agência) que determina que aquela ID é única, pois só pode existir uma Conta Corrente com o mesmo número em cada agência;
 *             E a senha, que é o fator de verificação de que a tentiva de autenticação está sendo realizada pelo titular da conta, já que é uma informação pessoal e que
 *             apenas ele - o titular - deve ter conhecimento.
 *
 *             Já a classe CheckingAccount sabe as mesmas informações que a classe Authentication, exceto a senha do cliente. Pois o seu princípio é definir e manipular os
 *             dados da Conta Corrente dos clientes quando os mesmos já estão autenticados no sistema.
 */

using Bytebank.Utils;

namespace Bytebank.Accounts
{
    /// <summary>
    /// Determina o que é uma Conta Corrente no Bytebank.
    /// </summary>
    internal class CheckingAccount
    {
        /// <summary>
        /// Construtor de uma Conta Corrente.
        /// </summary>
        /// <param name="accountId">Recebe o número da Conta Corrente, que serve como um ID global de cada conta.</param>
        /// <param name="bankBranch">Recebe o número da Agência do cliente, que serve como uma chave de confirmação para o accountId.</param>
        /// <param name="accountHolder">Recebe o nome do Titular da conta.</param>
        /// <param name="balance">Recebe o saldo da conta.</param>
        public CheckingAccount(string accountId, int bankBranch, Client accountHolder, decimal balance)
        {
            AccountId = accountId;
            BankBranch = bankBranch;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        /// <summary>
        /// Construtor vazio da classe CheckingAccount, utilizado em casos onde só é necessário criar uma variável temporária que armazena uma Conta Corrente.
        /// </summary>
        public CheckingAccount() { }

        //Conta
        public string? AccountId { get; set; }
        //Agência
        public int BankBranch { get; set; }
        //Titular
        public Client? AccountHolder { get; }
        //Saldo
        public decimal Balance { get; internal set; }

        /// <summary>
        /// Realiza a operação de Depósito, que pode ser na própria conta do cliente ou na conta de outro correntista do Bytebank.
        /// </summary>
        /// <param name="depositDestination">Recebe a conta de destino do depósito.</param>
        /// <param name="valueToDeposit">Recebe o valor que será depositado.</param>
        internal void Deposit(CheckingAccount depositDestination, decimal valueToDeposit)
        {
            if (valueToDeposit <= 0)
            {
                return;
            }
            else
            {
                depositDestination.Balance += valueToDeposit;
            }
        }

        /// <summary>
        /// Realiza o procedimento de Saque na Conta Corrente do cliente.
        /// </summary>
        /// <param name="valueToWithdraw">Recebe o valor que será sacado da conta.</param>
        /// <returns>Retorna TRUE se a operação for válida e FALSE se o saldo não for compatível com o valor que o cliente está tentando sacar.</returns>
        internal bool Withdraw(decimal valueToWithdraw) //Não está sendo utilizado o retorno do método por conveniência.
        {
            if (Balance <= 0 || valueToWithdraw > Balance)
            {
                PrintText.ColorizeText("[!] Não existe saldo disponível para ser sacado!", PrintText.TextColor.Red);
                return false;
            }
            else
            {
                Balance -= valueToWithdraw;
                return true;
            }
        }

        /// <summary>
        /// Realiza o procedimento de Transferência de recursos financeiros entre Contas de correntistas do Bytebank.
        /// </summary>
        /// <param name="transferDestination">Recebe a conta de destino da transferência.</param>
        /// <param name="valueToTransfer">Recebe o valor que será transferido entre contas.</param>
        /// <returns>Retorna TRUE se a operação for válida e FALSE se o valor das transferência exceder ou saldo disponível ou se o saldo for 0.</returns>
        internal bool Transfer(CheckingAccount transferDestination, decimal valueToTransfer) //Não está sendo utilizado o retorno do método por conveniência,
        {                                                                                    //já que a classe Operation faz essa verificação antes de o método Transfer ser chamado,
            if (Balance < valueToTransfer)                                                   //mas foi mantido mesmo assim para servir como dupla verificação.
            {
                PrintText.ColorizeText("[!] O valor da transferência é maior que o saldo disponível!", PrintText.TextColor.Red);
                return false;
            }
            else if (valueToTransfer < 0)
            {
                PrintText.ColorizeText("[!] Não existe saldo disponível para realizar a transferência!", PrintText.TextColor.Red);
                return false;
            }
            else
            {
                Balance -= valueToTransfer;
                transferDestination.Balance += valueToTransfer;
                return true;
            }
        }

        /// <summary>
        /// Exibe o saldo atual da Conta Corrente nas telas de operações.
        /// </summary>
        internal void ShowActualBalance()
        {
            PrintText.DecoratedTitleText($"Seu saldo atual: {Balance:C}", '-', PrintText.TextColor.DarkGray);
        }

        /// <summary>
        /// Exibe os dados básicos da Conta Corrente do cliente.
        /// </summary>
        internal void ShowClientAccountOverview()
        {
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            PrintText.ColorizeText($"Conta  : {AccountId}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Agência: {BankBranch}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Titular: {AccountHolder!.ClientName}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Saldo  : {Balance:C}", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
        }
    }
}