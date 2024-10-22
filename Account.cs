using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class Account
    {
        public int AccountNr { get; set; }

        public required string AccountName { get; set; }

        public int IdNr { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Balance { get; set; }

        public decimal MaxCredit { get; set; }

    }
}
