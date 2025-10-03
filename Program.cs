using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace BOFA
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    public class Program
    {
        private static List<Employee> _employees;
        static void HoldMain(string[] args)
        {
            /*
            var names = new List<string>
            { "SARAVANA SARAN", "ANITH KESAVA", "KAMARAJ", "BALA VIGNESH", "SUDALAI VIGNESH", "SANKARA SIDDHARTH" };
            Projection(names);
            var list = new List<int> { 12, 1, 23, 2, 1, 1, 2, 34, 3, 3, 4, 5, 5, 19 };
            FindDuplicates(list);
            var result = FilterAndSort(list);
            Console.WriteLine(string.Join(", ", result));
            AssignEmployees();
            EmployeeSalaryMorethanAverage(_employees);
            */
            string sentence = "LINQ makes C# powerful and LINQ is awesome";
            var wordFreq = WordsFrequency(sentence);
            foreach (var word in wordFreq)
            {
                Console.WriteLine(word.Key + ":" + word.Value);
            }
            Console.ReadLine();
        }
        public static void Projection(List<string> names)
        {
            var method = names.Select(n => new { name = n, length = n.ToLower().Replace(" ", "").Trim().Length });
            foreach (var q in method)
            {
                Console.WriteLine(q);
            }
        }
        public static List<int> FilterAndSort(List<int> nums)
        {
            var list = nums.DistinctBy(x => x).Where(x => x % 2 == 0).OrderByDescending(x => x).ToList();
            return list;
        }
        public static void FindDuplicates(List<int> nums)
        {
            var query = nums.GroupBy(x => x).
                         Where(x => x.Count() > 1).
                         Select(x => x.Key).
                         ToList();
            Console.WriteLine(string.Join(", ", query));
        }
        public static void AssignEmployees()
        {
            _employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Department = "Developer", EmployeeName = "Anith Kesava M R", Salary = 28000 },
                new Employee { EmployeeID = 2, Department = "Testing", EmployeeName = "Augustin Joshua", Salary = 35000 },
                new Employee { EmployeeID = 3, Department = "OTC", EmployeeName = "Vignesh Chandran", Salary = 50000 },
                new Employee { EmployeeID = 4, Department = "Technical Support", EmployeeName = "Kamaraj Palani", Salary = 30000 },
                new Employee { EmployeeID = 5, Department = "Technical Support", EmployeeName = "Saravana Saran Chandrasekar", Salary = 32000 },
                new Employee { EmployeeID = 6, Department = "Developer", EmployeeName = "Hemanth Kingsley", Salary = 45000 },
                new Employee { EmployeeID = 7, Department = "Technical Support", EmployeeName = "Sudalai Vignesh S", Salary = 29000 },
                new Employee { EmployeeID = 8, Department = "Technical Support", EmployeeName = "Bala Vignesh D", Salary = 35000 },
                new Employee { EmployeeID = 9, Department = "Technical Support", EmployeeName = "Jayanth K", Salary = 33000 },
                new Employee { EmployeeID = 9, Department = "Testing", EmployeeName = "Sanjeev", Salary = 57000 },
            };
        }
        public static void EmployeeSalaryMorethanAverage(List<Employee> employees)
        {
            var employee = _employees.GroupBy(x => x.Department).Select(x => new
            {
                Average = x.Average(x => x.Salary),
                Department = x.Key,
            })
            .ToList();
        }
        public static Dictionary<string, int> WordsFrequency(string sentences)
        {
            var content = sentences.Split(" ");
            var wordFreq = new Dictionary<string, int>();
            foreach (var sentence in content)
            {
                if (wordFreq.ContainsKey(sentence))
                {
                    wordFreq[sentence]++;
                }
                else
                {
                    wordFreq[sentence] = 1;
                }
            }
            return wordFreq;
        }

    }
}

namespace StudentsDepartment
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double Mark { get; set; }
        public int DepartmentID { get; set; }
    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class Program
    {
        private static List<Student> _students;
        private static List<Department> _departments;

        public static void HoldMain()
        {
            /*             
            AssignStudentValues();
            AssignDepartmentValues();
            StudentsWithDepartmentName(_students, _departments);
            GroupByDepartmentName();
             */


            Console.ReadLine();
        }

        public static void StudentsWithDepartmentName(List<Student> students, List<Department> departments)
        {
            var query = from student in students
                        join department in departments on student.DepartmentID equals
                        department.DepartmentID
                        select new
                        {
                            studentName = student.StudentName,
                            departmentName = department.DepartmentName,
                        };
            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }
        public static void AssignStudentValues()
        {
            _students = new List<Student>
            {
                new Student { StudentId=1, StudentName = "Anith Kesava", DepartmentID = 2 },
                new Student { StudentId=2, StudentName = "Balaji S", DepartmentID = 2 },
                new Student { StudentId=3, StudentName = "Abin", DepartmentID = 1 },
                new Student { StudentId=4, StudentName = "Murali Arasan", DepartmentID = 1 },
                new Student { StudentId=5, StudentName = "Vibin Kumar ", DepartmentID = 3 },
                new Student { StudentId=6, StudentName = "Sree Padmanabhan", DepartmentID = 3 },
                new Student { StudentId=7, StudentName = "Kabilan", DepartmentID = 4 },
                new Student { StudentId=8, StudentName = "Ayyapan", DepartmentID = 4 },
            };
        }
        public static void AssignDepartmentValues()
        {
            _departments = new List<Department>
            {
                new Department{ DepartmentID = 1, DepartmentName = "Computer Science" },
                new Department{ DepartmentID = 2, DepartmentName = "Mechanical Engineering" },
                new Department{ DepartmentID = 3, DepartmentName = "EEE" },
                new Department{ DepartmentID = 4, DepartmentName = "IT" },
            };
        }
        public static void GroupByDepartmentName()
        {
            var query = from student in _students
                        join department in _departments on student.DepartmentID equals
                        department.DepartmentID
                        group student by department.DepartmentName
                        into departmentname
                        select new
                        {
                            Departmentname = departmentname.Key,
                            Studentnames = departmentname.Select(x => x.StudentName).ToList(),
                        };
            /*here a new thing which i have learned, 
             * group one table and use the by with another columns table since its a join. 
             */
        }
        public static void StudentsMarks()
        {
            _students = new List<Student>
            {
                new Student { StudentId=1, StudentName = "Anith Kesava", DepartmentID = 2, Mark = 43 },
                new Student { StudentId=2, StudentName = "Balaji S", DepartmentID = 2, Mark = 88 },
                new Student { StudentId=3, StudentName = "Abin", DepartmentID = 1, Mark = 76 },
                new Student { StudentId=4, StudentName = "Murali Arasan", DepartmentID = 1, Mark = 77 },
                new Student { StudentId=5, StudentName = "Vibin Kumar ", DepartmentID = 3, Mark = 80 },
                new Student { StudentId=6, StudentName = "Sree Padmanabhan", DepartmentID = 3, Mark = 89 },
                new Student { StudentId=7, StudentName = "Kabilan", DepartmentID = 4, Mark = 78 },
                new Student { StudentId=8, StudentName = "Ayyapan", DepartmentID = 4, Mark = 64 }
            };
        }
        public static void GroupByGrades()
        {
            string firstGrade = "GradeA";
            string secondGrade = "GradeB";
            string thirdGrade = "GradeC";
            var gradeA = _students.Where(x => x.Mark >= 80).ToList();
            var gradeB = _students.Where(x => x.Mark >= 60 && x.Mark < 80).ToList();
            var gradeC = _students.Where(x => x.Mark < 60).ToList();

            

        }
    }
}
