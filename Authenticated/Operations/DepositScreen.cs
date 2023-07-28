/* Classe  : DepositScreen
 * Objetivo: Concentrar as operações de depósito na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 28/07/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    /// <summary>
    /// Exibe a tela da operação de Depósito.
    /// </summary>
    internal class DepositScreen
    {
        /// <summary>
        /// Exibe os diálogos responsáveis por capturar a entrada dos dados fornecidos pelo cliente para a realização da operação de Depósito.
        /// </summary>
        /// <param name="clientAccount">Recebe a Conta Corrente do cliente que foi autenticado no sistema.</param>
        internal static void DepositOperation(CheckingAccount clientAccount)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[+$] DEPÓSITO ", '*', PrintText.TextColor.DarkGreen, 0);
            clientAccount.ShowActualBalance();
            //---
            CheckingAccount destination = DefineAccountToDeposit(clientAccount);
            //---
            decimal valueToDeposit = Operation.InsertValueAndConfirmOperation('D');
            //
            clientAccount.Deposit(destination, valueToDeposit);
            //
            Operation.AccountBalanceStatus('D', valueToDeposit, clientAccount.Balance);
            //
            AuthenticatedScreen.ShowAuthenticatedMenu();
        }

        /// <summary>
        /// Exibe as opções que determinam onde qual o tipo de Depósito será realizado, na própria conta do cliente (Tipo 1) ou na conta de outro correntista (Tipo 2).
        /// </summary>
        /// <param name="clientAccount">Recebe a Conta Corrente do cliente autenticado no sistema.</param>
        /// <returns>Se a conta de destino for válida, retorna a instância com os dados da mesma.</returns>
        private static CheckingAccount DefineAccountToDeposit(CheckingAccount clientAccount)
        {
            PrintText.DecoratedTitleText(" ONDE DESEJA REALIZAR O DEPÓSITO? ", '-');
            PrintText.ColorizeText("|1| NA MINHA CONTA\n|2| NA CONTA DE UM TERCEIRO", PrintText.TextColor.Gray);
            PrintText.UserInputIndicator();
            int menuOption = InputValidation.ValidateMenuOptionInput(1, 2);
            switch (menuOption)
            {
                case 1:
                    return Operation.DefineAccountToDepositOrTransfer(clientAccount.AccountId!, clientAccount.BankBranch, clientAccount);
                case 2:
                    PrintText.ColorizeText("Digite o número da conta que receberá o depósito", PrintText.TextColor.White);
                    string destinationAccountId = AuthInputValidation.ValidateAccountIdInput("Authenticated");
                    Operation.SelfDepositOrTransferVerification(clientAccount, destinationAccountId);
                    PrintText.ColorizeText("\nDigite o número da agência da conta de destino", PrintText.TextColor.White);
                    int destinationBankBranch = AuthInputValidation.ValidateBankBranchInput("Authenticated");
                    return Operation.DefineAccountToDepositOrTransfer(destinationAccountId, destinationBankBranch);
            }
            return null!;
        }
    }
}