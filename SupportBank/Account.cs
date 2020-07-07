using System.Collections.Generic;

namespace SupportBank
{
    class Account
    {
        public string AccountName;
        public double Owes;

        public void BuildAccount(List<Transaction> transactions, string accountName)
        {
            AccountName = accountName;

            foreach (var transaction in transactions)
            {
                if (transaction.Payee == AccountName)
                    Owes -= transaction.Amount;
                if (transaction.Payer == AccountName)
                    Owes += transaction.Amount;
            }
        }
    }
}