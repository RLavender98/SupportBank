using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;

namespace SupportBank
{
    internal class JsonReader:FileReader
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public override List<Transaction> ReadFile(string path)
        {
            var transactions = new List<Transaction>();
            string fileData =
                System.IO.File.ReadAllText(path);
            fileData = fileData.Replace("FromAccount", "Payer").Replace("ToAccount", "Payee");
            var jsonTransactions = JsonConvert.DeserializeObject<List<Transaction>>(fileData);
            transactions.AddRange(jsonTransactions);
            logger.Info("Converted "+path+" into a list of transactions.");
            return transactions;
        }
    }
}