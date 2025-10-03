using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BankingProject
{
    public class Program
    {
        private static List<Employee> _employeeList;
        public static void HoldMain()
        {
            EmployeeDetails();
            TopThreeHighestPaidEmployees(_employeeList);
            FindAverageFromDepartment(_employeeList);
            FindEmployeeNameStartsWithA(_employeeList);
            var result = EmployeeDictionary(_employeeList);
            foreach (var r in result)
            {
                Console.WriteLine(r.Key + ": " + r.Value);
            }

            Console.ReadLine();
        }
        public static void EmployeeDetails()
        {
            _employeeList = new List<Employee>
            {
                new Employee{ EmployeeID=1, EmployeeName = "Anith Kesava M R", Department = "Software Developer", Salary = 49000 },
                new Employee{ EmployeeID=2, EmployeeName = "Saravana Saran C", Department = "Cyber Security", Salary = 50000 },
                new Employee{ EmployeeID=3, EmployeeName = "Sanjeev", Department = "Software Automation and Testing", Salary = 70000 },
                new Employee{ EmployeeID=4, EmployeeName = "Augustin Joshua K", Department = "Software Automation and Testing", Salary = 57000 },
                new Employee{ EmployeeID=5, EmployeeName = "Hemanth Kingsley", Department = "Software Developer", Salary = 57000 },
                new Employee{ EmployeeID=6, EmployeeName = "Dhanumalayan", Department = "SalesForce Administrative", Salary = 63000 }
            };
        }

        public static void TopThreeHighestPaidEmployees(List<Employee> employees)
        {
            var topthreeSalaries = employees.OrderByDescending(x => x.Salary).DistinctBy(x => x.Salary).Select(x => x.Salary).Take(3).ToList();
            var topthreeEmployeees = employees.Where(x => topthreeSalaries.Contains(x.Salary)).OrderByDescending(x=>x.Salary).ToList();
            foreach(var emp in topthreeEmployeees)
            {
                Console.WriteLine(emp.EmployeeName);
            }
        }

        public static void FindAverageFromDepartment(List<Employee> employees)
        {
            var groupbyDept = employees.GroupBy(x => x.Department).Select(g => new
            {
                Department = g.Key,
                Average = g.Average(x=>x.Salary)
            }).ToList(); 
            foreach(var dept in groupbyDept)
            {
                Console.WriteLine($"{dept.Department}: {dept.Average}");
            }
        }

        public static void FindEmployeeNameStartsWithA(List<Employee> employees)
        {
           var employee =  employees.Where(x => x.EmployeeName.ToLower().StartsWith('a')).ToList();
            foreach(var emp in employee)
            {
                Console.WriteLine(emp.EmployeeName);
            }
        }

        public static Dictionary<int, string> EmployeeDictionary(List<Employee> employees)
        {
            var dictionary = new Dictionary<int, string>();
            foreach(var emp in employees)
            {
                if(!dictionary.ContainsKey(emp.EmployeeID))
                {
                    dictionary[emp.EmployeeID] = emp.EmployeeName;
                }
            }
            return dictionary;
        }
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
