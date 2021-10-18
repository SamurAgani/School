using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class TopicRepository : IRepository<Topic>
    {
        private TaskContext context;
        public TopicRepository()
        {
            context = new TaskContext();
        }
        public void Add(Topic entity)
        {
            context.Topics.Add(entity);
        }

        public IEnumerable<Topic> GetAll()
        {
            return context.Topics;
        }

        public void Remove(Topic entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Topic entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
