using System;

namespace SupportBank
{
    public class Transaction
    {
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
            Amount = Convert.ToDouble(splitLine[4]);
        }
    }
}