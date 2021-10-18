using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class AdminRepository : IRepository<Admin>
    {
        private TaskContext context;
        public AdminRepository()
        {
            context = new TaskContext();

        }
        public void Add(Admin entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> GetAll()
        {
            return context.Admins.ToList();
        }

        public void Remove(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Admin entity)
        {
            throw new NotImplementedException();
        }

    }
    
}
