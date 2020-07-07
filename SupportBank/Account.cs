using System.Collections.Generic;
using System.ComponentModel.Design;

namespace SupportBank
{
    public class Account
    {
        public string AccountName;
        public double Owes;
        public List<Transaction> InvolvedTransactions;
        
        public Account(List<Transaction> transactions, string accountName)
        {
            AccountName = accountName;

            InvolvedTransactions = new List<Transaction>();
            foreach (var transaction in transactions)
            {
                if(transaction.Payer==AccountName || transaction.Payee ==AccountName)
                    InvolvedTransactions.Add(transaction);
            }
            
            foreach (var transaction in InvolvedTransactions)
            {
                if (transaction.Payee == AccountName)
                    Owes -= transaction.Amount;
                if (transaction.Payer == AccountName)
                    Owes += transaction.Amount;
            }
        }
    }
}