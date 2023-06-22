/* Classe  : Authentication
 * Objetivo: Concentra os métodos de autenticação para permitir que o usuário entre na área logada do sistema.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 22/06/2023 (Criação) | Modificação: DD/MM/AAAA
 */

using System;
using Bytebank.Utils;

namespace Bytebank.Authentication
{
    public class Authentication
    {
        //Fields

        //Properties
        public string AuthenticateClientAccountID { get; set; }
        public int AuthenticateClientPassword { get; set; }
        public int AuthenticateClientCpf { get; set; }

        //Constructor
        public Authentication(string client, int password, int cpf)
        {
            AuthenticateClientAccountID = client;
            AuthenticateClientPassword = password;
            AuthenticateClientCpf = cpf;
        }
        //Methods
    }
}