using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class AccountBalanceClass
    {

        public static void AccountBalance(List<Account> accountList) 
        {

            int accountNrCheck;
            Console.WriteLine("Kontosaldo");

            Console.WriteLine("Vad är kontonumret på kontot som saldot ska visas");
            accountNrCheck = Int32.Parse(Console.ReadLine());

            foreach (Account accounts in accountList)
            {
                if (accountNrCheck == accounts.AccountNr)
                {
                    Console.WriteLine($"Saldot på kontot {accounts.AccountNr} är {accounts.Balance}");
                }
            }
        }
    }
}
