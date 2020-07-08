using System;
using System.Collections.Generic;
using System.Xml;
using NLog;

namespace SupportBank
{
    internal class XmlReader:FileReader
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public override List<Transaction> ReadFile(string path)
        {
            var transactions = new List<Transaction>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var nodeCounter = 0;
            foreach (XmlNode node in doc.DocumentElement)
            {
                string dateish = node.Attributes[0].InnerText;
                string narrative = node.ChildNodes[0].InnerText;
                string amountish = node.ChildNodes[1].InnerText;
                string payer = node.ChildNodes[2].ChildNodes[0].InnerText;
                string payee = node.ChildNodes[2].ChildNodes[1].InnerText;
                
                
                if (!Double.TryParse(amountish, out var amount))
                {
                    string message = "Invalid Amount in SupportTransaction Node  " + nodeCounter + " of "+path+". Transaction skipped.";
                    Console.WriteLine(message);
                    logger.Debug(message);
                }
                else if (!Double.TryParse(dateish, out var weirddate))
                {
                    string message = "Invalid Date in SupportTransaction Node  " + nodeCounter + " of "+path+". Transaction skipped.";
                    Console.WriteLine(message);
                    logger.Debug(message);
                }
                else
                {
                    DateTime date = DateTime.FromOADate(weirddate);
                    var transaction = new Transaction(date, payer, payee, narrative, amount);
                    transactions.Add(transaction); 
                }
                nodeCounter++;
            }
            return transactions;
        }
    }
}