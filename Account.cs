using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    // Kontoklass
    public class Account
    {
        // Kontonummer
        public int AccountNr { get; set; }
        
        // Kontonamn
        public string AccountName { get; set; }

        // Idnummer
        public int IdNr { get; set; }

        // Saldo
        public decimal Balance { get; set; }
        // Ränta
        public decimal InterestRate { get; set; }
      
        // Kreditgräns
        public decimal MaxCredit { get; set; }


        // Konstruktor som används för att skapa ett konto
        public Account(int accountNr, string accountName, int idNr, decimal balance, decimal interestRate, decimal maxCredit) 
        {
            AccountNr = accountNr;
            AccountName = accountName;
            IdNr = idNr;
            Balance = balance;
            InterestRate = interestRate;
            MaxCredit = maxCredit;
        }

        
    }
}
