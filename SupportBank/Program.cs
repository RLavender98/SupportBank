using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var fileData = LoadData();
            var accountList = MakeAccountList(fileData);
            
            
            

            string command = Console.ReadLine();
            if (command == "List All")
                foreach (var account in accountList)
                {
                    Console.WriteLine(account.AccountName+" owes:"+account.Owes);
                }

        }

        public static List<Transaction> LoadData()
        {
            string[] fileData =
                System.IO.File.ReadAllLines(@"C:\Users\rublav\Work\Training\SupportBank\Transactions2014.txt");
            var transactions = new List<Transaction>();
            foreach (var line in fileData.Skip(1))
            {
                var transaction = new Transaction();
                transaction.BuildTransaction(line);
                transactions.Add(transaction);
            }

            return transactions;
        }
        
        //method that makes a list of accounts
        public static List<Account> MakeAccountList(List<Transaction> transactions)
        {
            var accountList = new List<Account>();
            var accountNames = new List<string>();
            foreach (var transaction in transactions)
            {
                if (accountNames.IndexOf(transaction.Payee) == -1)
                    accountNames.Add(transaction.Payee);
                if (accountNames.IndexOf(transaction.Payer)==-1)
                    accountNames.Add(transaction.Payer);
            }

            foreach (string accountName in accountNames)
            {
                var account = new Account();
                account.BuildAccount(transactions, accountName);
                accountList.Add(account);
            }

            return accountList;
        }
        
        //method that needs to return each person's name followed by the amount they are owed
        /*public static void ListAll(List<Transaction> transactions)
        {
            
        }*/
        
        //method that returns all the transactions for a given Account
        /*public static void ListSpecific(string name)
        {
            
        }*/
    }
}