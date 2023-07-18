/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 30/06/2023
 */

using Bytebank.AccountManagement;
using Bytebank.AuthenticationComponents;
using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using System;

namespace Bytebank.Authenticated
{
    public class AuthenticatedScreen
    {
        private static string? _accountId;
        private static int _accountBankBranch;
        //
        private static string? _accountHolder;
        private static double _balance;

        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        internal void ShowAuthenticatedScreen()
        {
            ShowAuthenticatedMenu();
        }

        //Pega como parâmetro o número da conta do cliente no momento que os dados de autenticação são validados na classe Authentication.
        internal static void GetAccountData(Authentication accountData)
        {
            _accountId = accountData.AuthClientAccountId;
            //_accountBankBranch = accountData.AuthClientBankBranch;

            AuthenticatedScreen authenticatedScreen = new AuthenticatedScreen();
            authenticatedScreen.InitializeClientAccount(_accountId);
        }

        /* Instancia os dados do cliente com base na classe de clientes registrados (RegisteredClients).
         */
        internal void InitializeClientAccount(string authData)
        {
            RegisteredClients registeredClients1 = new RegisteredClients();
            var clientsList = registeredClients1.currentAccounts;

            foreach (var client in clientsList)
            {
                if (client.AccountId.Equals(_accountId))
                {
                    _accountId = client.AccountId;
                    _accountBankBranch = client.BankBranch;
                    _accountHolder = client.AccountHolder;
                    _balance = client.Balance;

                    //CurrentAccount clientAccount = new CurrentAccount(_accountId, _accountBankBranch, _accountHolder, _balance);
                }
            }
        }

        private static void ShowClientAccountBasicInfo()
        {
            PrintText.ColorizeText("Dados da conta", PrintText.TextColor.DarkMagenta);
            PrintText.ColorizeText($"Conta: {_accountId}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Agência: {_accountBankBranch}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Titular: {_accountHolder}", PrintText.TextColor.White);
            PrintText.ColorizeText($"Saldo: {_balance}", PrintText.TextColor.White);
            PrintText.SetLineBreak(1);
        }

        private static void ShowAuthenticatedMenu()
        {
            Console.Clear();
            StartScreen.ShowProductOwnerBrand();
            PrintText.DecoratedTitleText("  TERMINAL DE OPERAÇÕES FINANCEIRAS DO BYTEBANK  ", '~');
            PrintText.SetLineBreak(2);
            //
            ShowClientAccountBasicInfo();
            PrintText.DecoratedTitleText(" Operações disponíveis neste terminal ", '-');
            PrintText.ColorizeText("|1| DEPÓSITO\n|2| SAQUE\n|3| TRANSFERÊNCIA", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("             Área do cliente          ", '-');
            PrintText.ColorizeText("|4| CONSULTAR MEUS DADOS\n|5| CONSULTAR MEU HISTÓRICO FINANCEIRO\n|6| TROCAR MINHA SENHA DE ACESSO", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("          Finalizar atendimento       ", '-');
            PrintText.ColorizeText("|7| ENCERRAR TERMINAL", PrintText.TextColor.DarkYellow);

            ConsoleKey keyPressed = StartScreen.EscapeFromScreenDialog("Para retornar a tela incial pressione |", ConsoleKey.Enter, "| ou aguarde.");
            if (keyPressed == ConsoleKey.Enter)
            {
                StartScreen.ReturningToStartScreenMessage();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
        }
    }
}