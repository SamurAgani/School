using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class GenderRepository : IRepository<Gender>
    {
        private TaskContext context;
        public GenderRepository()
        {
            context = new TaskContext();
        }
        public void Add(Gender entity)
        {
            context.Genders.Add(entity);
        }

        public IEnumerable<Gender> GetAll()
        {
            return context.Genders;
        }

        public void Remove(Gender entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Gender entity)
        {
            throw new NotImplementedException();
        }

    }
}
