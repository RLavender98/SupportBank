﻿using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    internal class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Log\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            
            var transactions = new List<Transaction>();
            var transactionListMaker = new TransactionListMaker();
            transactions = transactionListMaker.ReadCsv(transactions, @"C:\Users\rublav\Work\Training\SupportBank\DodgyTransactions2015.txt");
            transactions = transactionListMaker.ReadCsv(transactions,
                @"C:\Users\rublav\Work\Training\SupportBank\Transactions2014.txt");
            var accountMaker= new AccountMaker();
            var accountList = accountMaker.MakeAccountList(transactions);
            var userInterface = new UserInterface();
            userInterface.UserInteract(accountList, transactions);
        }
    }
}