using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NLog;

namespace SupportBank
{
    
    internal class FileReader
    {    
        
        private readonly JsonReader _jsonReader = new JsonReader();
        private readonly CsvReader _csvReader = new CsvReader();

        public JsonReader JsonReader
        {
            get { return _jsonReader; }
        }

        public CsvReader CsvReader
        {
            get { return _csvReader; }
        }
    }
}