using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    internal class CreateAccountClass 
    {
        public static void CreateAccount(List<Account> accountList)
        {
            Console.WriteLine("Skapa konto\n");

            Console.WriteLine("Skriv i Id-nummer:");
            int tempIdNr = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Skriv i kontonummer");
            //int tempAccountNr = Int32.Parse(Console.ReadLine());

            Random rnd = new Random();

            int tempAccountNr = rnd.Next(1111,9999);

            Console.WriteLine("Skriv in kontonamn");
            string tempAccountName = Console.ReadLine();



            //Console.WriteLine("Skriv in räntesats");
            //decimal tempInterestRate = Decimal.Parse(Console.ReadLine());

            //double tempInterestRate = rnd.Next(-5,6);
            decimal rndNrNext = rnd.Next(0, 6);
            double rndNrNextDouble = rnd.NextDouble();
            decimal rndNrDec = Convert.ToDecimal(rndNrNextDouble);
            rndNrDec = Math.Round(rndNrDec, 2);

            decimal tempInterestRate = rndNrNext + rndNrDec; 

           


            Console.WriteLine("Skriv in insättning");
            decimal tempBalance = Decimal.Parse(Console.ReadLine());


            Console.WriteLine("Skriv i max kredit");
            decimal tempMaxCredit = Decimal.Parse(Console.ReadLine());



            Account account = new Account(tempAccountNr, tempAccountName, tempIdNr, tempInterestRate, tempBalance, tempMaxCredit);

            accountList.Add(account);



            foreach (Account accounts in accountList)
            {
                if (accounts.AccountNr == tempAccountNr) {
                    Console.WriteLine("Det nya kontots information:");
                    Console.WriteLine($"AccountNr: {accounts.AccountNr}\nAccountName: {accounts.AccountName}\nIdNr: {accounts.IdNr}\nInterestRate: {accounts.InterestRate}\nBalance: {accounts.Balance}\nMaxCredit: {accounts.MaxCredit}\n");
                }
                }
        }



    }
}
