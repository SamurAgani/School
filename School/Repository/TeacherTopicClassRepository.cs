using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    class TeacherTopicClassRepository : IRepository<TeacherTopicClass>
    {
        private TaskContext context;
        public TeacherTopicClassRepository()
        {
            context = new TaskContext();
        }

        public void Add(TeacherTopicClass entity)
        {
            
        }

        public IEnumerable<TeacherTopicClass> GetAll()
        {
            return context.TeacherTopicClass;
        }

        public void Remove(TeacherTopicClass entity)
        {
            context.TeacherTopicClass.Remove(context.TeacherTopicClass.FirstOrDefault(x => x.Id == entity.Id));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TeacherTopicClass entity)
        {
            
        }
    }
}
