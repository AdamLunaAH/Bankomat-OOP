using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bankomat_OOP
{
    internal class Program
    {
        

        static void Main(string[] args)
        {


            List<Account> accountList = new List<Account>();

            InputValidator inputValidator = new InputValidator();

            BankMenuClass bankMenu = new BankMenuClass(inputValidator);

           ;

            // Exempel data som skapar några konto med data
            Account account1Example = new Account(12345, "Abc", 123, 2.56m, 20000, 50);
            accountList.Add(account1Example);
            Account account2Example = new Account(67890, "Def", 456, 4.52m, 15000, 30);
            accountList.Add(account2Example);

            int sortOption = 0;

            bankMenu.BankMenu(accountList, sortOption);

        }

       
    }
    
}
