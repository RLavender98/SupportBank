using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NLog;

namespace SupportBank
{
    public abstract class FileReader
    {
        public abstract List<Transaction> ReadFile(string path);
    }
}