using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.Repository
{
    class StudentRepository : IRepository<Student>
    {
        private TaskContext context;

        public StudentRepository()
        {
            context = new TaskContext();
        }
        public void Add(Student entity)
        {
            entity.Gender = context.Genders.FirstOrDefault(x => x.Id == entity.Gender.Id);
            var clas = context.Classes.FirstOrDefault(x => x.Id == entity.Class.Id);
            entity.Class = clas;
            clas.Students.Add(entity);
            context.Students.Add(entity);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }

        public void Remove(Student entity)
        {
            context.Students.Remove(context.Students.FirstOrDefault(x => x.Id == entity.Id));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
