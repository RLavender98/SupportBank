using System;

namespace SupportBank
{
    class Transaction
    {
        public string AllInfo;
        public string Date;
        public string Payer;
        public string Payee;
        public string Narrative;
        public double Amount;

        public void BuildTransaction(string line)
        {
            AllInfo = line;
            string[] splitLine = line.Split(',');
            Date = splitLine[0];
            Payer = splitLine[1];
            Payee = splitLine[2];
            Narrative = splitLine[3];
            Amount = Convert.ToDouble(splitLine[4]);
        }
    }
}