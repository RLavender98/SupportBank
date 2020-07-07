using System.Collections.Generic;
using System;

namespace SupportBank
{
    public class UserInteraction
    {
        public void UserInteract(List<Account> accountList, List<Transaction> transactionList)
        {
            string command = Console.ReadLine();
            if (command == "List All")
                foreach (var account in accountList)
                {
                    Console.WriteLine(account.AccountName + " owes:" + account.Owes);
                }
            else if (command.IndexOf("List ") == 0)
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
        }
    }
}