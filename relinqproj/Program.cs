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

            var res0 = from m in new MyQueryableData<int>(QueryParser.CreateDefault(), new MyQueryableExecutor())
                       where m == 3
                       select m;
            Console.WriteLine(string.Join(", ", res0));

            var res1 = (from m in new MyQueryableData<int>(QueryParser.CreateDefault(), new MyQueryableExecutor())
                        where m == 3
                        select m).Count();
            Console.WriteLine(res1.ToString());

            var res2 = (from m in new MyQueryableData<int>(QueryParser.CreateDefault(), new MyQueryableExecutor())
                        where m == 3
                        select m).FirstOrDefault();
            Console.WriteLine(res2.ToString());
        }
    }

    public class MyQueryableData<T> : QueryableBase<T>
    {
        public MyQueryableData(IQueryProvider provider)
            : base(provider)
        {
        }

        public MyQueryableData(IQueryParser parser, IQueryExecutor executor)
            : base (parser, executor)
        {
        }

        public MyQueryableData(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }
    }

    public class MyQueryableExecutor : IQueryExecutor
    {
        private MyQueryableModelVisitor visitor = new MyQueryableModelVisitor();
        private object[] objs = new object[] { 1, 2, 3, 4, 5, 6 };
        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            queryModel.Accept(visitor);
            Console.WriteLine("ExecuteCollection");
            foreach (var item in objs)
                yield return (T)item;
        }

        public T ExecuteScalar<T>(QueryModel queryModel)
        {
            Console.WriteLine("ExecuteScalar");
            return (T)(objs.Length as object);
        }

        public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
        {
            Console.WriteLine("ExecuteSingle");
            return (T)objs.First();
        }
    }

    public class MyQueryableModelVisitor : QueryModelVisitorBase
    {
    }
}
