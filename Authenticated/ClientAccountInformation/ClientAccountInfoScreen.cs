/* Classe  : ClientAccountInformationScreen
 * Objetivo: Exibir os dados pessoais do titular da Conta Corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 28/07/2023 (Criação) | Modificação: 28/07/2023
 */

using Bytebank.Clients;
using Bytebank.Utils;

namespace Bytebank.Authenticated.ClientAccountInformation
{
    /// <summary>
    /// Exibe a tela com os dados do titular (AccountHolder) da Conta Corrente.
    /// </summary>
    internal class ClientAccountInfoScreen
    {
        /// <summary>
        /// Exibe as informações gerais do titular da conta.
        /// </summary>
        internal static void ShowClientInformation(Client client)
        {
            HeaderText.BytebankOperationsHeader();
            PrintText.DecoratedTitleText(" Área do Cliente ", '*');
            client.ShowClientInfo();
            PrintText.SetLineBreak(1);
            PrintText.ColorizeText("Para voltar ao menu de operações digite |1|", PrintText.TextColor.Gray);
            int selectedOption = InputValidation.ValidateMenuOptionInput(1, 1);
            if (selectedOption == 1)
            {
                AuthenticatedScreen authScreen = new AuthenticatedScreen();
                authScreen.ReturningToAuthenticatedScreenMessage(1200);
            }
            else
            {
                PrintText.ColorizeText("Opção inválida!", PrintText.TextColor.Gray);
            }
        }
    }
}