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

            //Console.WriteLine($"AccountNr: {tempAccountNr}");

            string tempAccountName = AccountName();

            decimal tempBalance = AccountBalance();

            decimal tempInterestRate = AccountInterestRate();

            decimal tempMaxCredit = AccountCredit(tempBalance);

            //Console.WriteLine("Skriv i kontonummer");
            //int tempAccountNr = Int32.Parse(Console.ReadLine());
            //string accountNrCheck = Console.ReadLine();

            //while (true)
            //{
            //    if (_inputValidator.IsEmpty(accountNrCheck))
            //    {
            //        Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
            //    }
            //    else if (!_inputValidator.IsNumber(accountNrCheck))
            //    {
            //        Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
            //    }
            //    else
            //    {
            //        accountNrOk = _inputValidator.ConvertToInt(accountNrCheck);

            //        foreach (Account accounts in accountList)
            //        {
            //            if (accountNrOk == accounts.AccountNr)
            //            {
            //                Console.WriteLine("Kontonumret finns redan, tryck på en knapp för att försöka igen.");
            //                CreateAccount(accountList);
            //            }
            //        }
            //        break;
            //    }

            //    tempIdNrStr = Console.ReadLine();



            //var randomBytes = new byte[4];
            //using (var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(randomBytes);
            //    uint trueRandom = BitConverter.ToUInt32(randomBytes, 0);
            //}

            //    Random rnd = new Random();

            //int tempAccountNr = rnd.Next(1111,9999);



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
            //int tempIdNr = Int32.Parse(Console.ReadLine());
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
            //int accountNrOk = 0;

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
                //Console.Write("Välj ett giltigt alternativ: ");
                //menuInputStr = Console.ReadLine();
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




            //int accountInterest = RandomInterest();

            //static int RandomInterest()
            //{
            //    byte[] randomNumber = new byte[2];
            //    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            //    {
            //        rng.GetBytes(randomNumber);
            //    }

            //    int accountInterestInt = BitConverter.ToInt16(randomNumber, 0);

            //    return accountInterestInt % 90000 + 10000;
            //}

            //return accountInterest;

            decimal interestRateOk;
            decimal accountInterest = RandomInterest();

            static decimal RandomInterest()
            {
                byte[] randomNumber = new byte[4];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                }

                // Convert the bytes to a positive integer value
                int randomInt = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue; // Use bitwise AND to ensure positive

                // Scale the random integer to a range of 0.0 to 5.0
                decimal accountInterest = (randomInt % 501) / 100.0m;  // Dividing by 200 scales the range to 0.0 - 5.0
                return accountInterest;

            }

            return interestRateOk = accountInterest;


            //Console.WriteLine("Skriv in räntesats");
            //decimal tempInterestRate = Decimal.Parse(Console.ReadLine());
            //decimal tempInterestRate;
            //double tempInterestRatDouble = rnd.Next(-5, 6);
            //decimal rndNrNext = rnd.Next(0, 6);
            //double rndNrNextDouble = rnd.NextDouble();
            //decimal rndNrDec = Convert.ToDecimal(rndNrNextDouble);
            //rndNrDec = Math.Round(rndNrDec, 2);

            //tempInterestRate = rndNrNext + rndNrDec;
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
                //Console.Write("Välj ett giltigt alternativ: ");
                //menuInputStr = Console.ReadLine();
            }

            return interestRateOk;
            //double tempInterestRateDouble = rnd.Next(-5, 6);
            //decimal rndNrNext = rnd.Next(0, 6);
            //double rndNrNextDouble = rnd.NextDouble();
            //decimal rndNrDec = Convert.ToDecimal(rndNrNextDouble);
            //rndNrDec = Math.Round(rndNrDec, 2);

            //tempInterestRate = rndNrNext + rndNrDec;

        }

        private decimal AccountCredit(decimal tempBalance)
        {
            Console.WriteLine("Skriv i max kredit");
            //decimal tempMaxCredit = Decimal.Parse(Console.ReadLine());
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
