using System;
using System.Globalization;
using System.Linq;

namespace relinqproj
{
    class Program
    {
        static void Main(string[] args)
        {
            var res0 = from m in new SqlQueryable<Person>(new SqlQueryableExecutor())
                       where m.ID == 2 && (m.Name == "Alice" || m.ID == 1)
                       select m.ID;

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
}
