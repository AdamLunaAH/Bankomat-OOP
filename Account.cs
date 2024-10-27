using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    public class Account
    {
        public int AccountNr { get; set; }

        public string AccountName { get; set; }

        public int IdNr { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxCredit { get; set; }



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
