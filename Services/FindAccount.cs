using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{
    class FindAccount : IFindAccount
    {
        private IRepository<Admin> repository;
        public FindAccount(IRepository<Admin> repository)
        {
            this.repository = repository;
        }
        public Admin FindAdmin(string username, string password)
        {
            return repository.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
