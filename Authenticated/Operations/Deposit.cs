using Bytebank.StartScreenComponents;
using Bytebank.AccountManagement;
using Bytebank.Utils;
using System.Reflection.Metadata.Ecma335;

namespace Bytebank.Authenticated.Operations
{
    internal class Deposit
    {
        internal decimal DepositOperation(CheckingAccount checkingAccount)
        {
            HeaderTexts.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("DEPÓSITO", '*');
            PrintText.ColorizeText("Digite o valor que será depositado: ", PrintText.TextColor.White, 0);
            decimal valueToDeposit = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            checkingAccount.Deposit(valueToDeposit);
            PrintText.ColorizeText($"Valor adicionado à conta!\nValor atualizado: {checkingAccount.Balance:C}", PrintText.TextColor.DarkGreen);
            PrintTextAnimations.TreeDotsAnimation(1000);
            //AuthenticatedScreen.ShowAuthenticatedMenu();
            return valueToDeposit;
        }
    }
}