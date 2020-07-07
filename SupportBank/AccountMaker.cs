using System.Collections.Generic;

namespace SupportBank
{
    internal class AccountMaker
    {
        public List<Account> MakeAccountList(List<Transaction> transactions)
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
                var account = new Account(transactions, accountName);
                accountList.Add(account);
            }

            return accountList;
        }
    }
}