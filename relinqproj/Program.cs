using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Parsing.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace relinqproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var res0 = from m in new SqlQueryable<int>(QueryParser.CreateDefault(), new SqlQueryableExecutor())
                       where m == 3
                       select m;
            Console.WriteLine(string.Join(", ", res0));

            var res1 = (from m in new SqlQueryable<int>(QueryParser.CreateDefault(), new SqlQueryableExecutor())
                        where m == 3
                        select m).Count();
            Console.WriteLine(res1.ToString());

            var res2 = (from m in new SqlQueryable<int>(QueryParser.CreateDefault(), new SqlQueryableExecutor())
                        where m == 3
                        select m).FirstOrDefault();
            Console.WriteLine(res2.ToString());
        }
    }
}
