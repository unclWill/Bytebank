/* Classe  : RegisteredAuthenticationData
 * Objetivo: Armazenar os dados de autenticação das contas existentes.
 * Autor   : unclWill (williamsilvajdf@gmail.com)
 * Data    : 18/07/2023 (Criação) | Modificação: 18/07/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Bytebank.AuthenticationComponents;

namespace Bytebank.HARDCODED_DATABASE
{
    public class RegisteredAuthenticationData
    {
        //Lista de dados de autenticação cadastrados.
        internal List<Authentication> registeredAuthData = new()
        {
            { new Authentication("1010-X", 15, 1234) },
            { new Authentication("1018-5", 17, 4321) },
            { new Authentication("8594-6", 16, 2468) },
        };
    }
}