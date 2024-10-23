using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class DepositClass
    {
        public static void Deposit(List<Account> accountList) 
        {
            int accountNrCheck;
            Console.WriteLine("Insättning");

            Console.WriteLine("Vad är kontonumret på kontot som insättningen ska utföras");
            accountNrCheck = Int32.Parse(Console.ReadLine());

            foreach (Account accounts in accountList)
            {
                if (accountNrCheck == accounts.AccountNr)
                {
                    Console.WriteLine("Hur mycket ska sättas in?");

                    decimal depositCheck = decimal.Parse(Console.ReadLine());

                    accounts.Balance += depositCheck;

                    Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                }
            }

        }
    }
}
