using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class CreateAccount 
    {
        public int AccountNr { get; set; }
        public required string AccountName { get; set; }
        public int IdNr { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxCredit { get; set; }


        public CreateAccount(int accountNr, string accountName, int idNr, decimal interestRate, decimal balance, decimal maxCredit)
        {
            AccountNr = accountNr;
            AccountName = accountName;
            IdNr = idNr;
            InterestRate = interestRate;
            Balance = balance;
            MaxCredit = maxCredit;

            void AddIdNr()
            {
                Console.WriteLine("Skriv i Id-nummer");

                idNr = Int32.Parse(Console.ReadLine());

            }

            void AddAccountNr()
            { 
                Console.WriteLine("Skriv i kontonummer"); 
                accountNr = Int32.Parse(Console.ReadLine());
            }

            void AddAccountName() 
            {
                Console.WriteLine("Skriv in kontonummer");
                accountName = Console.ReadLine();
            }

            void AddInterestRate() 
            {
                Console.WriteLine("Skriv in kontnummer");
                interestRate = Decimal.Parse(Console.ReadLine());
            }

            void AddBalance() 
            {
                Console.WriteLine("Skriv in insättning");
                balance = Decimal.Parse(Console.ReadLine());
            }

            //void RemoveBalance() 
            //{   
            //    Console.WriteLine("Skriv in Uttag");
            //    balance = Decimal.Parse(Console.ReadLine());
            //}
        }

        
    }
}
