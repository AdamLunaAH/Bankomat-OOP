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
        private readonly InputValidator _inputValidator;

        public CreateAccountClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }


        public void CreateAccount(List<Account> accountList)
        {
            Console.WriteLine("Skapa konto\n");

            int tempIdNr = AccountIdNr();

            int tempAccountNr = AccountNr();


            string tempAccountName = AccountName();

            decimal tempBalance = AccountBalance();

            decimal tempInterestRate = AccountInterestRate();

            decimal tempMaxCredit = AccountCredit(tempBalance);

            Account account = new Account(tempAccountNr, tempAccountName, tempIdNr, tempBalance, tempInterestRate, tempMaxCredit);

            accountList.Add(account);



            foreach (Account accounts in accountList)
            {
                if (accounts.AccountNr == tempAccountNr)
                {
                    Console.WriteLine("Det nya kontots information:");
                    Console.WriteLine($"AccountNr: {accounts.AccountNr}\nAccountName: {accounts.AccountName}\nIdNr: {accounts.IdNr}\nBalance: {accounts.Balance}\nInterestRate: {accounts.InterestRate}\nMaxCredit: {accounts.MaxCredit}\n");
                }
            }
        }












        private int AccountIdNr()
        {
            Console.WriteLine("Skriv i Id-nummer:");
            int accountIdNrOk = 0;
            string tempIdNrStr = Console.ReadLine();

            while (true)
            {
                if (_inputValidator.IsEmpty(tempIdNrStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumber(tempIdNrStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }
                else
                {
                    accountIdNrOk = _inputValidator.ConvertToInt(tempIdNrStr);
                    break;
                }

                tempIdNrStr = Console.ReadLine();
            }

            return accountIdNrOk;
        }

        private static int AccountNr()
        {

            int accountNrOk = RandomAccountNumber();

            static int RandomAccountNumber()
            {
                byte[] randomNumber = new byte[2];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                }

                int accountNumberInt = BitConverter.ToInt16(randomNumber, 0);

                return accountNumberInt % 90000 + 10000;
            }

            return accountNrOk;
        }

        private string AccountName()
        {
            Console.WriteLine("Skriv in kontonamn");
            string accountNameOk = Console.ReadLine().Trim();

            while (true)
            {
                if (_inputValidator.IsEmpty(accountNameOk))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else
                {
                    break;
                }
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
                if (_inputValidator.IsEmpty(tempBalanceStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumberDecimal(tempBalanceStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                else if (_inputValidator.IsDecimalNegative(tempBalanceStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else
                {
                    balanceOk = _inputValidator.ConvertToDecimal(tempBalanceStr);
                    break;
                }

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

            int menuChoice;
            while (true)
            {
                if (_inputValidator.IsEmpty(menuInputStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumber(menuInputStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }
                else
                {
                    menuChoice = _inputValidator.ConvertToInt(menuInputStr);
                    break;
                }


                AccountInterestRate();
        
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
                    AccountInterestRate();
                    break;

            }
            return interestRateOk;


        }

        private decimal InterestRateAuto()
        {




           

            decimal interestRateOk;
            decimal accountInterest = RandomInterest();

            static decimal RandomInterest()
            {
                byte[] randomNumber = new byte[4];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                }

                int randomInt = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue;

                
                decimal accountInterest = (randomInt % 501) / 100.0m; 
                return accountInterest;

            }

            return interestRateOk = accountInterest;


        
        }

        private decimal InterestRateManual()
        {
            Console.WriteLine("Skriv in räntesats (0,00 — 5,00");

            decimal interestRateOk;
            string tempInterestRateStr = Console.ReadLine();

            while (true)
            {
                if (_inputValidator.IsEmpty(tempInterestRateStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumberDecimal(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                else if (_inputValidator.IsDecimalNegative(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else if (!_inputValidator.IsDecimalBetweenZeroAndFive(tempInterestRateStr))
                {
                    Console.WriteLine("Valet måste vara ett tal mellan 0 och 5. Försök igen");
                }
                else
                {
                    interestRateOk = _inputValidator.ConvertToDecimal(tempInterestRateStr);
                    break;
                }


                InterestRateManual();
                
            }

            return interestRateOk;
         

        }

        private decimal AccountCredit(decimal tempBalance)
        {
            Console.WriteLine("Skriv i max kredit");
            string tempMaxCreditStr = Console.ReadLine();

            decimal maxCreditOk = 0;

            while (true)
            {
                if (_inputValidator.IsEmpty(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumberDecimal(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                else if (_inputValidator.IsDecimalNegative(tempMaxCreditStr))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else if (_inputValidator.IsGreaterThanBalance(tempMaxCreditStr, tempBalance))
                {
                    Console.WriteLine("Beloppet överstiger kontosaldot. Försök igen.");
                }
                else
                {
                    maxCreditOk = _inputValidator.ConvertToDecimal(tempMaxCreditStr);
                    break;
                }

                tempMaxCreditStr = Console.ReadLine();
            }



            return maxCreditOk;
        }
    }
}
