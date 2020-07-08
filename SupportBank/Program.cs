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
            LoggingConfiguration();

            
            //allTransactions.AddRange(fileReader.JsonReader.ReadJson(@"C:\Users\rublav\Work\Training\SupportBank\Transactions2013.json"));
            //allTransactions.AddRange(fileReader.CsvReader.ReadCsv(@"C:\Users\rublav\Work\Training\SupportBank\Transactions2014.txt"));
            //allTransactions.AddRange(fileReader.CsvReader.ReadCsv(@"C:\Users\rublav\Work\Training\SupportBank\DodgyTransactions2015.txt"));
            var userInterface = new UserInterface();
            while(true)
            {
                userInterface.UserInteract(userInterface.AllTransactions);
            }

        }

        private static void LoggingConfiguration()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget
                {FileName = @"C:\Work\Log\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}"};
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
        }
    }
}