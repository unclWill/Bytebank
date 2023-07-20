/* Classe  : Deposit
 * Objetivo: Concentrar as operações de depósito na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 19/07/2023
 */

using Bytebank.StartScreenComponents;
using Bytebank.AccountManagement;
using Bytebank.Utils;
using System.Reflection.Metadata.Ecma335;

namespace Bytebank.Authenticated.Operations
{
    internal class Deposit
    {
        internal decimal DepositOperation(CheckingAccount account)
        {
            HeaderTexts.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[+$] DEPÓSITO ", '*');
            PrintText.ColorizeText($"Seu saldo atual: {account.Balance:C}", PrintText.TextColor.DarkGray);
            PrintText.ColorizeText("Digite o valor que será depositado: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            decimal valueToDeposit = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            account.Deposit(valueToDeposit);
            PrintText.ColorizeText($"Valor adicionado à conta!\nValor atualizado: {account.Balance:C}", PrintText.TextColor.DarkGreen);
            PrintTextAnimations.TreeDotsAnimation(1000);
            return valueToDeposit;
        }
    }
}