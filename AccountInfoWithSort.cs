using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    public class AccountInfoWithSortClass
    {
        private int SortOption { get; set; }

        public AccountInfoWithSortClass(int sortOption) { SortOption = sortOption; }

        public static void AccountInfoWithSortUI(List<Account> accountList, int sortOption)
        {

            Console.WriteLine("Kontoinformation med sortering\n\n1. Kontosaldo i fallande ordning\n2. Kontosaldo i stigande ordning\n3. Ränta i fallande ordning\n4 .Ränta i stigande ordning\n5. Avsluta\n");
            string option = Console.ReadLine();
            switch (option)
            {

                case "1":
                    sortOption = 1;
                    AccountInfoWithSort(accountList, sortOption);
                    break;

                case "2":
                    sortOption = 2;
                    AccountInfoWithSort(accountList, sortOption);
                    break;
            
                case "3":
                    sortOption = 3;
                    AccountInfoWithSort(accountList, sortOption);

                    break;

                case "4":
                    sortOption = 4;
                    AccountInfoWithSort(accountList, sortOption);
                    break;

                default:

                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    return;


            }

        }

        public static void AccountInfoWithSort(List<Account> accountList, int sortOption)
        {

            List<Account> sortList = accountList;
            switch (sortOption)
            {

                case 1:
                    Console.WriteLine("Kontosaldo i fallande ordning\n");
                    sortList = sortList.OrderByDescending(a => a.Balance).ToList();
                    break;

                case 2:
                    Console.WriteLine("Kontosaldo i stigande ordning\n");
                    sortList = sortList.OrderBy(a => a.Balance).ToList();
                    break;

                case 3:
                    Console.WriteLine("Ränta i fallande ordning\n");
                    sortList = sortList.OrderByDescending(a => a.InterestRate).ToList();
                    break;

                case 4:
                    Console.WriteLine("Ränta i stigande ordning\n");
                    sortList = sortList.OrderBy(a => a.InterestRate).ToList();
                    break;

                default:
                    Console.WriteLine("Något gick fel");
                    break;

            }

            
            Console.WriteLine("Kontonr, Kontosaldo, Ränta");
            foreach (Account accounts in sortList)
            {
                Console.WriteLine($"{accounts.AccountNr} | {accounts.Balance} | {accounts.InterestRate}");
            }

            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
            Console.ReadKey();

            
        }
    }
}
