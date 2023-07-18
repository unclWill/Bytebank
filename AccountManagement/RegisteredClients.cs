using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytebank.AccountManagement
{
    internal class RegisteredClients
    {
        internal List<CurrentAccount> currentAccounts = new List<CurrentAccount>()
        {
            new CurrentAccount("1010-X", 15, "André Silva", 100d),
            new CurrentAccount("1018-5", 17, "Marisa Santos", 500d),
            new CurrentAccount("8594-6", 16, "Eustáquio Sodré", 1000d),
        };
    }
}