/* Classe  : HeaderTexts
 * Objetivo: Classe auxiliar para imprimir cabeçalhos com o logo do Bytebank, além de informações adicionais, de acordo com o contexto da tela.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 19/07/2023 (Criação) | Modificação: 19/07/2023
 */

using System;

namespace Bytebank.Utils
{
    internal static class HeaderText
    {
        internal static void BytebankLogoHeader()
        {
            Console.Clear();
            string bytebankLogo = @"
 ______                  _                 _     
(____  \       _        | |               | |    
 ____)  )_   _| |_  ____| | _   ____ ____ | |  _ 
|  __  (| | | |  _)/ _  ) || \ / _  |  _ \| | / )
| |__)  ) |_| | |_( (/ /| |_) | ( | | | | | |< ( 
|______/ \__  |\___)____)____/ \_||_|_| |_|_| \_)
        (____/";
            PrintText.ColorizeText(bytebankLogo, PrintText.TextColor.DarkMagenta);
            PrintText.SetLineBreak(1);
        }

        internal static void BytebankOperationsHeader()
        {
            BytebankLogoHeader();
            PrintText.DecoratedTitleText("  TERMINAL DE OPERAÇÕES FINANCEIRAS DO BYTEBANK  ", '~');
            PrintText.SetLineBreak(2);
        }
    }
}