/* Classe  : Client
 * Objetivo: Concentra as lógicas de criação de clientes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 27/06/2023 (Criação) | Modificação: 27/07/2023
 */

using System;

namespace Bytebank.AccountManagement
{
    public class Client
    {
        public string? AccountHolder { get; set; }
        public string? Cpf { get; set; }
        public string? Profession { get; set; }

    }
}