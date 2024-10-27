using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class DeleteAccountClass
    {

        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public DeleteAccountClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Metod för att ta bort ett konto från kontolistan
        public void DeleteAccount(List<Account> accountList)
        {
            // Variabel till kontonummer för validering och kontoval
            string accountNrCheck;
            // Konverterad accountNrCheck variabel för användning efter validering
            int accountNrOk = 0;


            Console.WriteLine("Avsluta konto");

            // Kontonummer inmatning
            Console.WriteLine("Vad är kontonumret på kontot som ska avslutas");
            accountNrCheck = Console.ReadLine();

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(accountNrCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett nummer
                else if (!_inputValidator.IsNumber(accountNrCheck))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }
                // Kollar om kontot finns
                else if (!_inputValidator.AccountExists(accountList, accountNrCheck))
                {
                    Console.WriteLine("Kontot finns inte. Försök igen");
                }
                else
                {
                    // Konverterar string till nummer
                    accountNrOk = _inputValidator.ConvertToInt(accountNrCheck);
                    break;
                }

                accountNrCheck = Console.ReadLine();

            }

            // Hämtar in kontot
            Account accountFound = accountList.FirstOrDefault(a => a.AccountNr == accountNrOk);

            // Konverterar kontosaldot till sträng
            string accountBalanceString = accountFound.Balance.ToString();

            while (true)
            {
                // Kollar om saldot är noll
                if (!_inputValidator.IsGreaterThanZero(accountBalanceString))
                {
                    // Om saldot inte är noll får anvädaren välja om kontot fortfarande ska avslutas
                    Console.WriteLine("Kontosaldot är inte 0, vill du fortfarande avsluta kontot\n1. Avsluta kontot\n2. Avbryt");
                    string deleteMenuStr = Console.ReadLine();
                    int deleteMenu;
                    while (true)
                    {
                        // Kollar om input är tom
                        if (_inputValidator.IsEmpty(deleteMenuStr))
                        {
                            Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                        }
                        // Kollar om input är ett nummer
                        else if (!_inputValidator.IsNumber(deleteMenuStr))
                        {
                            Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                        }
                        else
                        {
                            // Konverterar string till nummer
                            deleteMenu = _inputValidator.ConvertToInt(deleteMenuStr);
                            break;
                        }

                        // Om input är fel får man mata in ett nytt tal
                        accountNrCheck = Console.ReadLine();

                    }

                    switch (deleteMenu)

                    {
                        // Avslutar kontot
                        case 1:
                            accountList.Remove(accountFound);
                            Console.WriteLine($"Kontot med kontonummer {accountNrOk} har avslutats");
                            ExitToMenuClass.ExitToMenu();

                            return;
                        // Går till menyn
                        case 2:
                            return;

                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            return;



                    }
                }
                else
                {
                    // Om saldot var noll så avslutas kontot
                    accountList.Remove(accountFound);
                    break;
                }



            }

            // Meddelande som säger att kontot avslutats
            Console.WriteLine($"Kontot med kontonummer {accountNrOk} har avslutats");
            ExitToMenuClass.ExitToMenu();

        }
    }
}
