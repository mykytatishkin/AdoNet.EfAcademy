using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAcademy_P05
{
    public class Student : Person
    {
        public string University { get; set; } = null;
        public int Cource { get; set; }
        public List<Teacher> Teachers { get; set; } = new();
    }
}
