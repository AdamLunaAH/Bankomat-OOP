using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class DepositClass
    {

        private readonly InputValidator _inputValidator;

        public DepositClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        public void Deposit(List<Account> accountList) 
        {
            string accountNrCheck;
            int accountNrOk = 0;
            decimal depositCheckOk = 0;

            Console.WriteLine("Insättning");
            Console.WriteLine("Vad är kontonumret på kontot som insättningen ska utföras");
            accountNrCheck = Console.ReadLine();

            while (true)
            {
                if (_inputValidator.IsEmpty(accountNrCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumber(accountNrCheck))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                }
                else
                {
                    accountNrOk = _inputValidator.ConvertToInt(accountNrCheck);
                    break;
                }

                accountNrCheck = Console.ReadLine();
            }

            bool accountExists = false;
            foreach (Account accounts in accountList)
            {
                if (accountNrOk == accounts.AccountNr)
                {
                    accountExists = true;
                    break;
                }
            }

            if (!accountExists)
            {
                Console.WriteLine("Kontot finns inte.");
                return; 
            }

            Console.WriteLine("Hur mycket ska sättas in?");
            string depositCheck = Console.ReadLine();

            while (true)
            {
                if (_inputValidator.IsEmpty(depositCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumberDecimal(depositCheck))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                else if (_inputValidator.IsDecimalNegative(depositCheck))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else
                {
                    depositCheckOk = _inputValidator.ConvertToDecimal(depositCheck);
                    break;
                }

                depositCheck = Console.ReadLine();
            }

            foreach (Account accounts in accountList)
            {
                if (accountNrOk == accounts.AccountNr)
                {
                    accounts.Balance += depositCheckOk;
                    Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                    return;
                }
            }
        }
    }
}
