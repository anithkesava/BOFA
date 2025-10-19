using StudentsDepartment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
namespace DataStructureandAlgorithm
{
    public class DSA
    {
        public static void HoldMain()
        {
            /*
            var str1 = new List<string> { "apple", "banana", "rubics cube", "hello" };
            var str2 = new List<string> { "chikku", "apple", "banana", "welcome" };
            Console.WriteLine(string.Join(",", CompareStrings(str1, str2)));
            var array = new int[] { 1, 2, 3 };
            Console.WriteLine(string.Join(",", ReverseArray(array)));
            var array = new int[] { 3, 1, 4, 2 };
            int result = SecondLargestElement(array);
            Console.WriteLine(result);
            string s = "banana";
            LongestSubstringWithoutRepeating(s);
            var array = new int[] { 1, 1, 2, 3, 4, 4, 5, 6, 6, 7, 8, 9, 10, 10 };
            Console.WriteLine(string.Join(",", RemoveDuplicates(array)));
            var array = new int[] { 1, 1, 2, 3, 4, 4, 5, 6, 6, 7, 8, 9, 10, 10 };
            Console.WriteLine(string.Join(",", FindDuplicates(array)));
            var array1 = new int[] {1, 2, 3, 4, 5 };
            var array2 = new int[] {3, 5, 6, 7, 8 };
            Console.WriteLine(string.Join(",", NewLinq(array1, array2)));
            Console.Write("Enter the String: ");
            string? str = Console.ReadLine();
            var result = FindNonRepeatingChar(str);
            Console.WriteLine("[" + string.Join(", ", result) + "]");
            var array = new int[] { 2, 7, 12, 14, 3 };
            int target = 26;
            var result = FindIndexOfSum(array, target);
            Console.WriteLine("["+result.Item1+","+result.Item2+"]");
            var list = new int[] { 1, 2, 1, 1, 1, };
            var result = FindMostlyAppearedNumber(list);
            if (result.Count > 0)
                Console.WriteLine($"[{string.Join(",", result)}]");
            else
                Console.WriteLine("[]");
            */
            Console.ReadLine();
        }
        public static List<string> CompareStrings(List<string> str1, List<string> str2)
        {
            var set = new HashSet<string>(str1);
            return str2.Where(x => set.Contains(x)).ToList();
        }
        public static int[] ReverseArray(int[] array)
        {
            /*
             * my code but it involves a new array
             * 
            var newarray = new int[array.Length];
            int i = array.Length - 1;
            int j = 0;
            while (i >= 0)
            {
                newarray[j] = array[i];
                i--;
                j++;
            }
            return newarray;
            */
            /* chatgpt code:                 
            */
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
            return array;
        }
        public static int SecondLargestElement(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }
            return array[1];
        }
        public static int LongestSubstringWithoutRepeating(string s)
        {
            // Dictionary to remember last seen position of each character
            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int start = 0;   // starting index of our window
            int maxLength = 0;
            for (int end = 0; end < s.Length; end++)
            {
                char current = s[end];
                // If current character is already in dictionary and inside our window
                if (lastSeen.ContainsKey(current) && lastSeen[current] >= start)
                {
                    // move start to one after the last seen index of current char
                    start = lastSeen[current] + 1;
                }
                // update last seen position of current char
                lastSeen[current] = end;
                // calculate window length (end - start + 1)
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }
        public static List<int> RemoveDuplicates(int[] array)
        {
            var set = new HashSet<int>(array);
            return set.ToList();
        }
        public static List<int> FindDuplicates(int[] array)
        {
            var dictionary = new Dictionary<int, int>();
            var duplicates = new List<int>();
            foreach (var arr in array)
            {
                if (!dictionary.ContainsKey(arr))
                    dictionary[arr] = 1;
                else
                    dictionary[arr]++;
            }
            foreach (var d in dictionary)
            {
                if (d.Value > 1)
                {
                    duplicates.Add(d.Key);
                }
            }
            return duplicates;
        }
        public static List<int> NewLinq(int[] array1, int[] array2)
        {
            return array1.Except(array2).ToList();
        }
        public static List<char> FindNonRepeatingChar(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("value cannot be null");
                return new List<char>();
            }
            return str.Trim().Replace(" ", "").ToLower()
                .GroupBy(x => x)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .ToList();
        }
        public static (int, int) FindIndexOfSum(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }
        public static List<int> FindMostlyAppearedNumber(int[] array)
        {
            int half = array.Length / 2;
            return array.GroupBy(x => x).Where(g => g.Count() > half).Select(g => g.Key).ToList();
        }
    }
    public class BOFA
    {
        public static void HoldMain()
        {
            /*
            var employeeDetails = GetEmployeeDetails();
            var departmentDetails = GetDepartmentDetails();
            var employeeandDepartments = EmployeeandDepartment(employeeDetails, departmentDetails);
            var employeeCountswithDepartment = GetEmployeeCountsWithDepartment(employeeandDepartments);
            foreach (var e in employeeCountswithDepartment)
            {
                Console.WriteLine("Department: " + e.Key);
                Console.WriteLine("Employee Count: " + e.Value);
            }  
            var averageSalary = GetAverageSalaryFromDepartment(employeeDetails, departmentDetails);
            foreach(var r in averageSalary)
            {
                Console.Write(r.DepartmentName+" ");
                Console.WriteLine(r.AverageSalary);
            }
            var employeeDetails = GetEmployeeDetails();
            var departmentDetails = GetDepartmentDetails();
            var groupByDepartments = EmployeesInDepartments(employeeDetails, departmentDetails);
            foreach(var g in groupByDepartments)
            {
                Console.WriteLine("Department: "+g.DepartmentName);
                Console.WriteLine("EmployeeNames: "+string.Join(",", g.EmployeeNames));
            }
            var customers = GetCustomerDetails();
            var orders = GetOrderDetails();
            var result = CustomerWithOrders(customers, orders);
            foreach(var r in result)
            {
                Console.WriteLine("Customername: "+r.CustomerName+" Total OrderAmount: "+r.TotalAmount+" Orders Count: "+r.OrdersCount);
            }

            var students = GetStudentDetails();
            var departments = GetDepartmentDetails();
            GroupStudentsWithDepartment(students, departments);
            */

            var customers = GetCustomerDetails();
            var transactions = GetTransactionDetails();
            var topthreetransactions = GettopThreeTransaction(customers, transactions);
            foreach (var top in topthreetransactions)
            {
                Console.WriteLine("Customer Name: " + top.Customername + " Amount Paid: " + top.AmountPaid);
            }
            Console.ReadLine();
        }
        public static List<TransactionDetails> GetTransactionDetails()
        {
            return new List<TransactionDetails>
            {
                new TransactionDetails { TransactionId=1, CustomerID = 1, AmountPaid = 200 },
                new TransactionDetails { TransactionId=2, CustomerID = 2, AmountPaid = 120 },
                new TransactionDetails { TransactionId=3, CustomerID = 3, AmountPaid = 300 }, //2
                new TransactionDetails { TransactionId=4, CustomerID = 1, AmountPaid = 220 },  //3
                new TransactionDetails { TransactionId=5, CustomerID = 2, AmountPaid = 20 },
                new TransactionDetails { TransactionId=6, CustomerID = 3, AmountPaid = 330 }, //1
                new TransactionDetails { TransactionId=7, CustomerID = 1, AmountPaid = 90 },
                new TransactionDetails { TransactionId=8, CustomerID = 2, AmountPaid = 120 },
                new TransactionDetails { TransactionId=9, CustomerID = 3, AmountPaid = 175 },
                new TransactionDetails { TransactionId=10, CustomerID = 2, AmountPaid = 100 },
            };
        }
        public static void GroupStudentsWithDepartment(List<Student> student, List<Department> department)
        {
            var query = (from s in student
                         join d in department
                        on s.DepartmentId equals d.Id
                         group s by d.DepartmentName into groupedDept
                         select new
                         {
                             StudentName = groupedDept.Select(x => x.StudentName).ToList(),
                             DepartmentName = groupedDept.Key
                         }).ToList();
            foreach (var q in query)
            {
                Console.WriteLine("Department Name: " + q.DepartmentName);
                Console.WriteLine("Student Name: " + string.Join(",", q.StudentName));
            }
        }
        public static List<Student> GetStudentDetails()
        {
            return new List<Student>
            {
                 new Student { Id = 1, StudentName = "Asha", Marks = 85, DepartmentId = 1 },
                 new Student { Id = 2, StudentName = "Ravi", Marks = 72, DepartmentId = 2 },
                 new Student { Id = 3, StudentName = "Priya", Marks = 59, DepartmentId = 1 },
                 new Student { Id = 4, StudentName = "Kumar", Marks = 90, DepartmentId = 2 },
                 new Student { Id = 5, StudentName = "Divya", Marks = 40, DepartmentId = 3 }
            };
        }
        public static List<Department> GetDepartmentDetails()
        {
            return new List<Department>
                {
                    new Department { Id = 1, DepartmentName = "Computer Science" },
                    new Department { Id = 2, DepartmentName = "Electronics" },
                    new Department { Id = 3, DepartmentName = "Mechanical" }
                };
        }
        public static List<Order> GetOrderDetails()
        {
            return new List<Order>
            {
                new Order { Id = 101, CustomerId = 1, Amount = 250 },
                new Order { Id = 102, CustomerId = 2, Amount = 450 },
                new Order { Id = 103, CustomerId = 1, Amount = 150 },
                new Order { Id = 104, CustomerId = 3, Amount = 300 },
                new Order { Id = 105, CustomerId = 2, Amount = 500 }
            };
        }
        public static List<Customer> GetCustomerDetails()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 2, Name = "Emma" },
                new Customer { Id = 3, Name = "Mike" }
            };
        }
        public static List<CustomersOrder> CustomerWithOrders(List<Customer> customers, List<Order> orders)
        {
            return (from cust in customers
                    join order in orders on cust.Id equals order.CustomerId
                    group order by cust.Name into groupedcust
                    select new CustomersOrder
                    {
                        CustomerName = groupedcust.Key,
                        TotalAmount = groupedcust.Sum(x => x.Amount),
                        OrdersCount = groupedcust.Select(x => x.Id).Count(),
                    }).ToList();
        }
        public static List<Employees> GetEmployeeDetails()
        {
            return new List<Employees>
            {
                new Employees { EmployeeId = 1, EmployeeName = "Anith Kesava M R", Salary = 28000, DepartmentId = 2 },
                new Employees { EmployeeId = 2, EmployeeName = "Saravana Saran C", Salary = 31000, DepartmentId = 1 },
                new Employees { EmployeeId = 7, EmployeeName = "Ananthiga C H", Salary = 40000, DepartmentId = 1 },
                new Employees { EmployeeId = 3, EmployeeName = "Sudalai Vignesh S", Salary = 29000, DepartmentId = 3 },
                new Employees { EmployeeId = 4, EmployeeName = "Bala Vignesh D", Salary = 29000, DepartmentId = 3 },
                new Employees { EmployeeId = 5, EmployeeName = "Hemanth Kingsley", Salary = 42000, DepartmentId = 2 },
                new Employees { EmployeeId = 6, EmployeeName = "Joshua Augestin K", Salary = 35000, DepartmentId = 4 },
                new Employees { EmployeeId = 8, EmployeeName = "Sanjeev", Salary = 57000, DepartmentId = 4 }
            };
        }
        public static List<Departments> GetDepartmentsDetails()
        {
            return new List<Departments>
            {
                new Departments{ DepartmentId = 1, DepartmentName = "Cyber Security" },
                new Departments{ DepartmentId = 2, DepartmentName = "Software Developer" },
                new Departments{ DepartmentId = 3, DepartmentName = "Compliance Handling" },
                new Departments{ DepartmentId = 4, DepartmentName = "Automation and Testing" },
            };
        }
        public static List<EmployeeDepartment> EmployeeandDepartment(List<Employees> employees, List<Departments> departments)
        {
            return (from emp in employees
                    join dept in departments
                    on emp.DepartmentId equals dept.DepartmentId
                    select new EmployeeDepartment
                    {
                        EmployeeName = emp.EmployeeName,
                        DepartmentName = dept.DepartmentName
                    }).ToList();
        }
        public static Dictionary<string, int> GetEmployeeCountsWithDepartment(List<EmployeeDepartment> employeeDepartments)
        {
            return employeeDepartments
                .GroupBy(x => x.DepartmentName)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public static List<DepartmentAverageSalary> GetAverageSalaryFromDepartment(List<Employees> employees, List<Departments> departments)
        {
            //the below is the code for find the average of department. 
            /*
             SQL Query: 
                select DepartmentName d, avg(e.Salary) from Employee e join Department d on e.DepartmentId = d.Id group by d.DepartmentName ;
             */
            return (from emp in employees
                    join dept in departments on emp.DepartmentId equals dept.DepartmentId
                    group emp by dept.DepartmentName into groupeddept
                    select new DepartmentAverageSalary
                    {
                        DepartmentName = groupeddept.Key,
                        AverageSalary = groupeddept.Average(x => x.Salary)
                    }).ToList();
            /*
             the above code contains two linq operations 
            - join 
            - group by  
             */
        }
        public static List<EmployeeInEachDepartment> EmployeesInDepartments(List<Employees> employees, List<Departments> departments)
        {
            return (from emp in employees
                    join dept in departments on emp.DepartmentId equals dept.DepartmentId
                    group emp by dept.DepartmentName into groupedDept
                    select new EmployeeInEachDepartment
                    {
                        DepartmentName = groupedDept.Key,
                        EmployeeNames = groupedDept.Select(x => x.EmployeeName).ToList(),
                    }).ToList();
        }
        public static List<HighestTransaction> GettopThreeTransaction(List<Customer> customers, List<TransactionDetails> transactions)
        {
            /*we need to fetch the 
             * -transaction id,
             * -customer name, 
             * -amount paid  
             * 
             * what we need to display in output. 
             * -customer name
             * -the amount he paid
             */

            return (from customer in customers
                    join transaction in transactions
                   on customer.Id equals transaction.CustomerID
                    select new HighestTransaction
                    {
                        Customername = customer.Name,
                        AmountPaid = transaction.AmountPaid
                    }).OrderByDescending(x => x.AmountPaid).Take(3).ToList();
        }
    }
    public class HighestTransaction
    {
        public string Customername { get; set; }
        public decimal AmountPaid { get; set; }
    }
    public class TransactionDetails
    {
        public int TransactionId { get; set; }
        public int CustomerID { get; set; }
        public decimal AmountPaid { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
        public int DepartmentId { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CustomersOrder
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrdersCount { get; set; }
    }
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
    public class Departments
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class EmployeeDepartment
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
    public class DepartmentAverageSalary
    {
        public string DepartmentName { get; set; }
        public decimal AverageSalary { get; set; }
    }
    public class EmployeeInEachDepartment
    {
        public string DepartmentName { get; set; }
        public List<string> EmployeeNames { get; set; }
    }
}

namespace PracticeLinq
{
    public class Program
    {
        public static void HoldMain()
        {
            /*
            var array = Enumerable.Range(1, 10).ToArray();
            var result = FindSumOfSquares(array);
            Console.WriteLine(result);

            var array = Enumerable.Range(1, 30).ToArray();
            GroupByRemainder(array);

            var array = new int[] { 12, 1, 2, 1, 12, 12, 10, 11, 11, 13, 51, 13 };
            var result = TopFiveLargestNumber(array);
            Console.WriteLine(string.Join(",", result));

            Console.WriteLine(AverageOfOdd(array));

            var array = Enumerable.Range(1, 100).ToArray();
            var result = NumberEndsWith(array);
            Console.WriteLine(string.Join(",", result));

            var array = new int[] { 10, 2, 3, 9, 3, 8, 9, 11, 11, 12, 13, 12, 1 };
            int value = SecondHighestDistinctNumber(array);
            Console.WriteLine(value);

            var words = new List<string> { "anith", "ashvath", "mufeed", "dhanu", "eat onion" };
            var result = WordsHaveMoreVowels(words);
            Console.WriteLine(string.Join(",", result));
             */
            var numbers = Enumerable.Range(1, 19).ToList();
            var result = GroupNumbers(numbers);
            Console.WriteLine("Even Count: "+result.Item1);
            Console.WriteLine("Odd Count: "+result.Item2);
            Console.ReadLine();
        }
        public static int FindSumOfSquares(int[] array)
        {
            return array.Select(x => x * x).Sum();
        }
        public static void GroupByRemainder(int[] array)
        {
            var groupRemainder = array.GroupBy(x => x % 3).Select(x => new
            {
                Remainder = x.Key,
                Numbers = x.ToList()
            }).ToList();
            foreach (var group in groupRemainder)
            {
                Console.WriteLine(group.Remainder);
                Console.WriteLine(string.Join(",", group.Numbers));
            }
        }
        public static List<int> TopFiveLargestNumber(int[] array)
        {
            return array.Distinct().OrderByDescending(x => x).Take(5).ToList();
        }
        public static double AverageOfOdd(int[] array)
        {
            return array.Where(x => x % 2 != 0).Average();
        }
        public static List<int> NumberEndsWith(int[] array)
        {
            return array.Where(x => x % 10 == 7).ToList();
        }
        public static int SecondHighestDistinctNumber(int[] array)
        {
            var distinct = array.Distinct();
            var max = array.Distinct().Max(x => x);
            return distinct.Where(x => x < max).Max();

        }
        public static List<string> WordsHaveMoreVowels(List<string> words)
        {
            return words.Where(x=>x.Count(x=>"AEIOUaeiou".Contains(x)) > 3).ToList();
        }
        public static (int, int) GroupNumbers(List<int> Numbers)
        {
            int oddCount = 0;
            int EvenCount = 0;
            var query = Numbers.GroupBy(x => x % 2 == 0 ? "Even" : "Odd").Select(x => new
            {
                Type = x.Key,
                Count = x.Count()

            }).ToList();
            
            foreach(var q in query)
            {
                if(q.Type == "Even")
                    EvenCount = q.Count;
                else
                    oddCount = q.Count;
            }
            return (EvenCount, oddCount);
        }
    }
}
