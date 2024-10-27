using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    // Insättningsklass
    internal class DepositClass
    {

        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public DepositClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Metod för att hantera insättning på ett konto.
        public void Deposit(List<Account> accountList) 
        {
            // Variabel till kontonummer för validering och kontoval
            string accountNrCheck;
            // Konverterad accountNrCheck variabel för användning efter validering
            int accountNrOk = 0;
            // Variabel för att lagra det validerade insättningsbeloppet.
            decimal depositCheckOk = 0;

            Console.WriteLine("Insättning");
            // Kontonummer inmatning
            Console.WriteLine("Vad är kontonumret på kontot som insättningen ska utföras");
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

            // Letar efter kontot i listan med det validerade kontonumret.
            Account accountFound = accountList.FirstOrDefault(a => a.AccountNr == accountNrOk);

            // Belopp inmatning
            Console.WriteLine("Hur mycket ska sättas in?");
            string depositCheck = Console.ReadLine();

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(depositCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett decimaltal (behöver inte innehålla decimaler)
                else if (!_inputValidator.IsNumberDecimal(depositCheck))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                // Kollar om input är ett positivt tal
                else if (_inputValidator.IsDecimalNegative(depositCheck))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                // Kollar om beloppet är noll
                else if (_inputValidator.IsGreaterThanZero(depositCheck))
                {
                    Console.WriteLine("Beloppet är 0. Försök igen.");
                }
                else
                {
                    // Konverterar string till nummer
                    depositCheckOk = _inputValidator.ConvertToDecimal(depositCheck);
                    break;
                }

                depositCheck = Console.ReadLine();
            }

            // Uppdaterar saldot till det nya saldot, och presenterar det ny saldot.
            accountFound.Balance += depositCheckOk;
            Console.WriteLine($"Nya saldot för konto {accountFound.AccountNr} är {accountFound.Balance}");
            ExitToMenuClass.ExitToMenu();

        }
    }
}
