using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class WithdrawWithinCreditLimitClass
    {

        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public WithdrawWithinCreditLimitClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Metod för att hantera uttag från ett konto med kreditgräns.
        public void WithdrawWithinCreditLimit(List<Account> accountList)
        {
            // Variabel till kontonummer för validering och kontoval
            string accountNrCheck;
            // Konverterad accountNrCheck variabel för användning efter validering
            int accountNrOk = 0;
            // Variabel för att lagra det validerade uttagsbeloppet.
            decimal withdrawCheckOk = 0;

            Console.WriteLine("Uttag");

            // Kontonummer inmatning
            Console.WriteLine("Vad är kontonumret på kontot som uttag ska utföras");
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
            Console.WriteLine("Hur mycket ska tas ur?");
            string withdrawCheck = Console.ReadLine();

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(withdrawCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett decimaltal (behöver inte innehålla decimaler)
                else if (!_inputValidator.IsNumberDecimal(withdrawCheck))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                // Kollar om input är ett positivt tal
                else if (_inputValidator.IsDecimalNegative(withdrawCheck))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                // Kollar om uttagsbelopet är större än kreditgränsen
                else if (_inputValidator.IsGreaterThanBalance(withdrawCheck, accountFound.MaxCredit))
                {
                    Console.WriteLine("Beloppet överstiger Kreditgränsen. Försök igen.");
                }
                // Kollar om uttagsbelopet är större än kontosaldot
                else if (_inputValidator.IsGreaterThanBalance(withdrawCheck, accountFound.Balance))
                {
                    Console.WriteLine("Beloppet överstiger Saldot. Försök igen.");
                }
                else
                {
                    // Konverterar string till nummer
                    withdrawCheckOk = _inputValidator.ConvertToDecimal(withdrawCheck);
                    break;
                }
                // Om input är fel får man mata in ett nytt tal
                withdrawCheck = Console.ReadLine();

            }


            // Uppdaterar saldot till det nya saldot, och presenterar det ny saldot.
            accountFound.Balance -= withdrawCheckOk;
            Console.WriteLine($"Nya saldot för konto {accountFound.AccountNr} är {accountFound.Balance}");
            ExitToMenuClass.ExitToMenu();

            return;


        }
    }
}
