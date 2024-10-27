using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class BankMenuClass
    {
        // Används i list sorteringen
        int sortOption;

        // Instansvariabler för olika klasser, används för valideringsfunktionen
        private readonly InputValidator _inputValidator;
        private readonly DepositClass _deposit;
        private readonly WithdrawClass _withdraw;
        private readonly AccountBalanceClass _accountBalance;
        private readonly CreateAccountClass _createAccount;
        private readonly InterestCalculationClass _interestCalculationUI;
        private readonly WithdrawWithinCreditLimitClass _withdrawWithinCreditLimit;
        private readonly AccountInfoClass _accountInfo;
        private readonly DeleteAccountClass _deleteAccount;
        private readonly AccountInfoWithSortClass _accountInfoWithSort;

        // Konstruktor som initierar klasserna med validering funktionen
        public BankMenuClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
            _deposit = new DepositClass(inputValidator);
            _withdraw = new WithdrawClass(inputValidator);
            _accountBalance = new AccountBalanceClass(inputValidator);
            _createAccount = new CreateAccountClass(inputValidator);
            _interestCalculationUI = new InterestCalculationClass(inputValidator);
            _withdrawWithinCreditLimit = new WithdrawWithinCreditLimitClass(inputValidator);
            _accountInfo = new AccountInfoClass(inputValidator);
            _deleteAccount = new DeleteAccountClass(inputValidator);
            _accountInfoWithSort = new AccountInfoWithSortClass(inputValidator);
        }

        // Huvudmenyn
        public void BankMenu(List<Account> accountList/*, int sortOption*/)
        {
            Console.WriteLine("Bankomat OOP\n");

            // Loop som loopas tills användaren väljer att avsluta
            while (true)
            {
                // Menyval
                Console.WriteLine("\nVälj en åtgärd:");
                Console.WriteLine("1. Gör en insättning på ett konto");
                Console.WriteLine("2. Gör ett uttag på ett konto");
                Console.WriteLine("3. Gör ett uttag på ett konto inom kreditgränsen");
                Console.WriteLine("4. Visa saldot på ett konto");
                Console.WriteLine("5. Visa kontoinformationen på ett konto");
                Console.WriteLine("6. Skriv ut en lista på alla kontonr och saldon");
                Console.WriteLine("7. Simulera 1 månads ränta på kontosaldon");
                Console.WriteLine("8. Kontoinformation med sortering");
                Console.WriteLine("9. Skapa ett konto");
                Console.WriteLine("10. Avsluta konto");

                Console.WriteLine("11. Avsluta");

                // Menyval input
                string menuInputStr = Console.ReadLine();

                // Avslutar loopen
                if (menuInputStr == "11")
                {
                    Console.WriteLine("Programmet avslutas. Tack för att du använde Bankomaten.");
                    return;
                }

                int menuChoice;

                // Input-validering
                while (true)
                {
                    if (_inputValidator.IsEmpty(menuInputStr))
                    {
                        Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                        menuInputStr = Console.ReadLine();
                        if (menuInputStr == "11")
                        {
                            Console.WriteLine("Programmet avslutas. Tack för att du använde Bankomaten.");
                            return;
                        }
                    }
                    else if (!_inputValidator.IsNumber(menuInputStr))
                    {
                        Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                        menuInputStr = Console.ReadLine();
                        if (menuInputStr == "11")
                        {
                            Console.WriteLine("Programmet avslutas. Tack för att du använde Bankomaten.");
                            return;
                        }
                    }
                    else
                    {
                        // Konverterar input string till int
                        menuChoice = _inputValidator.ConvertToInt(menuInputStr);
                        break;
                    }
                }

                // switch för de olika meny-valen
                switch (menuChoice)
                {
                    case 1:
                        // Insättning
                        _deposit.Deposit(accountList);
                        break;

                    case 2:
                        // Uttag
                        _withdraw.Withdraw(accountList);
                        break;

                    case 3:
                        // Uttag med Kreditgräns
                        _withdrawWithinCreditLimit.WithdrawWithinCreditLimit(accountList);
                        break;

                    case 4:
                        // Visa saldot för ett konto
                        _accountBalance.AccountBalance(accountList);
                        break;

                    case 5:
                        // Visa kontoinformation för ett konto
                        _accountInfo.AccountInfo(accountList);
                        break;

                    case 6:
                        // Visar lista på konton och saldon
                        AccountAndBalanceListClass.AccountAndBalanceList(accountList);
                        break;

                    case 7:
                        // Ränteuträkning
                        _interestCalculationUI.InterestCalculationUI(accountList);
                        break;

                    case 8:
                        // Kontolista med sortering
                        _accountInfoWithSort.AccountInfoWithSortUI(accountList, sortOption);
                        break;

                    case 9:
                        // Skapa konto
                        _createAccount.CreateAccount(accountList);
                        break;

                    case 10:
                        // Avsluta konto
                        _deleteAccount.DeleteAccount(accountList);
                        break;

                        // Om input är ogiltligt
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}
