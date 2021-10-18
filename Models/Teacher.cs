using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Teacher : Account
    {
        public override string ToString()
        {
            return Name + " " + Surname; 
        }
    }
}
