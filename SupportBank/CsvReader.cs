using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace SupportBank
{
    internal class CsvReader
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> ReadCsv(string path)
        {
            string[] fileData =
                System.IO.File.ReadAllLines(path);
            var lineNumber = 1;
            var transactions = new List<Transaction>();
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

            logger.Info("converted "+ path+" into a list of transactions.");
            return transactions;
        }
    }
}