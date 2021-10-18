using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{
    public interface IFindAccount
    {
        Admin FindAdmin(string username, string password);
    }
}
