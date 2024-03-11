using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtLinQ
{
    class Employee
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }

        public static List<Employee> getEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "A", DepartmentID = 1, Age = 20, Salary = 1500000, BirthDate = new DateTime(2003, 1, 25)},
                new Employee { ID = 2, Name = "B", DepartmentID = 3, Age = 20, Salary = 1500000, BirthDate = new DateTime(2002, 1, 25)},
                new Employee { ID = 3, Name = "C", DepartmentID = 2, Age = 20, Salary = 1500000, BirthDate = new DateTime(2001, 1, 25)},
                new Employee { ID = 4, Name = "D", DepartmentID = 1, Age = 20, Salary = 1500000, BirthDate = new DateTime(2007, 1, 25)},
            };

        }
    }
}
