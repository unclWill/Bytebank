/* Classe  : AuthenticationScreen
 * Objetivo: Exibe a tela de autenticação de verificando se um Cliente existe no sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: 23/06/2023
 */

using System;
using Bytebank.Utils;

namespace Bytebank.AuthenticationComponents
{
    internal class AuthenticationScreen
    {
        //Fields
        //public Authentication authInfo;
        //Properties
        //public Authentication AuthenticationInfo { get; set; }
        // Constructor
        /*public AuthenticationScreen()
        {
            AuthenticationInfo = authInfo;
        }*/

        //Methods
        protected internal static void ShowAuthenticationDialog()
        {
            PrintText.ColorizeText("Informe o número da sua conta   : ", PrintText.TextColor.White, 0);
            string clientAccountId = Console.ReadLine()!;
            PrintText.ColorizeText("\nInforme o seu CPF (Nºs apenas)  : ", PrintText.TextColor.White, 0);
            string clientCpf = Console.ReadLine()!;
            PrintText.ColorizeText("\nInforme a sua senha de 4 dígitos: ", PrintText.TextColor.White, 0);
            int clientPassword = int.Parse(Console.ReadLine()!);

            Authentication clientInfo = new Authentication(clientAccountId, clientCpf, clientPassword);
            Authentication.IsAuthenticated(clientInfo);
        }

        /*private Authentication AuthenticateClient(Authentication clientAccountId, Authentication clientCpf, Authentication clientPassword)
        {
            return auth;
        }*/
    }
}