using System;
using NLog;

namespace SupportBank
{
    public class Transaction
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public DateTime Date;
        public string Payer;
        public string Payee;
        public string Narrative;
        public double Amount;

        public Transaction(DateTime date, string payer, string payee, string narrative, double amount)
        {
            Date = date;
            Payer = payer;
            Payee = payee;
            Narrative = narrative;
            Amount = amount;
        }
    }
}