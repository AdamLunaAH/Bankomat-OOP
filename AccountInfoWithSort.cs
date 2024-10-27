using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    // Klass till kontosorteringen
    public class AccountInfoWithSortClass
    {
        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public AccountInfoWithSortClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Sorteringsvalet
        public int SortOption { get; set; }

        // Konstruktor till sorteringsvalet
        public AccountInfoWithSortClass(int sortOption) { SortOption = sortOption; }

        // Menyvalsmetod
        public void AccountInfoWithSortUI(List<Account> accountList, int sortOption)
        {
            // Menyval
            Console.WriteLine("Kontoinformation med sortering\n\n1. Kontosaldo i fallande ordning\n2. Kontosaldo i stigande ordning\n3. Ränta i fallande ordning\n4 .Ränta i stigande ordning\n5. Avsluta\n");

            // Variabel till menyval för validering och menyval
            string menuInputStr;
            // Konverterad menuInputStr variabel för användning efter validering
            int menuChoice;

            while (true)
            {
                //Menyvalinmatning
                menuInputStr = Console.ReadLine();

                // Kollar om input är tom
                if (_inputValidator.IsEmpty(menuInputStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                    continue;
                }
                // Kollar om input är ett nummer
                else if (!_inputValidator.IsNumber(menuInputStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                    continue;
                }
                else
                {
                    // Konverterar string till nummer
                    menuChoice = _inputValidator.ConvertToInt(menuInputStr);
                    break;
                }
            }

            // Går tillbaka till menyn
            if (menuChoice == 5)
            {
                Console.WriteLine();
                return;
            }

            // Kör sorteringsfunktionen beroende på användarensval
            switch (menuChoice)
            {
                case 1:
                    sortOption = 1;
                    AccountInfoWithSort(accountList, sortOption);
                    break;

                case 2:
                    sortOption = 2;
                    AccountInfoWithSort(accountList, sortOption);
                    break;

                case 3:
                    sortOption = 3;
                    AccountInfoWithSort(accountList, sortOption);

                    break;

                case 4:
                    sortOption = 4;
                    AccountInfoWithSort(accountList, sortOption);
                    break;

                case 5:
                    break;

                default:
                    // Meddelande för ogiltigt val, anropar metoden igen för ny inmatning
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    AccountInfoWithSortUI(accountList, sortOption);
                    break;
            }

        }

        // Metod för att sortera och visa kontoinformation beroende på det valda sorteringsalternativ
        public static void AccountInfoWithSort(List<Account> accountList, int sortOption)
        {

            // Skapar en kopia av kontolistan för sortering
            List<Account> sortList = accountList;
            // Sorteringsval
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

            // Presenterar den sorterade kontolistan
            Console.WriteLine("Kontonr, Kontosaldo, Ränta");
            foreach (Account accounts in sortList)
            {
                Console.WriteLine($"{accounts.AccountNr} | {accounts.Balance} | {accounts.InterestRate}");
            }

            ExitToMenuClass.ExitToMenu();



        }
    }
}
