using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class AccountBalanceClass
    {
        private readonly InputValidator _inputValidator;

        public AccountBalanceClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        public void AccountBalance(List<Account> accountList) 
        {

            string accountNrCheck;
            int accountNrOk = 0;
            Console.WriteLine("Kontosaldo");

            Console.WriteLine("Vad är kontonumret på kontot som saldot ska visas");
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

            foreach (Account accounts in accountList)
            {
                if (accountNrOk == accounts.AccountNr)
                {
                    Console.WriteLine($"Saldot på kontot {accounts.AccountNr} är {accounts.Balance}");
                }
            }
        }
    }
}
