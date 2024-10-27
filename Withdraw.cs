using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class WithdrawClass
    {

        private readonly InputValidator _inputValidator;

        public WithdrawClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        public void Withdraw(List<Account> accountList)
        {
            string accountNrCheck;
            int accountNrOk = 0;
            decimal withdrawCheckOk = 0;

            Console.WriteLine("Uttag");

            Console.WriteLine("Vad är kontonumret på kontot som uttag ska utföras");
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


            Account accountFound = accountList.FirstOrDefault(a => a.AccountNr == accountNrOk);
            if (accountFound == null)
            {
                Console.WriteLine("Kontot finns inte.");
                return;
            }

       


            Console.WriteLine("Hur mycket ska tas ur?");
            string withdrawCheck = Console.ReadLine();

            while (true)
            {
                if (_inputValidator.IsEmpty(withdrawCheck))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                }
                else if (!_inputValidator.IsNumberDecimal(withdrawCheck))
                {
                    Console.WriteLine("Valet måste vara ett decimaltal. Försök igen.");
                }
                else if (_inputValidator.IsDecimalNegative(withdrawCheck))
                {
                    Console.WriteLine("Valet måste vara ett positivt tal. Försök igen");
                }
                else if (_inputValidator.IsGreaterThanBalance(withdrawCheck, accountFound.Balance))
                {
                    Console.WriteLine("Beloppet överstiger kontosaldot. Försök igen.");
                }
                else
                {
                    withdrawCheckOk = _inputValidator.ConvertToDecimal(withdrawCheck);
                    break;
                }

                withdrawCheck = Console.ReadLine();

            }

            foreach (Account accounts in accountList)
            {
                if (accountNrOk == accounts.AccountNr)
                {
                    accounts.Balance -= withdrawCheckOk;
                    Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                    return;
                }
            }

        }
    }
}
