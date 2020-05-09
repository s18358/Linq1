using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            Console.WriteLine("Przykład 1 query syntax");
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            foreach (var r in res)
            {
                Console.WriteLine(r);
            }


            //2. Lambda and Extension methods
            Console.WriteLine("Przykład 1 lambda");
            var r2 = Emps.Where(e => e.Job == "Backend programmer");
            foreach (var r in r2)
                Console.WriteLine(r);
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            Console.WriteLine("Przykład 2");
            var r2 = Emps.Where(e => e.Job == "Frontend programmer" && e.Salary >= 1000);
            foreach (var r in r2.OrderByDescending(e => e.Ename))
            {
                Console.WriteLine(r);
            }
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            Console.WriteLine("Przykład 3");
            var res = Emps.Max(e => e.Salary);
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            Console.WriteLine("Przykład 4");
            var max = Emps.Max(e => e.Salary);
            var res = Emps.Where(e => e.Salary == max);
            res.ToList().ForEach(r => Console.WriteLine(r));

        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            Console.WriteLine("Przykład 5");
            //Jeżeli zobaczy Pan ten komentarz prosiłbym w ocenie jeżeli może Pan napisać czy w Lambda da się wartość przyjąć coś w rodzaju var res = Emps.All(e => e.Ename  != null as Nazwisko)
           /*var res = Emps.Select(e => e.Ename as "Nazwisko");
           foreach(var r in res)
             {
                 Console.WriteLine(r);
             }
           */
            var res2 = from emp in Emps
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Praca = emp.Job
                      };
            res2.ToList().ForEach(e => Console.WriteLine(e));
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            Console.WriteLine("Przykład 6");
            //var res = Emps.Join(Depts, eid => eid.Deptno, did => did.Deptno, (eid, did) => new { Eid = eid, Did = did }).Where(s => s.Eid.Deptno == s.Did.Deptno);
            // foreach (var r in res)
            // {
            //     Console.WriteLine(r);
            // }


            var res2 = from values in Emps.
                      Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new { emp, dept })
                       select new
                       {
                           values.emp.Ename,
                           values.emp.Job,
                           values.dept.Dname
                       };
            res2.ToList().ForEach(x => Console.WriteLine(x));

        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            Console.WriteLine("Przykład 7");
            var res = from emp in Emps
                      group emp by emp.Job into empGroup
                      select new
                      {
                          Praca = empGroup.Key,
                          LiczbaPracownikow = (from emp in Emps
                                               where emp.Job == empGroup.Key
                                               select emp).Count()
                      };
            res.ToList().ForEach(r => Console.WriteLine(r));


        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            Console.WriteLine("Przykład 8");
            bool isThere = Emps.Any(e => e.Job == "Backend programmer");
            Console.WriteLine(isThere);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            Console.WriteLine("Przykład 9");
            var res = Emps.Where(e => e.Job == "Frontend programmer").OrderByDescending(e => e.Ename);
            Console.WriteLine(res.First());
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10()
        {
            Console.WriteLine("Przykład 10");
            var union = from emp in Emps
                      select new
                      {
                          emp.Ename,
                          emp.Job,
                          emp.HireDate
                      };

            var union2 = new List<Object>();
            union2.Add(new Emp
            {
                Ename = "Brak wartości",
                Job = null,
                HireDate = null
            });

            var res = union.Union(union2);
            res.ToList().ForEach(r => Console.WriteLine(r));
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            Console.WriteLine("Przykład 11");
            var res = Emps.Select(e => e.Salary).Aggregate((x, y) => x > y ? x : y);
            Console.WriteLine(res);
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            Console.WriteLine("Przykład 12");
            var res = from emp in Emps
                      from dept in Depts
                      select new
                      {
                          emp.Ename,
                          dept.Dname
                      };
            res.ToList().ForEach(r => Console.WriteLine(r));
        }
    }
}
