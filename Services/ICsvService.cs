using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{ 
   public interface ICsvService
    {
        void WriteCSV(string path, string contents);
    }
}
