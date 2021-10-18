using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual ObservableCollection<TeacherTopicClass> TeacherTopics { get; set; } = new ObservableCollection<TeacherTopicClass>();

        public override string ToString()
        {
            return Name;
        }
    }
}
