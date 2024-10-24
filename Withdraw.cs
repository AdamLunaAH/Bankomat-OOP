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

            bool quit = false;

            foreach (Account accounts in accountList)
            {
                if (accountNrCheck == accounts.AccountNr)
                {

                    

                    while (quit == false) 
                    {
                        Console.WriteLine("Hur mycket ska tas ur?");
                        decimal withdrawCheck = decimal.Parse(Console.ReadLine());
                        if (withdrawCheck > accounts.Balance)
                        {
                            Console.WriteLine($"Uttag är större än kontosaldot\nTryck en knapp för att göra ett nytt uttag eller tryck q för att avsluta uttag.");
                            string withdrawRestart = Console.ReadLine();
                            if (withdrawRestart == "q") 
                            {
                               quit = true;
                            } 
                            
                        }
                        else 
                        {
                            accounts.Balance -= withdrawCheck;

                            Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                            quit = true;
                        }
                    }

                    //accounts.Balance -= withdrawCheck;

                    //Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                }
            }
        }
    }
}
