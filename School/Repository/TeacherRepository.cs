using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.Repository
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private TaskContext context;
        public TeacherRepository()
        {
            context = new TaskContext();
        }
        public void Add(Teacher entity)
        {
            entity.Gender = context.Genders.FirstOrDefault(x => entity.Gender.Id == x.Id);
            context.Teachers.Add(entity);
           
        }

        public IEnumerable<Teacher> GetAll()
        {
            return context.Teachers;
        }

        public void Remove(Teacher entity)
        {
            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Teacher entity)
        {
            
        }

     
    }
}
