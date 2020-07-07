using System.Collections.Generic;
using System.Linq;
using NLog;

namespace SupportBank
{
    
    internal class TransactionListMaker
    {    
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> LoadData()
        {
            string[] fileData =
                System.IO.File.ReadAllLines(@"C:\Users\rublav\Work\Training\SupportBank\DodgyTransactions2015.txt");
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