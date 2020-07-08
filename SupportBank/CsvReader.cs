using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NLog;

namespace SupportBank
{
    
    internal class FileReader
    {    
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly JsonReader _jsonReader = new JsonReader();

        public JsonReader JsonReader
        {
            get { return _jsonReader; }
        }

        public List<Transaction> ReadCsv(List<Transaction> transactions, string path)
        {
            string[] fileData =
                System.IO.File.ReadAllLines(path);
            var lineNumber = 1;
            foreach (var line in fileData.Skip(1))
            {    
                string[] splitLine = line.Split(',');
                string payer = splitLine[1];
                string payee = splitLine[2];
                string narrative = splitLine[3];
                if (!Double.TryParse(splitLine[4], out var amount))
                {
                    string message = "Invalid Amount in line " + lineNumber + " of "+path+". Transaction skipped.";
                    Console.WriteLine(message);
                    logger.Debug(message);
                }
                else if (!DateTime.TryParse(splitLine[0], out var date))
                {
                    string message = "Invalid Date in line " + lineNumber + " of "+path+". Transaction skipped.";
                    Console.WriteLine(message);
                    logger.Debug(message);
                }
                else
                {
                    var transaction = new Transaction(date, payer, payee, narrative, amount);
                    transactions.Add(transaction); 
                }
                lineNumber++;
            }
            
            logger.Info("Added "+ path+" to list of transactions.");
            return transactions;
        }
    }
}