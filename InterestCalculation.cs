using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class InterestCalculationClass
    {

        public static void InterestCalculationUI(List<Account> accountList)
        {

            Console.WriteLine("Utför en ränteuträckning och uppdaterar saldot\n\n1. Utför ränteuträkning\n2. Gå tillbaka till menyn");
            string option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        InterestCalc(accountList);
                        break;

                    case "2":
                        break;

                    default:

                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        return;

                }
            

     
        }

        public static void InterestCalc(List<Account> accountList) 
        {
            Console.WriteLine("Visar det ursprungliga saldot, räntan och det nya saldot på kontona\nKonotnr, Saldo, Ränta, Nya saldot\n");
            foreach (Account account in accountList) 
            {
                decimal interestPercent = 0;
                decimal yearlyInterest = 0;
                decimal monthlyInterest = 0;
                decimal currentBalance = 0;

                currentBalance = account.Balance;

                interestPercent = account.InterestRate / 100;

                yearlyInterest = (account.Balance * interestPercent);


                monthlyInterest = Math.Round(yearlyInterest / 12);

                account.Balance += monthlyInterest;

                Console.WriteLine($"{account.AccountNr}, {currentBalance}, {account.InterestRate}, {account.Balance}");



            }

        
        }
    }
}
