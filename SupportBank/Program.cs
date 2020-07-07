using System;
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

            var transactionListMaker = new TransactionListMaker();
            var transactionList = transactionListMaker.LoadData();
            var accountMaker= new AccountMaker();
            var accountList = accountMaker.MakeAccountList(transactionList);
            var userInterface = new UserInterface();
            userInterface.UserInteract(accountList, transactionList);
        }
    }
}