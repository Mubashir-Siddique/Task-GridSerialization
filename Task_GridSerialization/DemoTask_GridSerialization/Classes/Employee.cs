using System;

namespace DemoTask_GridSerialization
{
    [Serializable]
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? Age { get; set; }
        public int? Experience { get; set; }
        public int? Salary { get; set; }

        /*public Employee(int Id, string name, int age, int exp, int salary)
        {
            this.EmployeeId = Id;
            this.EmployeeName = name;
            this.Age = age;
            this.Experience = exp;
            this.Salary = salary;
        }*/
    }
}