using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var transactionListMaker = new TransactionListMaker();
            var transactionList = transactionListMaker.LoadData();
            var accountMaker= new AccountMaker();
            var accountList = accountMaker.MakeAccountList(transactionList);
            var userInteraction = new UserInteraction();
            userInteraction.UserInteract(accountList, transactionList);
        }
    }
}