using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SomeDemo.LinqDemo
{
    public class LinqDemo2
    {
        public void Run()
        {
            string[] strs = new string[] { "Alice", "Jerry", "Tom", "Jim" };
            var res = strs
                .Where(s => { Console.WriteLine(s + " where"); return s.StartsWith("J"); })
                .Select(s => { Console.WriteLine(s + " select"); return s + " --"; })
                ;
            foreach (var s in res)
            {
                Console.ReadKey(true);
            }
        }
    }

    public class Queryable<T> : IQueryable<T>
    {
        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public IEnumerator GetEnumerator() => (Provider.Execute(Expression) as IEnumerable).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (Provider.Execute(Expression) as IEnumerable<T>).GetEnumerator();

        public Queryable(IQueryProvider provider, Expression expression)
        {
            Expression = expression;
            Provider = provider;
        }
    }

    public class QueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new Queryable<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
