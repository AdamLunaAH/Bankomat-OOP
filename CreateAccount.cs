using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class CreateAccountClass
    {
        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public CreateAccountClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        // Metod för att skapa ett konto och lägga till det i kontolistan
        public void CreateAccount(List<Account> accountList)
        {
            Console.WriteLine("Skapa konto\n");
            // Idnummer
            int tempIdNr = AccountIdNr();
            // Kontonummer
            int tempAccountNr = AccountNr(accountList);
            // Kontonamn
            string tempAccountName = AccountName();
            // Kontosaldo
            decimal tempBalance = AccountBalance();
            // Ränta
            decimal tempInterestRate = AccountInterestRate();
            // Kredit
            decimal tempMaxCredit = AccountCredit(tempBalance);

            // Skapar ett nytt kontoobjekt
            Account account = new Account(tempAccountNr, tempAccountName, tempIdNr, tempBalance, tempInterestRate, tempMaxCredit);

            // Lägger till kontot i kontolistan
            accountList.Add(account);


            // Presenterar informationen på det nya kontot
            foreach (Account accounts in accountList)
            {
                if (accounts.AccountNr == tempAccountNr)
                {
                    Console.WriteLine("Det nya kontots information:");
                    Console.WriteLine($"Kontonummer: {accounts.AccountNr}\nKontonamn: {accounts.AccountName}\nIdnummer: {accounts.IdNr}\nSaldo: {accounts.Balance}\nRänta: {accounts.InterestRate}\nKreditgräns: {accounts.MaxCredit}\n");
                }
            }

            ExitToMenuClass.ExitToMenu();

        }

        // Skapa en Idnummer (till skillnad från kontonumret så behöver detta inte vara unikt)
        private int AccountIdNr()
        {
            Console.WriteLine("Skriv i Id-nummer:");
            int accountIdNrOk = 0;
            string tempIdNrStr = Console.ReadLine();

            // Input validering
            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(tempIdNrStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett nummer
                else if (!_inputValidator.IsNumber(tempIdNrStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }

                // Kollar om talet är negativt
                else if (_inputValidator.IsNumberNegative(tempIdNrStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else
                {
                    // Konverterar string till nummer
                    accountIdNrOk = _inputValidator.ConvertToInt(tempIdNrStr);
                    break;
                }

                // Om input är fel får man mata in ett nytt tal
                tempIdNrStr = Console.ReadLine();
            }

            return accountIdNrOk;
        }

        // Skapar ett slumpmässigt kontonummer med RandomNumberGenerator (Då detta är säkrare och mer "slumpmässigt" än Random)
        private int AccountNr(List<Account> accountList)
        {
            int accountNrOk;

            // Loopar om ett icke-unikt kontonummer skapdes
            do
            {
                accountNrOk = RandomAccountNumber();
            } while (accountList.Any(account => account.AccountNr == accountNrOk));

            return accountNrOk;
        }

        private int RandomAccountNumber()
        {
            int accountNumberInt;
            do
            {
                byte[] randomNumber = new byte[2];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                }

                accountNumberInt = BitConverter.ToInt16(randomNumber, 0);
            }
            // loopar tills ett nummer mellan 10000 och 99999 hittas
            while (accountNumberInt < 10000 || accountNumberInt > 99999);
            
            return accountNumberInt;
        }

        // Skapa en kontonamn
        private string AccountName()
        {
            Console.WriteLine("Skriv in kontonamn");
            string accountNameOk = Console.ReadLine().Trim();

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(accountNameOk))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else
                {
                    break;
                }
                // Om input är fel får man mata in ett nytt tal
                accountNameOk = Console.ReadLine();
            }

            return accountNameOk;
        }

        private decimal AccountBalance()
        {
            Console.WriteLine("Skriv in insättning");

            string tempBalanceStr = Console.ReadLine();
            decimal balanceOk;

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(tempBalanceStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett decimaltal (behöver inte innehålla decimaler)
                else if (!_inputValidator.IsNumberDecimal(tempBalanceStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                // Kollar om talet är negativt
                else if (_inputValidator.IsDecimalNegative(tempBalanceStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else
                {
                    balanceOk = _inputValidator.ConvertToDecimal(tempBalanceStr);
                    break;
                }

                // Om input är fel får man mata in ett nytt tal
                tempBalanceStr = Console.ReadLine();
            }

            return balanceOk;
        }

        private decimal AccountInterestRate()
        {
            Console.WriteLine("Ränta\n");
            decimal interestRateOk = 0;

            Console.WriteLine("Välj om räntan ska skapas automatiskt eller om en manuell ränta ska väljas.\n1. Automatisk ränta\n2. Manuell ränta");
            string menuInputStr = Console.ReadLine();

            int menuChoice = 0;
            while (true)
            {
                
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(menuInputStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett nummer
                else if (!_inputValidator.IsNumber(menuInputStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }
                else
                {
                    // Konverterar string till nummer
                    menuChoice = _inputValidator.ConvertToInt(menuInputStr);
                    break;
                }

            }

            switch (menuChoice)
            {
                case 1:
                    //Automatisk ränta;
                    interestRateOk = InterestRateAuto();
                    break;

                case 2:
                    //Manuell ränta
                    interestRateOk = InterestRateManual();
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    return AccountInterestRate();
            }
            return interestRateOk;

        }

        // Skapar en slumpmässig ränta med RandomNumberGenerator (Då detta är säkrare och mer "slumpmässigt" än Random)
        private decimal InterestRateAuto()
        {
            decimal accountInterest = RandomInterest();
            return accountInterest;

        }

        // Skapar en slumpmässig ränta med RandomNumberGenerator (Då detta är säkrare och mer "slumpmässigt" än Random)
        private decimal RandomInterest()
        {
            byte[] randomNumber = new byte[4];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            int randomInt = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue;

            // Räntan är mellen 0,00 och 5,00
            decimal accountInterest = (randomInt % 501) / 100.0m;
            return accountInterest;

        }

        // Hämtar och validerar användarens manuella input för räntesats
        private decimal InterestRateManual()
        {
            Console.WriteLine("Skriv in räntesats (0,00 — 5,00");

            decimal interestRateOk;
            string tempInterestRateStr = Console.ReadLine();

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(tempInterestRateStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett decimaltal (behöver inte innehålla decimaler)
                else if (!_inputValidator.IsNumberDecimal(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                // Kollar om talet är negativt
                else if (_inputValidator.IsDecimalNegative(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                // Kollar om talet är mellan 0,00 och 5,00
                else if (!_inputValidator.IsDecimalBetweenZeroAndFive(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett tal mellan 0,00 och 5,00 Försök igen");
                }
                else
                {
                    interestRateOk = _inputValidator.ConvertToDecimal(tempInterestRateStr);
                    break;
                }

                // Om input är fel får man mata in ett nytt tal
                tempInterestRateStr = Console.ReadLine();               
            }

            return interestRateOk;
         

        }

        // Hämtar och validerar användarens input för max kreditgräns
        private decimal AccountCredit(decimal tempBalance)
        {
            Console.WriteLine("Skriv i max kredit");
            string tempMaxCreditStr = Console.ReadLine();

            decimal maxCreditOk = 0;

            while (true)
            {
                // Kollar om input är tom
                if (_inputValidator.IsEmpty(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                // Kollar om input är ett decimaltal (behöver inte innehålla decimaler)
                else if (!_inputValidator.IsNumberDecimal(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                // Kollar om talet är negativt
                else if (_inputValidator.IsDecimalNegative(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                // Kollar om talet är större än saldot
                else if (_inputValidator.IsGreaterThanBalance(tempMaxCreditStr, tempBalance))
                {
                    Console.WriteLine("Beloppet överstiger kontosaldot. Försök igen.");
                }
                else
                {
                    maxCreditOk = _inputValidator.ConvertToDecimal(tempMaxCreditStr);
                    break;
                }

                // Om input är fel får man mata in ett nytt tal
                tempMaxCreditStr = Console.ReadLine();
            }



            return maxCreditOk;
        }
    }
}
