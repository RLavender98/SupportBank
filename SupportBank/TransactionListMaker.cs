using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    internal class TransactionListMaker
    {
        public List<Transaction> LoadData()
        {
            string[] fileData =
                System.IO.File.ReadAllLines(@"C:\Users\rublav\Work\Training\SupportBank\Transactions2014.txt");
            var transactions = new List<Transaction>();
            foreach (var line in fileData.Skip(1))
            {
                var transaction = new Transaction(line);
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}