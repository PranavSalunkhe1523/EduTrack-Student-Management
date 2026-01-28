using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int Marks { get; set; }
    }
}
