using System.Collections.Generic;
using Newtonsoft.Json;

namespace SupportBank
{
    internal class JsonReader
    {
        public List<Transaction> ReadJson(List<Transaction> transactions, string path)
        {
            string fileData =
                System.IO.File.ReadAllText(path);
            fileData = fileData.Replace("FromAccount", "Payer").Replace("ToAccount", "Payee");
            var jsonFile = JsonConvert.DeserializeObject<List<Transaction>>(fileData);
            transactions.AddRange(jsonFile);
            return transactions;
        }
    }
}