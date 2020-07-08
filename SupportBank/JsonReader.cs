using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;

namespace SupportBank
{
    internal class JsonReader
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> ReadJson(List<Transaction> transactions, string path)
        {
            string fileData =
                System.IO.File.ReadAllText(path);
            fileData = fileData.Replace("FromAccount", "Payer").Replace("ToAccount", "Payee");
            var jsonFile = JsonConvert.DeserializeObject<List<Transaction>>(fileData);
            transactions.AddRange(jsonFile);
            logger.Info("Added "+path+" to the list of transactions.");
            return transactions;
        }
    }
}