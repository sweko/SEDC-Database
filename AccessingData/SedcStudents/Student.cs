using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedcStudents
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", FirstName, LastName, Email);
        }
    }
}
