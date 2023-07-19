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
using System.Text;
using System.Text.Json;
using System.IO;

namespace Bytebank.Authenticated
{
    public class AuthenticatedScreen
    {
        private static string? _accountId;
        private static int _accountBankBranch;
        private static string? _accountHolder;
        private static decimal _balance;

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
        private static void InitializeClientAccount(string authData)
        {
            RegisteredCheckingAccounts rCA = new RegisteredCheckingAccounts();
            var clientsAccountList = rCA.CheckingAccounts;

            try
            {
                //CheckingAccount checkingAccount = new CheckingAccount();
                //var clientsAccountList = checkingAccount.LoadJsonFile();

                foreach (var client in clientsAccountList)
                {
                    if (client.AccountId is not null && client.AccountId.Equals(authData))
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
            /*
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            PrintText.ColorizeText($"Conta  : {clientAccount.AccountId}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Agência: {clientAccount.BankBranch}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Titular: {clientAccount.AccountHolder}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Saldo  : {clientAccount.Balance:C}", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            */
        }

        private static void ShowAuthenticatedMenu()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            PrintText.DecoratedTitleText("  TERMINAL DE OPERAÇÕES FINANCEIRAS DO BYTEBANK  ", '~');
            PrintText.SetLineBreak(2);
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

            ConsoleKey keyPressed = StartScreen.EscapeFromScreenDialog("Para retornar a tela incial pressione |", ConsoleKey.Enter, "| ou aguarde.");
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
                    Console.Clear();
                    StartScreen.ShowProductOwnerBrand();
                    CheckingAccount clientAccountDeposit = new CheckingAccount(_accountId!, _accountBankBranch, _accountHolder!, _balance);
                    PrintText.DecoratedTitleText("DEPÓSITO", '*');
                    PrintText.ColorizeText("Digite o valor que será depositado: ", PrintText.TextColor.White, 0);
                    decimal valueToDeposit = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
                    clientAccountDeposit.Deposit(valueToDeposit);
                    PrintText.ColorizeText($"Valor adicionado à conta!\nValor atualizado: {clientAccountDeposit.Balance:C}", PrintText.TextColor.DarkGreen);
                    PrintTextAnimations.TreeDotsAnimation(1000);
                    _balance = clientAccountDeposit.Balance;
                    //clientAccountDeposit.GenerateJsonFile(clientAccountDeposit);
                    ShowAuthenticatedMenu();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;

            }
        }
    }
}