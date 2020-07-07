using System;

namespace SupportBank
{
    class Transaction
    {
        public string Payer;
        public string Payee;
        public string Narrative;
        public double Amount;

        public void BuildTransaction(string line)
        {
            string[] splitLine = line.Split(',');
            Payer = splitLine[1];
            Payee = splitLine[2];
            Narrative = splitLine[3];
            Amount = Convert.ToDouble(splitLine[4]);
        }
    }
}