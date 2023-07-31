/* Classe  : AuthenticatedScreen
 * Objetivo: Concentra os métodos utilizados na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 30/07/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.Utils;
using Bytebank.Clients;
using Bytebank.Authenticated.Operations;
using Bytebank.Authenticated.ClientAccountInformation;

namespace Bytebank.Authenticated
{
    /// <summary>
    /// Define os comportamentos presentes na área logada do sistema.
    /// </summary>
    internal class AuthenticatedScreen
    {
        /// <summary>
        /// Recebe os dados de uma instância de CheckingAccount (Conta Corrente), que é o cliente que foi autenticado no sistema.
        /// Toda a operação dentro do sistema ocorre baseada nesta conta.
        /// </summary>
        private Client? _clientAccount;

        /// <summary>
        /// Construtor da classe AuthenticatedScreen que recebe um Client (Conta do Cliente) como parâmetro para que os dados da conta sejam passados para o campo _clientAccount.
        /// <code>Após passar os dados da instância o construtor chama o método ShowAuthenticatedMenu que exibe as opções para utilização da Conta Corrente pelo cliente.</code>
        /// </summary>
        /// <param name="clientAccount">Recebe os dados do cliente que foi autenticada no sistema.</param>
        /// <exception cref="ArgumentNullException">Lança uma exceção se a conta for nula.</exception>
        internal AuthenticatedScreen(Client clientAccount)
        {
            _clientAccount = clientAccount ?? throw new ArgumentNullException(nameof(clientAccount), "A instância deste conta está nula.");
            ShowAuthenticatedMenu();
        }

        internal AuthenticatedScreen() { }

        /// <summary>
        /// Exibe uma mensagem com uma animação que indica que o sistema está retornando para a tela principal do menu de operações.
        /// </summary>
        /// <param name="timer">Recebe o tempo que levará cada ciclo até a o método ter sido completamente executado.</param>
        internal void ReturningToAuthenticatedScreenMessage(int timer = 450)
        {
            PrintText.ColorizeText("\n[i] Retornando ao menu de operações", PrintText.TextColor.Yellow, 0);
            PrintTextAnimations.TreeDotsAnimation(timer);
            AuthenticatedScreen authScreen = new AuthenticatedScreen();
            authScreen.ShowAuthenticatedMenu();
        }

        /// <summary>
        /// Exibe o menu de operações com as opções disponíveis para o cliente.
        /// </summary>
        internal void ShowAuthenticatedMenu()
        {
            HeaderText.BytebankOperationsHeader();
            //----
            _clientAccount!.CheckingAccount!.ShowClientAccountOverview();
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
            MenuAction(menuOption);
        }

        /// <summary>
        /// Leva o cliente (usuário do sistema) para a tela da opção escolhida.
        /// </summary>
        /// <param name="selectedOption">Recebe o número da opção do menu que o cliente digitou.</param>
        private void MenuAction(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1:
                    DepositScreen.DepositOperation(_clientAccount!);
                    break;
                case 2:
                    WithdrawScreen.WithdrawOperation(_clientAccount!);
                    break;
                case 3:
                    TransferScreen.TransferOperation(_clientAccount!);
                    break;
                case 4:
                    ClientAccountInfoScreen.ShowClientInformation(_clientAccount!);
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
    }
}