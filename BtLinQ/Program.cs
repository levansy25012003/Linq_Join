using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Employee.getEmployees();
            List<Department> departments = Department.getDepatments();

            // Truy vấn MAX, MIN, AVERAGE của Salary
            double maxSalary = employees.Max(emp => emp.Salary);
            double minSalary = employees.Min(emp => emp.Salary);
            double averageSalary = employees.Average(emp => emp.Salary);

            // Hiển thị kết quả
            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
            


            var query = from emp in employees
                        join dep in departments on emp.DepartmentID equals dep.ID
                        orderby dep.Name, emp.Name
                        select new
                        {
                            EmployeeID = emp.ID,
                            EmployeeName = emp.Name,
                            DepartmentName = dep.Name,
                            Age = emp.Age,
                            Salary = emp.Salary,
                            BirthDate = emp.BirthDate
                        };

            // In thông tin nhân viên theo phòng ban
            foreach (var employee in query)
                Console.WriteLine(string.Format("Employee ID: {0}, Employee Name: {1}, Department Name: {2}, Age: {3}, Salary: {4:C}, Birth Date: {5}",
                                                 employee.EmployeeID, employee.EmployeeName, employee.DepartmentName, employee.Age,
                                                 employee.Salary, employee.BirthDate.ToShortDateString()));



            // Truy vấn MAX và MIN của Tuổi
            int maxAge = employees.Max(emp => CalculateAge(emp.BirthDate));
            int minAge = employees.Min(emp => CalculateAge(emp.BirthDate));

            // Hiển thị kết quả
            Console.WriteLine($"Max Age: {maxAge}");
            Console.WriteLine($"Min Age: {minAge}");
            Console.ReadKey();

        }

        static int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
    }
}
