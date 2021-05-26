using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrray - LINQTOObject
            ////create integer array initialise with few numbers
            //int[] numArray = { 4,8,3,10,6};

            ////from the array print even numbers
            ////declarative syntax
            //IEnumerable<int> evenData= from num in numArray where num % 2 == 0 select num;

            ////method syntax - Lambda (input param)=>expression
            //IEnumerable<int> evenData1=numArray.Where(num => num % 2 == 0);

            //foreach(int item in evenData1)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("-----------------------------------");
            ////print square of each number from arrray

            //IEnumerable<int> numArraySquare = from num in numArray orderby num descending select num * num;

            //IEnumerable<int> numArraySquare1 = numArray.OrderBy(n=>n).Select(n => n * n);
            //foreach(int item in numArraySquare1)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Generic collection
            //collection initializer
            List<Employee> empList = new List<Employee>()
            {
                //object initializer
                new Employee { EmpName="bhavana", Address="mumbai", Department="accounts", Salary=15000},
                new Employee { EmpName="vishal", Address="pune", Department="sales", Salary=18000},
                new Employee { EmpName="kavita", Address="mumbai", Department="sales", Salary=25000},
                new Employee { EmpName="amit ", Address="mumbai", Department="accounts", Salary=20000},
                new Employee { EmpName="hemant", Address="pune", Department="sales", Salary=27000},
                new Employee { EmpName="aarti", Address="pune", Department="accounts", Salary=30000},
                new Employee { EmpName="varsha", Address="mumbai", Department="accounts", Salary=15000}
            };

            //where
            //list all emp staying mumbai
            //defered execution query
            IEnumerable<Employee> query1 = from e in empList where e.Address == "mumbai" select e;
            query1 = empList.Where(e => e.Address == "mumbai");

            //immediated execution query
            //ToList()-collection
            IEnumerable<Employee> query2 = (from e in empList where e.Address == "mumbai" select e).ToList();
            query2 = empList.Where(e => e.Address == "mumbai").ToList();

            foreach (Employee item in query2)
            {
                //Console.WriteLine(item);
            }

            //Console.WriteLine("------------------------------------------");
            //-------------------
            empList.Add(new Employee { EmpName = "nancy", Address = "mumbai", Department = "sales", Salary = 25000 });
            foreach (Employee item in query2)
            {
                //  Console.WriteLine(item);
            }

            Console.WriteLine("----------------------------------------");
            //----------------immediate execution method for single record
            //First() / FirstOrDefault() / Single() / SingleOrDefault()
            //search record of vishal
            Employee employee = (from e in empList where e.EmpName == "vishal" select e).Single();
            //method syntax
            employee = empList.Where(e => e.EmpName == "vishal").Single();
            employee = empList.Single(e => e.EmpName == "vishal");
            // Console.WriteLine("search: " +employee);

            //-------------------------- anonymous type
            //Console.WriteLine("----------------------------------------");
            //list empname,dept,salary
            var query4 = from e in empList select new { e.EmpName, job = e.Department, e.Salary };
            query4 = empList.Select(e => new { e.EmpName, job = e.Department, e.Salary });
            foreach (var item in query4)
            {
                //  Console.WriteLine(item.EmpName+" "+item.job+" "+item.Salary+"-"+item.GetType().Name);
            }

            //var is a local variable
            //var cannot be used to declare instance or class level variable
            //var cannot be used to parameter to a method
            //var cannot be used as return type of a method



            //list all emp sort on dept


            //IEnumerable<Employee> query5= from e in empList orderby e.Department select e;
            // query5 = empList.OrderBy(e => e.Department);

            // foreach (var item in query5)
            // {
            //   //  Console.WriteLine(item.EmpName+" "+item.Department);
            // }

            // Console.WriteLine("----------------------------------------");
            // //list all emp sort on dept,within dept on salary h to l
            // IEnumerable<Employee> query7 = from e in empList orderby e.Department,e.Salary descending select e;

            // query7= empList.OrderBy(e => e.Department).ThenByDescending(e=>e.Salary);

            // foreach (var item in query7)
            // {
            //     Console.WriteLine(item);
            //}

            //distinct deptname
            IEnumerable<string> deptnames = (from e in empList select e.Department).Distinct();
            //foreach(string item in deptnames)
            //{
            //    Console.WriteLine(item);
            //}

            //group by
            //account
            //.............
            //..............
            //sales
            //.........
            //.........

            var query9 = from e in empList group e by e.Department;
            query9 = empList.GroupBy(e => e.Department);
            //foreach(var item in query9)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach(var subitem in item)
            //    {
            //        Console.WriteLine("\t" + subitem.EmpName + " " + subitem.Address + " " + subitem.Salary);
            //    }
            //}


            //top 2 highest paid emps
            IEnumerable<Employee> query10 = (from e in empList orderby e.Salary descending select e).Take(2);
            //foreach(Employee item in query10 )
            //{
            //    Console.WriteLine(item);
            //}


            //use of let

            var query8 = from e in empList let bonus = e.Salary * .1m
                         where bonus > 2500
                         orderby bonus
                         select new { e.EmpName, e.Salary, bonus };
            //foreach(var item in query8)
            //{
            //    Console.WriteLine(item.EmpName + " " + item.Salary + " " + item.bonus);
            //}

            //aggregate function
            //total salary of all emps

            //decimal totalSalary = (from e in empList select e).Sum(e => e.Salary);
            //Console.WriteLine("Total Salary of all emps=" + totalSalary);

            //decimal minSalary = (from e in empList select e).Min(e => e.Salary);
            //Console.WriteLine("Min Salary is=" + minSalary);

            //decimal maxSalary = (from e in empList select e).Max(e => e.Salary);
            //Console.WriteLine("Max Salary is=" + maxSalary);

            //decimal avgSalary = (from e in empList select e).Average(e => e.Salary);
            //Console.WriteLine("Average Salary is=" + avgSalary);

            //deptwise total salary
            var query6 = from e in empList
                         group e by e.Department into empgrp
                         select new { dept = empgrp.Key, salsum = empgrp.Sum(e => e.Salary) };
            query6 = empList.GroupBy(e => e.Department).Select(e => new { dept = e.Key, salsum = e.Sum(e => e.Salary) });
            foreach (var item in query6)
            {
                Console.WriteLine(item.dept + " " + item.salsum);
            }

            //accounts  mumbai
            //..................
            //...........
            //accounts pune
            //............
            //...........
            //sales  mumbai
            //.............
            //.............
            //sales  pune
            //................
            //.............


            var query12 = from emp in empList
                          group emp by new{emp.Department, emp.Address};
            query12 = empList.GroupBy(emp => new { emp.Department, emp.Address }).OrderBy(grp => grp.Key.Department);
            foreach (var item in query12)
            {
                Console.WriteLine("/n");
                Console.WriteLine(item.Key.Department+" "+item.Key.Address+" Total Employee=" +item.Count().ToString());
                foreach (var e in item)
                {
                    Console.WriteLine("\t" +e.ToString());
                }
            }

            #endregion


        }
    }
    
}
