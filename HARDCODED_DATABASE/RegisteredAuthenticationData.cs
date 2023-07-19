/* Classe  : RegisteredAuthenticationData
 * Objetivo: Armazenar os dados de autenticação das contas existentes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 19/07/2023
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Bytebank.AuthenticationComponents;

namespace Bytebank.HARDCODED_DATABASE
{
    public class RegisteredAuthenticationData
    {
        internal RegisteredAuthenticationData()
        {
            RegisteredAuthData = registeredAuthData;
        }

        internal List<Authentication> RegisteredAuthData { get; set; }

        //Lista de dados de autenticação cadastrados.
        private List<Authentication> registeredAuthData = new List<Authentication>()
        {
            { new Authentication("1010-X", 15, 1234) },
            { new Authentication("1018-5", 17, 4321) },
            { new Authentication("8594-6", 16, 2468) },
        };
    }
}