/* Classe  : Withdraw
 * Objetivo: Concentrar as operações de saque na conta corrente.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 19/07/2023
 */

using System;
using Bytebank.AccountManagement;
using Bytebank.Utils;

namespace Bytebank.Authenticated.Operations
{
    internal class Withdraw
    {
        internal decimal WithdrawOperation(CheckingAccount account)
        {
            HeaderTexts.BytebankOperationsHeader();
            PrintText.DecoratedTitleText("[-$] SAQUE ", '*');
            PrintText.ColorizeText("Digite o valor que deseja sacar: ", PrintText.TextColor.White);
            PrintText.UserInteractionIndicator();
            decimal valueToWithdraw = decimal.Parse(Console.ReadLine()!.Replace('.', ','));
            account.Withdraw(valueToWithdraw);
            PrintText.ColorizeText($"Valor sacado da conta!\nValor atualizado: {account.Balance:C}", PrintText.TextColor.DarkYellow);
            PrintTextAnimations.TreeDotsAnimation(1000);
            return valueToWithdraw;
        }
    }
}