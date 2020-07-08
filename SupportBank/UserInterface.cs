using System.Collections.Generic;
using System;
using NLog;

namespace SupportBank
{
    public class UserInterface
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public void UserInteract(List<Transaction> transactionList)
        {
            string command = Console.ReadLine();
            if (command == "List All")
            {
                var accountMaker = new AccountMaker();
                var accountList = accountMaker.MakeAccountList(transactionList);
                foreach (var account in accountList)
                {
                    Console.WriteLine(account.AccountName + " owes:" + account.Owes);
                }
            }
            else if (command.StartsWith("List "))
            {
                command = command.Remove(0, 5);
                foreach (var transaction in transactionList)
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
                var fileReader = new FileReader();
                if (command.EndsWith(".txt"))
                {
                    transactionList.AddRange(fileReader.CsvReader.ReadCsv(@command));
                    Console.WriteLine("Added file:" + command + " to the transaction list");
                }
                else if (command.EndsWith(".json"))
                {
                    transactionList.AddRange(fileReader.JsonReader.ReadJson(@command));
                    Console.WriteLine("Added file:" + command + " to the transaction list");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid command, the available commands are:\n \t List All \n \t List [Account] \n \t Import File [filename]");
            }
        }
    }
}