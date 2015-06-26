using System;
using System.Linq;

namespace DapperExample2
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return string.Format("#{4}: {0} {1} - {2} - {3} - {5}", FirstName, LastName, Email, Phone, ID, DateOfBirth);
        }
    }
}
