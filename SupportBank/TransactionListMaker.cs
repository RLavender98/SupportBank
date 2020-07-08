using System.Collections.Generic;
using System.Linq;
using NLog;

namespace SupportBank
{
    
    internal class TransactionListMaker
    {    
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> ReadCsv(List<Transaction> transactions, string path)
        {
            string[] fileData =
                System.IO.File.ReadAllLines(path);
            
            foreach (var line in fileData.Skip(1))
            {
                var transaction = new Transaction(line);
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}