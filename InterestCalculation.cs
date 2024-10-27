using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class InterestCalculationClass
    {
        // Deklarerar och används för att validera input
        private readonly InputValidator _inputValidator;

        // Konstruktor till inputvalidering
        public InterestCalculationClass(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }
        // Metod till menyn för ränteuträkning
        public void InterestCalculationUI(List<Account> accountList)
        {
            Console.WriteLine("Utför en ränteuträckning och uppdaterar saldot\n\n1. Utför ränteuträkning\n2. Gå tillbaka till menyn");

            // Variabel till menyval för validering och menyval
            string menuInputStr;
            // Konverterad menuInputStr variabel för användning efter validering
            int menuChoice;

            // Loop som loopas tills användaren väljer att avsluta
            while (true)
            {
                // Menyvals inmatning
                menuInputStr = Console.ReadLine(); 

                // Kollar om input är tom
                if (_inputValidator.IsEmpty(menuInputStr))
                {
                    Console.WriteLine("Valet kan inte vara tomt. Försök igen.");
                    continue; 
                }
                // Kollar om input är ett nummer
                else if (!_inputValidator.IsNumber(menuInputStr))
                {
                    Console.WriteLine("Valet måste vara ett nummer. Försök igen.");
                    continue; 
                }
                else
                {
                    // Konverterar string till nummer
                    menuChoice = _inputValidator.ConvertToInt(menuInputStr);
                    break; 
                }
            }

            // Avslutar loopen
            if (menuChoice == 2)
            {
                Console.WriteLine();
                return; 
            }

            // switch för de olika meny-valen
            switch (menuChoice)
            {
                case 1:
                    // Ränteutträkning
                    InterestCalc(accountList);
                    break;
                default:
                    // Om input är ogiltligt
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    InterestCalculationUI(accountList); 
                    break;
            }
        }

        // Metod för att beräkna ränta och uppdatera kontobalansen
        public void InterestCalc(List<Account> accountList)
        {

            Console.WriteLine("Visar det ursprungliga saldot, räntan och det nya saldot på kontona\nKonotnr, Saldo, Ränta, Nya saldot\n");
            // Loopar genom varje konto i listan
            foreach (Account account in accountList)
            {
                // Variabler för att lagra och presentera räntor och saldon
                decimal interestPercent = 0;
                decimal yearlyInterest = 0;
                decimal monthlyInterest = 0;
                decimal currentBalance = 0;

                // Hämtar nuvarande saldot
                currentBalance = account.Balance;

                // Hämtar nuvarande räntan och konvertera den till procent
                interestPercent = account.InterestRate / 100;

                // Multiplicera saldot med räntan för att få fram årsräntan
                yearlyInterest = (account.Balance * interestPercent);

                // Dividera årsräntan för att få fram månadsräntan
                monthlyInterest = Math.Round(yearlyInterest / 12);

                // Uppdatera saldot med adderingen av månadsränta
                account.Balance += monthlyInterest;

                // Presentera det gamla och nya saldot
                Console.WriteLine($"{account.AccountNr}, {currentBalance}, {account.InterestRate}, {account.Balance}");



            }
            ExitToMenuClass.ExitToMenu();

        }
    }
}
