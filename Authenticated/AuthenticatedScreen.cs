/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 26/07/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.AccountManagement;
using Bytebank.Authenticated.Operations;

namespace Bytebank.Authenticated
{
    internal class AuthenticatedScreen
    {
        private static CheckingAccount _clientAccount;

        public AuthenticatedScreen(CheckingAccount clientAccount)
        {
            if (clientAccount == null)
            {
                throw new ArgumentNullException(nameof(clientAccount), "A instância de CheckingAccount não pode ser nula.");
            }
            _clientAccount = clientAccount;
        }

        public AuthenticatedScreen()// : this(new CheckingAccount())
        {
            // O construtor padrão agora chama o construtor parametrizado com uma nova instância de CheckingAccount.
        }

        /// <summary>
        /// Exibe o menu da área logada do sistema.
        /// </summary>
        internal static void ShowAuthenticatedScreen()
        {
            ShowAuthenticatedMenu();
        }

        internal static void ShowAuthenticatedMenu()
        {
            HeaderText.BytebankOperationsHeader();
            //----
            _clientAccount.ShowClientAccountOverview();
            //----
            PrintText.DecoratedTitleText(" Operações disponíveis neste terminal ", '-');
            PrintText.ColorizeText("|1| DEPÓSITO\n|2| SAQUE\n|3| TRANSFERÊNCIA", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("             Área do cliente          ", '-');
            PrintText.ColorizeText("|4| CONSULTAR MEUS DADOS\n|5| CONSULTAR MEU HISTÓRICO FINANCEIRO\n|6| TROCAR MINHA SENHA DE ACESSO", PrintText.TextColor.Gray);
            PrintText.SetLineBreak(1);
            PrintText.DecoratedTitleText("          Finalizar atendimento       ", '-');
            PrintText.ColorizeText("|7| ENCERRAR ATENDIMENTO", PrintText.TextColor.Gray);
            PrintText.ColorizeText("\n|>| ", PrintText.TextColor.White, 0);
            //----
            int menuOption = InputValidation.ValidateMenuOptionInput(1, 7);
            AuthenticatedScreen authScreen = new AuthenticatedScreen();
            authScreen.MenuAction(menuOption);
        }

        private void MenuAction(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1:
                    Deposit depositToAccount = new Deposit();
                    depositToAccount.DepositOperation(_clientAccount);
                    ShowAuthenticatedMenu();
                    break;
                case 2:
                    Withdraw withdrawFromAccount = new Withdraw();
                    withdrawFromAccount.WithdrawOperation(_clientAccount);
                    ShowAuthenticatedMenu();
                    break;
                case 3:
                    Transfer transferToAccount = new Transfer();
                    Transfer.TransferOperation(_clientAccount);
                    ShowAuthenticatedMenu();
                    break;
                case 4:
                    Console.WriteLine("NÃO IMPLEMENTADO.");
                    break;
                case 5:
                    Console.WriteLine("NÃO IMPLEMENTADO.");
                    break;
                case 6:
                    Console.WriteLine("NÃO IMPLEMENTADO.");
                    break;
                case 7:
                    StartScreen.ReturningToStartScreenMessage();
                    break;
                default:
                    ShowAuthenticatedMenu();
                    break;
            }
        }
        internal static void ReturningToAuthenticatedScreenMessage(int timer = 450)
        {
            PrintText.ColorizeText("\n[i] Retornando ao menu de operações", PrintText.TextColor.Yellow, 0);
            PrintTextAnimations.TreeDotsAnimation(timer);
            ShowAuthenticatedMenu();
        }
    }
}