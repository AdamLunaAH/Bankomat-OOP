using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class AccountInfoClass
    {
        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public AccountInfoClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Kontoinformation metoden
        public void AccountInfo(List<Account> accountList)
        {
            // Variabel till kontonummer för validering och kontoval
            string accountNrCheck;
            // Konverterad accountNrCheck variabel för användning efter validering
            int accountNrOk = 0;
            Console.WriteLine("Kontoinformation");

            // Kontonummer inmatning
            Console.WriteLine("Vad är kontonumret på kontot som informationen ska visas");
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

                // Om input är fel får man mata in ett nytt tal
                accountNrCheck = Console.ReadLine();

            }


            // Hämta kontot som matchar det validerade kontonumret från kontolistan
            Account accountFound = accountList.FirstOrDefault(a => a.AccountNr == accountNrOk);


            // Skriv ut kontoinformation
            Console.WriteLine("Kontonummer| Kontonamn | Idnummer | Kontosaldo | Ränta | Kredit");
            Console.WriteLine($"{accountFound.AccountNr} | {accountFound.AccountName} | {accountFound.IdNr} | {accountFound.Balance} | {accountFound.InterestRate} | {accountFound.MaxCredit}");

            ExitToMenuClass.ExitToMenu();


        }
    }
}
