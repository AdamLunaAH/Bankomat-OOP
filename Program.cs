using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bankomat_OOP
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            // Skapar en lista som sparar kontoinfromation
            List<Account> accountList = new List<Account>();

            // Initierar input validering
            InputValidator inputValidator = new InputValidator();

            // Initierar menyn
            BankMenuClass bankMenu = new BankMenuClass(inputValidator);

           ;

            // Exempel data som skapar några konto med data
            Account account1Example = new Account(12345, "Abc", 123, 20000, 2.56m, 50);
            accountList.Add(account1Example);
            Account account2Example = new Account(67890, "Def", 456, 15000, 4.52m, 30);
            accountList.Add(account2Example);

            // Kör menyn
            bankMenu.BankMenu(accountList);

        }

       
    }
    
}
