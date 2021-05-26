using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Employee
    {
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return string.Format($"EmpName:{EmpName} \tAddress={Address} \tDepartment={Department} \tSalary={Salary}");
        }
    }
}
