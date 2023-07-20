/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 19/07/2023
 */

using Bytebank.HARDCODED_DATABASE;
using Bytebank.AuthenticationComponents;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.AccountManagement;
using Bytebank.Authenticated.Operations;

namespace Bytebank.Authenticated
{
    internal class AuthenticatedScreen
    {
        private static string? _accountId;
        private static int _accountBankBranch;
        private static string? _accountHolder;
        private static decimal _balance;

        public AuthenticatedScreen() { }

        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        internal static void ShowAuthenticatedScreen()
        {
            ShowAuthenticatedMenu();
        }


        //Pega como parâmetro o número da conta do cliente no momento que os dados de autenticação são validados na classe Authentication.
        internal static void GetAccountData(Authentication accountData)
        {
            _accountId = accountData.AuthClientAccountId;
            InitializeClientAccount(_accountId);
        }

        /* Instancia os dados do cliente com base na classe de clientes registrados (RegisteredClients).
         */
        private static void InitializeClientAccount(string accountId)
        {
            RegisteredCheckingAccounts rCA = new RegisteredCheckingAccounts();
            var clientsAccountList = rCA.CheckingAccounts;

            try
            {
                foreach (var client in clientsAccountList)
                {
                    if (client.AccountId is not null && client.AccountId.Equals(accountId))
                    {
                        _accountId = client.AccountId;
                        _accountBankBranch = client.BankBranch;
                        _accountHolder = client.AccountHolder;
                        _balance = client.Balance;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        private static void ShowClientAccountInfo()
        {
            CheckingAccount clientAccountInfo = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);
            clientAccountInfo.ShowClientAccountOverview();
        }

        internal static void ShowAuthenticatedMenu()
        {
            HeaderTexts.BytebankOperationsHeader();
            //
            ShowClientAccountInfo();
            //
            PrintText.DecoratedTitleText(" Operações disponíveis neste terminal ", '-');
            PrintText.ColorizeText("|1| DEPÓSITO\n|2| SAQUE\n|3| TRANSFERÊNCIA", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("             Área do cliente          ", '-');
            PrintText.ColorizeText("|4| CONSULTAR MEUS DADOS\n|5| CONSULTAR MEU HISTÓRICO FINANCEIRO\n|6| TROCAR MINHA SENHA DE ACESSO", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("          Finalizar atendimento       ", '-');
            PrintText.ColorizeText("|7| ENCERRAR TERMINAL", PrintText.TextColor.DarkGray, 2);
            PrintText.ColorizeText("|>| ", PrintText.TextColor.White, 0);
            //
            int selectedOption = int.Parse(Console.ReadLine()!);
            MenuAction(selectedOption);

            ConsoleKey keyPressed = StartScreen.EscapeFromScreenDialog("Para retornar a tela incial pressione |", ConsoleKey.Enter, "| ou digite uma opção válida.");
            if (keyPressed == ConsoleKey.Enter)
            {
                StartScreen.ReturningToStartScreenMessage();
            }
            else
            {
                ShowAuthenticatedMenu();
            }
        }

        private static void MenuAction(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1:
                    CheckingAccount accountToDeposit = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);
                    Deposit depositToAccount = new Deposit();
                    depositToAccount.DepositOperation(accountToDeposit);
                    _balance = accountToDeposit.Balance;
                    ShowAuthenticatedMenu();
                    break;
                case 2:
                    CheckingAccount accountToWithdraw = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);
                    Withdraw withdrawFromAccount = new Withdraw();
                    withdrawFromAccount.WithdrawOperation(accountToWithdraw);
                    _balance = accountToWithdraw.Balance;
                    ShowAuthenticatedMenu();
                    break;
                case 3:
                    CheckingAccount accountToTransfer = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);
                    Transfer transferToAccount = new Transfer();
                    transferToAccount.TransferOperation(accountToTransfer);
                    _balance = accountToTransfer.Balance;
                    ShowAuthenticatedMenu();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    StartScreen.ReturningToStartScreenMessage();
                    break;

            }
        }
    }
}