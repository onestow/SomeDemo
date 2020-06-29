using Microsoft.EntityFrameworkCore;
using relinqproj.EF;
using relinqproj.Entity;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

namespace relinqproj
{
    class Program
    {
        static DbSet<Person> dbPerson;
        static void Main(string[] args)
        {
            EfTest();
            var res0 = from m in new SqlQueryable<Person>()
                       join c in new SqlQueryable<Course>() on m.ID equals c.PersonID into grd
                       from g in grd.DefaultIfEmpty()
                       where m.ID == 1 && (m.Name == "Alice" || m.ID == 1)
                       select new { m.ID, m, g };
                       //select m.Name;
                       //select new { A = m.ID, B = m.Name, C = c.CourseName, D = c.ID };
                       //select new { m.ID, m.Name };
                       //select m.ID;
                       //select new { m, c };

            Console.WriteLine(string.Join(Environment.NewLine, res0));
            var res1 = from m in new SqlQueryable<Person>()
                       from c in new SqlQueryable<Course>()
                       where m.ID == c.PersonID
                       orderby c.ID descending
                       select new { m, c };
            Console.WriteLine(string.Join(Environment.NewLine, res1));

            //var res1 = (from m in new SqlQueryable<int>(QueryParser.CreateDefault(), new SqlQueryableExecutor())
            //            where m == 3
            //            select m).Count();
            //Console.WriteLine(res1.ToString());

            //var res2 = (from m in new SqlQueryable<int>(QueryParser.CreateDefault(), new SqlQueryableExecutor())
            //            where m == 3
            //            select m).FirstOrDefault();
            //Console.WriteLine(res2.ToString());
            Console.ReadKey(true);
        }

        static void EfTest()
        {
            using var db = new MyDbContext();
            var res0 = from p in db.Person
                       join c in db.Course.Where(c => c.CourseName == "Math") on p.ID equals c.PersonID into cs
                       from c0 in cs.DefaultIfEmpty()
                       select new { p, c0 };
            Console.WriteLine(string.Join(Environment.NewLine, res0));
            var res1 = from p in db.Person
                       from c in db.Course
                       where p.ID == c.PersonID
                       select new { p, c };
            Console.WriteLine(string.Join(Environment.NewLine, res1));
            var res2 = from p in db.Person
                       join c in db.Course on p.ID equals c.PersonID
                       select new { p, c };
            Console.WriteLine(string.Join(Environment.NewLine, res2));
            Console.WriteLine();
        }
    }
}
