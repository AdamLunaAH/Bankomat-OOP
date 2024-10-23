using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class AccountAndBalanceListClass
    {
        public static void AccountAndBalanceList(List<Account> accountList) {
            Console.WriteLine("Kontonnummer och kontosaldon\n");

            foreach (Account accounts in accountList)
            {
                Console.WriteLine($"Kontonr: {accounts.AccountNr}\nKontosaldo: {accounts.Balance}\n");
            }

        }
    }
}
