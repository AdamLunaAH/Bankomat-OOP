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

        //static CreateAccounts()
        //{
        //    //CreateAccount();


        //    Console.WriteLine("Skapa konto\n");

        //    Console.WriteLine("Skriv i Id-nummer:");
        //    int tempIdNr = Int32.Parse(Console.ReadLine());

        //    Console.WriteLine("Skriv i kontonummer");
        //    int tempAccountNr = Int32.Parse(Console.ReadLine());

        //    Console.WriteLine("Skriv in kontonamn");
        //    string tempAccountName = Console.ReadLine();



        //    Console.WriteLine("Skriv in räntesats");
        //    decimal tempInterestRate = Decimal.Parse(Console.ReadLine());



        //    Console.WriteLine("Skriv in insättning");
        //    decimal tempBalance = Decimal.Parse(Console.ReadLine());

        //    Console.WriteLine("Skriv i max kredit");
        //    decimal tempMaxCredit = Decimal.Parse(Console.ReadLine());


        //    Account account = new Account(tempAccountNr, tempAccountName, tempIdNr, tempInterestRate, tempBalance, tempMaxCredit);

        //    accountList.Add(account);



        //    foreach (Account accounts in accountList)
        //    {
        //        Console.WriteLine($"AccountNr: {accounts.AccountNr}\nAccountName: {accounts.AccountName}\nIdNr: {accounts.IdNr}\nInterestRate: {accounts.InterestRate}\nBalance: {accounts.Balance}\nMaxCredit: {accounts.MaxCredit}\n");
        //    }




        //}

        //public int AccountNr { get; set; }
        //public required string AccountName { get; set; }
        //public int IdNr { get; set; }
        //public decimal InterestRate { get; set; }
        //public decimal Balance { get; set; }
        //public decimal MaxCredit { get; set; }


        //public CreateAccount(int accountNr, string accountName, int idNr, decimal interestRate, decimal balance, decimal maxCredit)
        //{
        //    AccountNr = accountNr;
        //    AccountName = accountName;
        //    IdNr = idNr;
        //    InterestRate = interestRate;
        //    Balance = balance;
        //    MaxCredit = maxCredit;

        //    void AddIdNr()
        //    {
        //        Console.WriteLine("Skriv i Id-nummer");

        //        idNr = Int32.Parse(Console.ReadLine());

        //    }

        //    void AddAccountNr()
        //    { 
        //        Console.WriteLine("Skriv i kontonummer"); 
        //        accountNr = Int32.Parse(Console.ReadLine());
        //    }

        //    void AddAccountName() 
        //    {
        //        Console.WriteLine("Skriv in kontonummer");
        //        accountName = Console.ReadLine();
        //    }

        //    void AddInterestRate() 
        //    {
        //        Console.WriteLine("Skriv in kontnummer");
        //        interestRate = Decimal.Parse(Console.ReadLine());
        //    }

        //    void AddBalance() 
        //    {
        //        Console.WriteLine("Skriv in insättning");
        //        balance = Decimal.Parse(Console.ReadLine());
        //    }

        //    //void RemoveBalance() 
        //    //{   
        //    //    Console.WriteLine("Skriv in Uttag");
        //    //    balance = Decimal.Parse(Console.ReadLine());
        //    //}
        //}


    }
}
