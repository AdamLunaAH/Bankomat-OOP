using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class BankMenuClass
    {


        private readonly InputValidator _inputValidator;
        private readonly DepositClass _deposit;
        private readonly WithdrawClass _withdraw;
        private readonly AccountBalanceClass _accountBalance;
        private readonly CreateAccountClass _createAccount;


        public BankMenuClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
            _deposit = new DepositClass(inputValidator);
            _withdraw = new WithdrawClass(inputValidator);
            _accountBalance = new AccountBalanceClass(inputValidator);
            _createAccount = new CreateAccountClass(inputValidator);
        }

        public void BankMenu(List<Account> accountList, int sortOption)
        {



            Console.WriteLine("Bankomat OOP\n");

            while (true)

            {

                Console.WriteLine("\nVälj en åtgärd:");

                Console.WriteLine("1. Gör en insättning på ett konto");

                Console.WriteLine("2. Gör ett uttag på ett konto");

                Console.WriteLine("3. Visa saldot på ett konto");

                Console.WriteLine("4. Skriv ut en lista på alla kontonr och saldon");

                Console.WriteLine("5. Skapa ett konto");

                Console.WriteLine("6. Avsluta konto");

                Console.WriteLine("7. Simulera 1 månads ränta på kontosaldon");

                Console.WriteLine("8. Kontoinformation med sortering");

                Console.WriteLine("9. Avsluta");

                string menuInputStr = Console.ReadLine();
                //int menuOutputInt = 0;

                int menuChoice;




                //MenuInputValidationClass.MenuInputValidation(menuInputStr);

                //int menuChoice = menuOutputInt;

                //string menuChoice = Console.ReadLine();

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

                 
                    BankMenu(accountList, sortOption);
                    //Console.Write("Välj ett giltigt alternativ: ");
                    //menuInputStr = Console.ReadLine();
                }



                switch (menuChoice)

                {

                    case 1:

                        //Insättning;

                        _deposit.Deposit(accountList);

                        break;

                    case 2:

                        //Uttag

                        _withdraw.Withdraw(accountList);

                        break;

                    case 3:

                        //Kontosaldo

                        _accountBalance.AccountBalance(accountList);

                        break;

                    case 4:

                        //Konton och saldon
                        AccountAndBalanceListClass.AccountAndBalanceList(accountList);

                        break;

                    case 5:

                        //Skapa konto

                        _createAccount.CreateAccount(accountList);

                        break;

                    case 6:

                        //Avsluta konto

                        break;

                    case 7:

                        // Ränteuträkning
                        InterestCalculationClass.InterestCalculationUI(accountList);
                        break;

                    case 8:

                        // Kontoinformationsortering

                        AccountInfoWithSortClass.AccountInfoWithSortUI(accountList, sortOption);
                        break;

                    case 9:

                        return;

                    default:

                        Console.WriteLine("Ogiltigt val. Försök igen.");

                        break;

                }

            }
        }
    }
}
