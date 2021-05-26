using System;

namespace TypeDemoApp
{
    struct Employee
    {
        public int EmpId;
        public string EmpName;
        public double Salary;

        public override string ToString()
        {
            return string.Format($"EmpId:{EmpId} EmpName:{EmpName} Salary :{Salary}");
        }
        public Employee(int eid, string ename, double salary)
        {
            EmpId = eid;
            EmpName = ename;
            Salary = salary;

        }
    }


        enum Months
        {
            jan = 1, feb, mar, apr, may, jun, jl, aug, sep, oct, nov, dec
        }

        class Program
        {
            static void Main(string[] args)
            {
                Employee employee = new(101, "Ankita", 30000);
                Console.WriteLine(employee); ;

                Console.WriteLine(DayOfWeek.Sunday + "=" + (int)DayOfWeek.Sunday);

            }
        
    }
}
