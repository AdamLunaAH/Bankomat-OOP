using System.Collections.Generic;

namespace Bankomat_OOP
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

           
            List<Account> accountList = new List<Account>();

            // Exempel data som skapar några konto med data
            Account account1Example = new Account(12345, "Abc", 123, 2.56m, 20000, 50);
            accountList.Add(account1Example);
            Account account2Example = new Account(67890, "Def", 456, 4.52m, 15000, 30);
            accountList.Add(account2Example);

            int sortOption = 0;
            //int accountNrCheck;

            Console.WriteLine("Bankomat OOP\n");

            while (true)

            {

                Console.WriteLine("\nVälj en åtgärd:");

                Console.WriteLine("1. Gör en insättning på ett konto");

                Console.WriteLine("2. Gör ett uttag på ett konto");

                Console.WriteLine("3. Visa saldot på ett konto");

                Console.WriteLine("4. Skriv ut en lista på alla kontonr och saldon");

                Console.WriteLine("5. Skapa ett konto");

                Console.WriteLine("6. Avsluta konto");

                Console.WriteLine("7. Simulera 1 månads ränta på kontosaldon");

                Console.WriteLine("8. Kontoinformation med sortering");

                Console.WriteLine("9. Avsluta");

           
                string choice = Console.ReadLine();

                switch (choice)

                {

                    case "1":

                        //Insättning;
                        DepositClass.Deposit(accountList);

                        break;

                    case "2":

                        //Uttag

                        WithdrawClass.Withdraw(accountList);

                        break;

                    case "3":

                        //Kontosaldo

                        AccountBalanceClass.AccountBalance(accountList);

                        break;

                    case "4":

                        //Konton och saldon
                        AccountAndBalanceListClass.AccountAndBalanceList(accountList);

                        break;

                    case "5":

                        //Skapa konto

                        CreateAccountClass.CreateAccount(accountList);

                        break;

                    case "6":

                        //Avsluta konto

                        break;

                    case "7":

                        // Ränteuträkning
                        InterestCalculationClass.InterestCalculationUI(accountList);
                        break;

                    case "8":

                        // Kontoinformationsortering

                        AccountInfoWithSortClass.AccountInfoWithSortUI(accountList, sortOption);
                        break;

                    case "9":

                        return;

                    default:

                        Console.WriteLine("Ogiltigt val. Försök igen.");

                        break;

                }

            }   
        }

    }
    
}
