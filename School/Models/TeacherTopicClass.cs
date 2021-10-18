using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class TeacherTopicClass
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Topic Topic { get; set; }

    }
}
