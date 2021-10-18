using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services 
{ 
    class CsvService : ICsvService
    {
        public void WriteCSV(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}
