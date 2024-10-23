using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class WithdrawClass
    {
        public static void Withdraw(List<Account> accountList) 
        {
            int accountNrCheck;
            Console.WriteLine("Uttag");

            Console.WriteLine("Vad är kontonumret på kontot som uttag ska utföras");
            accountNrCheck = Int32.Parse(Console.ReadLine());

            foreach (Account accounts in accountList)
            {
                if (accountNrCheck == accounts.AccountNr)
                {
                    Console.WriteLine("Hur mycket ska tas ur?");

                    decimal withdrawCheck = decimal.Parse(Console.ReadLine());

                    accounts.Balance -= withdrawCheck;

                    Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                }
            }
        }
    }
}
