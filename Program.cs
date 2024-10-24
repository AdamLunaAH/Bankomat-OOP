﻿using System.Collections.Generic;

namespace Bankomat_OOP
{
    //public class Account
    //{
    //    public int AccountNr { get; set; }

    //    public string AccountName { get; set; }

    //    public int IdNr { get; set; }
    //    public decimal InterestRate { get; set; }
    //    public decimal Balance { get; set; }
    //    public decimal MaxCredit { get; set; }



    //    public Account(int accountNr, string accountName, int idNr, decimal interestRate, decimal balance, decimal maxCredit)
    //    {
    //        AccountNr = accountNr;
    //        AccountName = accountName;
    //        IdNr = idNr;
    //        InterestRate = interestRate;
    //        Balance = balance;
    //        MaxCredit = maxCredit;
    //    }

    //    private List<Account> accountList { get; set; } = new List<Account>();
    //    public List<Account> GetAccountList() 
    //    {
    //        return accountList;
    //    }
    //}


    internal class Program
    {

        static void Main(string[] args)
        {

            List<Account> accountList = new List<Account>();

            Account account1Example = new Account(12345, "Abc", 123, 2.5m, 200, 50);
            accountList.Add(account1Example);
            Account account2Example = new Account(67890, "Def", 456, 4.5m, 150, 30);
            accountList.Add(account2Example);

            int accountNrCheck;

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

                Console.WriteLine("7. Avsluta");



                string choice = Console.ReadLine();

                switch (choice)

                {

                    case "1":

                        //Insättning;
                        DepositClass.Deposit(accountList);

                        //Console.WriteLine("Insättning");

                        //Console.WriteLine("Vad är kontonumret på kontot som insättningen ska utföras");
                        // accountNrCheck = Int32.Parse(Console.ReadLine());

                        //foreach (Account accounts in accountList)
                        //{
                        //    if (accountNrCheck == accounts.AccountNr)
                        //    {
                        //        Console.WriteLine("Hur mycket ska sättas in?");

                        //        decimal depositCheck = decimal.Parse(Console.ReadLine());

                        //        accounts.Balance += depositCheck;

                        //        Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                        //    }
                        //}



                        //Console.WriteLine(accounts);


                        break;

                    case "2":

                        //Uttag

                        WithdrawClass.Withdraw(accountList);
                        //Console.WriteLine("Uttag");

                        //Console.WriteLine("Vad är kontonumret på kontot som uttag ska utföras");
                        //accountNrCheck = Int32.Parse(Console.ReadLine());

                        //foreach (Account accounts in accountList)
                        //{
                        //    if (accountNrCheck == accounts.AccountNr)
                        //    {
                        //        Console.WriteLine("Hur mycket ska tas ur?");

                        //        decimal withdrawCheck = decimal.Parse(Console.ReadLine());

                        //        accounts.Balance -= withdrawCheck;

                        //        Console.WriteLine($"Nya saldot för konto {accounts.AccountNr} är {accounts.Balance}");
                        //    }
                        //}


                        break;

                    case "3":

                        //Kontosaldo

                        AccountBalanceClass.AccountBalance(accountList);

                        //Console.WriteLine("Kontosaldo");

                        //Console.WriteLine("Vad är kontonumret på kontot som saldot ska visas");
                        //accountNrCheck = Int32.Parse(Console.ReadLine());

                        //foreach (Account accounts in accountList)
                        //{
                        //    if (accountNrCheck == accounts.AccountNr)
                        //    {
                        //        Console.WriteLine($"Saldot på kontot {accounts.AccountNr} är {accounts.Balance}");
                        //    }
                        //}



                        //Console.WriteLine(accounts)

                        break;

                    case "4":

                        //Konton och saldon
                        AccountAndBalanceListClass.AccountAndBalanceList(accountList);

                        //Console.WriteLine("Kontonnummer och kontosaldon\n");

                        //foreach (Account accounts in accountList) 
                        //{
                        //   Console.WriteLine($"Kontonr: {accounts.AccountNr}\nKontosaldo: {accounts.Balance}\n");
                        //}

                        break;

                    case "5":

                        //Skapa konto

                        CreateAccountClass.CreateAccount(accountList);

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


                    //Account account = new Account(tempAccountNr, tempAccountName, tempIdNr, tempInterestRate, tempBalance, tempMaxCredit);

                    //    accountList.Add(account);

                        

                    //    foreach (Account accounts in accountList)
                    //    {
                    //        Console.WriteLine($"AccountNr: {accounts.AccountNr}\nAccountName: {accounts.AccountName}\nIdNr: {accounts.IdNr}\nInterestRate: {accounts.InterestRate}\nBalance: {accounts.Balance}\nMaxCredit: {accounts.MaxCredit}\n");
                    //    }


                        break;

                    case "6":

                        //Avsluta konto

                        break;

                    case "7":

                        return;

                    default:

                        Console.WriteLine("Ogiltigt val. Försök igen.");

                        break;

                }

            }   
        }

        

        //List<Account> accountList = new List<Account>();
        //static void CreateAccount(List<Account> accountList)
        //{
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
    }

    
}
