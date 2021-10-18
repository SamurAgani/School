using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class ClassRepository : IRepository<Class>
    {
        private TaskContext context;
        public ClassRepository()
        {
            context = new TaskContext();
        }
        public void Add(Class entity)
        {

            context.Classes.Add(entity);
        }

        public IEnumerable<Class> GetAll()
        {
            return context.Classes;
        }

        public void Remove(Class entity)
        {
            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Class entity)
        {

        }
        
    }
}
