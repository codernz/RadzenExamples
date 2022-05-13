using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportCsvFiles.Models
{
    public class Mappings
    {
        public int Position { get; set; }
        public string CSVField { get; set; }
        public string DatabaseField { get; set; }
    }
}
