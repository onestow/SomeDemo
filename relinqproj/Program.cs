using System;
using System.Globalization;
using System.Linq;

namespace relinqproj
{
    class Program
    {
        static void Main(string[] args)
        {
            var res0 = from m in new SqlQueryable<Person>()
                       join c in new SqlQueryable<Course>() on m.ID equals c.PersonID
                       where m.ID == 1 && (m.Name == "Alice" || m.ID == 1)
                       select new { m.ID, m, c };
                       //select m.Name;
                       //select new { A = m.ID, B = m.Name, C = c.CourseName, D = c.ID };
                       //select new { m.ID, m.Name };
                       //select m.ID;
                       //select new { m, c };
            var res = res0.ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, res0));

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
    }

    class Person
    {
        public Person() { }
        public Person(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ID + "|" + Name;
        }
    }

    class Course
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string CourseName { get; set; }
        public override string ToString()
        {
            return ID + "|" + PersonID + "|" + CourseName;
        }
    }
}
