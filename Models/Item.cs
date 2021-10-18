using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbrellaTask.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
