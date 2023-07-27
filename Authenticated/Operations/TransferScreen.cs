/* Classe  : TransferScreen
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 27/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    /// <summary>
    /// Exibe a tela da operação de Transferência.
    /// </summary>
    internal class TransferScreen
    {
        /// <summary>
        /// Exibe os diálogos responsáveis por capturar a entrada dos dados fornecidos pelo cliente para a realização de transferências entre contas.
        /// </summary>
        /// <param name="clientAccount">Recebe a conta do cliente autenticado no sistema.</param>
        internal static void TransferOperation(CheckingAccount clientAccount)
        {
            //DEFININDO A CONTA QUE RECEBERÁ A TRANSFERÊNCIA
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[$->] TRANSFERÊNCIA ", '*', PrintText.TextColor.DarkCyan);
            clientAccount.ShowActualBalance();
            Operation.VerifyBalance('T', clientAccount.Balance);
            //Destino:
            CheckingAccount destination = DefineAccountToTransfer(clientAccount);
            //DEFININDO O VALOR QUE SERÁ TRANSFERIDO
            decimal valueToTransfer = Operation.ConfirmAction('T');
            clientAccount.Transfer(destination, valueToTransfer);
            Operation.AccountBalanceStatus('T', valueToTransfer, clientAccount.Balance, destination.Balance);
            //
            AuthenticatedScreen.ShowAuthenticatedMenu();
        }

        /// <summary>
        /// Exibe os diálogos que permitem a entrada de dados para definir a conta que receberá a transferência.
        /// </summary>
        /// <param name="clientAccount">Recebe a conta do cliente autenticado no sistema.</param>
        /// <returns>Se a conta de destino for válida, retorna a instância com os dados da mesma.</returns>
        private static CheckingAccount DefineAccountToTransfer(CheckingAccount clientAccount)
        {
            PrintText.ColorizeText("Digite o número da conta que receberá a transferência", PrintText.TextColor.White);
            string transferDestinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
            Operation.SelfDepositOrTransferVerification(clientAccount, transferDestinationAccountId);
            PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
            int transferDestinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
            CheckingAccount destination = Operation.DefineAccountToDepositOrTransfer(transferDestinationAccountId, transferDestinationBankBranch);
            return destination;
        }
    }
}