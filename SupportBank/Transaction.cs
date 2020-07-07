using System;
using NLog;

namespace SupportBank
{
    public class Transaction
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public string Date;
        public string Payer;
        public string Payee;
        public string Narrative;
        public double Amount;

        public Transaction(string line)
        {
            string[] splitLine = line.Split(',');
            Date = splitLine[0];
            Payer = splitLine[1];
            Payee = splitLine[2];
            Narrative = splitLine[3];
            try
            {
                Amount = Convert.ToDouble(splitLine[4]);
            }
            catch
            {
                Amount = 0;
                Console.WriteLine(line + " <-- please enter a numerical value for " + splitLine[4]);
                logger.Debug("Set Amount to zero because "+splitLine[4]+" is not a number");
                
            }
        }
    }
}