/* Classe  : Operation
 * Objetivo: Concentrar os métodos comuns a todas as operações.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 20/07/2023 (Criação) | Modificação: 28/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.HARDCODED_DATABASE;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    /// <summary>
    /// Concentra as lógicas que são comuns a todas as operações.
    /// </summary>
    internal class Operation
    {
        internal static void ReturnToOperationsMenu()
        {
            PrintText.ColorizeText("[i] Para retornar ao menu de operações digite |1| ou |2| para continuar", PrintText.TextColor.DarkGray);
            int selectedOption = InputValidation.ValidateMenuOptionInput(1, 2);
            switch (selectedOption)
            {
                case 1:
                    AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1000);
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Exibe os diálogos de inserção de valores para movimentação e confirmação da operação.
        /// </summary>
        /// <param name="operationType">Recebe o tipo de operação: D (Deposit), T (Transfer) ou W (Withdraw) para determinar a mensagem que será retornada no início da operação.</param>
        /// <returns>Retorna o valor que será movimentado na conta.</returns>
        internal static decimal InsertValueAndConfirmOperation(char operationType)
        {
            switch (operationType)
            {
                case 'D':
                    PrintText.ColorizeText("\nDigite o valor que deseja depositar", PrintText.TextColor.White);
                    break;
                case 'T':
                    PrintText.ColorizeText("\nDigite o valor que deseja transferir", PrintText.TextColor.White);
                    break;
                case 'W':
                    PrintText.ColorizeText("\nDigite o valor que deseja sacar", PrintText.TextColor.White);
                    break;
            }
            PrintText.UserInputIndicator();
            //---
            decimal operationValue = OperationInputValidation();
            bool operationConfirmation = ConfirmOperation();

            if (operationConfirmation == true)
            {
                return operationValue;
            }
            else if (operationConfirmation == false)
            {
                return 0m;
            }
            return 0m;
        }

        /// <summary>
        /// Verifica o saldo disponível na Conta Corrente do cliente.
        /// </summary>
        /// <param name="operationType">Recebe o tipo de operação: T (Transfer) ou W (Withdraw) para determinar a mensagem que será retornada caso não haja saldo disponível para realizar as operações.</param>
        /// <param name="balance">Recebe o saldo atual da conta.</param>
        internal static void VerifyBalance(char operationType, decimal balance)
        {
            switch (operationType)
            {
                case 'W':
                    if (balance <= 0)
                    {
                        PrintText.ColorizeText("[!] Você não possui saldo disponível para realizar saques!", PrintText.TextColor.DarkYellow);
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1200);
                    }
                    break;
                case 'T':
                    if (balance <= 0)
                    {
                        PrintText.ColorizeText("[!] Você não possui saldo disponível para realizar transferências!", PrintText.TextColor.DarkYellow);
                        AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1200);
                    }
                    break;
            }
        }

        /// <summary>
        /// Verifica se a conta de Origem e a de Destino são a mesma e impede o prosseguimento da operação.
        /// </summary>
        /// <param name="clientAccount">Recebe a conta de origem da movimentação.</param>
        /// <param name="destination">Recebe a conta que será o destino da movimentação.</param>
        internal static void SelfDepositOrTransferVerification(CheckingAccount clientAccount, string destination)
        {
            if (destination == clientAccount.AccountId)
            {
                PrintText.ColorizeText("[!] Não são permitidas movimentações onde a origem e o destino são os mesmos.", PrintText.TextColor.Red);
                AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1200);
            }
        }

        /// <summary>
        /// Exibe uma mensagem que informa o status do saldo após a operação, se foi acrescido, subtraído, transferido ou se permanece inalterado.
        /// </summary>
        /// <param name="operationType">Recebe o tipo de operação: D (Deposit), T (Transfer) ou W (Withdraw) para determinar a mensagem que será retornada ao fim da operação.</param>
        /// <param name="transactionValue">Recebe o valor que está sendo movimentado.</param>
        /// <param name="balance">Recebe o saldo atual, pós operação.</param>
        /// <param name="accountToTransferBalance">Recebe o saldo atualizado da conta de destino (utilizado para teste durante o desenvolvimento).</param>
        internal static void AccountBalanceStatus(char operationType, decimal transactionValue, decimal balance, decimal accountToTransferBalance = 0m)
        {
            switch (operationType)
            {
                case 'D':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi depositado.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor adicionado à conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'W':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi sacado.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"[i] Valor sacado da da conta!\nValor atualizado: {balance:C}", PrintText.TextColor.DarkGreen);
                    }
                    break;
                case 'T':
                    if (transactionValue == 0m)
                    {
                        PrintText.ColorizeText("[i] Nenhum valor foi transferido.", PrintText.TextColor.Gray);
                    }
                    else
                    {
                        PrintText.ColorizeText($"Valor transferido da conta!\nValor atualizado: {balance:C}\nValor na conta recebedora: {accountToTransferBalance:C}", PrintText.TextColor.DarkYellow);
                    }
                    break;
            }
            PrintTextAnimations.TreeDotsAnimation(1000);
        }

        
        /// <summary>
        /// Busca pelas Contas Correntes na base de dados para determinar o destino de uma operação de Depósito ou uma Transferência.
        /// </summary>
        /// <param name="accountId">Recebe o número da Conta Corrente de destino.</param>
        /// <param name="bankBranch">Recebe o número da Agência da Conta Corrente de destino.</param>
        /// <param name="clientAccount">Recebe a instância da Conta Corrente do cliente autenticado no sistema, se o depósito for do Tipo 1, senão o valor é nulo.</param>
        /// <returns>Retorna a Conta Corrente que será o destino da operação.</returns>
        internal static CheckingAccount DefineAccountToDepositOrTransfer(string accountId, int bankBranch, CheckingAccount clientAccount = null!)
        {
            RegisteredClients registeredClientAccounts = new RegisteredClients();
            var clientsAccountList = registeredClientAccounts.Clients;
            CheckingAccount destinationAccount = new CheckingAccount();

            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.CheckingAccount!.AccountId is not null && client.CheckingAccount.AccountId.Equals(accountId) && client.CheckingAccount.BankBranch == bankBranch)
                    {
                        if (clientAccount is not null && client!.CheckingAccount.AccountId.Equals(clientAccount!.AccountId))
                        {
                            return clientAccount;
                        }
                        else
                        {
                            destinationAccount = client.CheckingAccount!;
                        }
                    }
                }
                if (accountId != destinationAccount.AccountId)
                {
                    PrintText.ColorizeText("[!] A conta informada não existe ou foi digitada incorretamente!", PrintText.TextColor.Red);
                    AuthenticatedScreen.ReturningToAuthenticatedScreenMessage(1200);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            return destinationAccount;
        }

        /// <summary>
        /// Realiza a validação da entrada do valor da operação que está sendo feita.
        /// </summary>
        /// <returns>Retorna o valor da operção validado.</returns>
        private static decimal OperationInputValidation()
        {
            decimal operationValue;
            while (!decimal.TryParse(Console.ReadLine()!.Replace('.', ','), out operationValue))
            {
                PrintText.ColorizeText("[!] Por favor, digite corretamente o valor que deseja movimentar", PrintText.TextColor.Red);
                PrintText.UserInputIndicator();
            }
            return operationValue;
        }

        /// <summary>
        /// Confirma ou cancela a operação, de acordo com a opção digitada pelo usuário.
        /// </summary>
        /// <returns>Retorna False se a operação for cancelada e True se for confirmada.</returns>
        private static bool ConfirmOperation()
        {
            PrintText.DecoratedTitleText(" Confirmar operação? ", '-', PrintText.TextColor.DarkRed, 0);
            PrintText.ColorizeText("|1| NÃO  -  |2| SIM", PrintText.TextColor.Red, 2);
            PrintText.UserInputIndicator();

            int confirmation = InputValidation.ValidateMenuOptionInput(1, 2);
            switch (confirmation)
            {
                case 1:
                    PrintText.ColorizeText("[i] Operação cancelada.", PrintText.TextColor.Red);
                    return false;
                case 2:
                    return true;
            }
            return false;
        }
    }
}