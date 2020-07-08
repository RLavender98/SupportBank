using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using NLog;

namespace SupportBank
{
    public class UserInterface
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public List<Transaction> AllTransactions;
        
        public void UserInteract(List<Transaction> AllTransactions)
        {
            string command = Console.ReadLine();
            if (command == "List All")
            {
                var accountMaker = new AccountMaker();
                var accountList = accountMaker.MakeAccountList(AllTransactions);
                foreach (var account in accountList)
                {
                    Console.WriteLine(account.AccountName + " owes:" + account.Owes);
                }
            }
            else if (command.StartsWith("List "))
            {
                command = command.Remove(0, 5);
                foreach (var transaction in AllTransactions)
                {
                    if (transaction.Payee == command || transaction.Payer == command)
                    {
                        var fullTransaction = transaction.Date + ", " + transaction.Payer + ", " +
                                              transaction.Payee + ", " + transaction.Narrative + ", " +
                                              transaction.Amount;
                        Console.WriteLine(fullTransaction);
                    }
                }
            }
            else if (command.StartsWith("Import File "))
            {
                command = command.Remove(0, 12);
                FileReader fileReader = null;
                if (command.EndsWith(".txt"))
                {
                    fileReader = new CsvReader();
                }
                else if (command.EndsWith(".json"))
                {
                    fileReader = new JsonReader();
                }

                if (fileReader != null)
                {
                    AllTransactions.AddRange(fileReader.ReadFile(@command));
                    Console.WriteLine("Added file:" + command + " to the transaction list");
                }
                else
                {
                    Console.WriteLine("Program doesn't recognise file type, cannot import file:" + command);
                }
                
            }
            else
            {
                Console.WriteLine("Please enter a valid command, the available commands are:\n \t List All \n \t List [Account] \n \t Import File [filename]");
            }
            
        }

        public UserInterface()
        {
            AllTransactions = new List<Transaction>();
        }
    }
}