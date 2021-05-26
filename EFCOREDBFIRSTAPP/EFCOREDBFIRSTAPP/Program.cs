using System;
using EFCOREDBFIRSTAPP.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFCOREDBFIRSTAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainingContext db = new TrainingContext();
            // IEnumerable<Emp> empdata = db.Emps.ToList();

            // foreach(Emp item in empdata)
            // {
            //     //Console.WriteLine(item.Empno + " " + item.Ename + " " + item.Job + " " + item.Sal + " " + item.Deptno);
            // }


            // //list all emps as per the job
            // IEnumerable<Emp> empdata1 = db.Emps.OrderBy(e => e.Job);

            // foreach (Emp item in empdata1)
            // {
            //    // Console.WriteLine(item.Ename+" "+item.Job);
            // }

            // //print total sal
            // var sumSal = db.Emps.Sum(e => e.Sal);

            //// Console.WriteLine("Total Salary of all emps=" +sumSal);



            // //print total sal for each dept
            // var query1 = db.Emps.GroupBy(e => e.Deptno).Select(e => new
            // {
            //     dept = e.Key,
            //     salsum = e.Sum(e => e.Sal)

            // });
            // foreach( var item in query1)
            // {
            //     Console.WriteLine(item.dept + "" + item.salsum);
            // }

            // //list dept and emps for that dept
            // //10
            // //....
            // //....
            // //20
            // //....
            // //....
            // var query2 = from e in db.Emps group e by e.Deptno;
            // foreach(var item in query2)
            // {
            //     Console.WriteLine(item.Key);
            //     foreach(var row in item)
            //     {
            //         Console.WriteLine(row.Ename + " " + row.Job);
            //     }
            // }


            //join

            //empname, job,sal,deptname

            //inner join
            var joinData = from e in db.Emps
                           join d in db.Depts
                           on e.Deptno equals d.Deptno
                           select new { EmpName = e.Ename, e.Job, e.Sal, DeptName = d.Dname };
            var joinData1 = db.Emps.Join(db.Depts, e => e.Deptno, d => d.Deptno, (e, d) => new { e.Ename, d.Dname });

            //foreach(var item in joinData)
            //{
            //    Console.WriteLine(item.EmpName + " " + item.Job + " " + item.Sal + " "+item.DeptName);
            //}

            //left outer join
            //King

            var joinData2 = from e in db.Emps join d in db.Depts on e.Deptno equals d.Deptno into empdept from dept in empdept.DefaultIfEmpty() select new {e.Ename,dept.Dname};

            foreach(var item in joinData2)
            {
                Console.WriteLine(item.Ename+" "+item.Dname);
            }
        }
    }
}
