using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace SomeDemo.LinqDemo
{
    public class LinqDemo2
    {
        public void Run()
        {
            var q = new Queryable<int>();

            var result = from item in q
                         select item;

            Console.WriteLine(string.Join(Environment.NewLine, result));
            Console.ReadKey(true);
        }
    }

    public class Queryable<T> : IQueryable<T>
    {
        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        //public IEnumerator GetEnumerator() => (Provider.Execute(Expression) as IEnumerable).GetEnumerator();
        public IEnumerator GetEnumerator() => throw new NotImplementedException();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return Provider.Execute<T>(Expression);
        }

        public Queryable(IQueryProvider provider, Expression expression = null)
        {
            Expression = expression ?? Expression.Constant(this);
            Provider = provider;
        }

        public Queryable(Expression expression = null)
            : this(new QueryProvider(), expression)
        {

        }
    }

    public class QueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            //Console.WriteLine("CreateQuery: " + expression);
            //return (IQueryable)Activator.CreateInstance(
            //    typeof(Queryable<>).MakeGenericType(expression.Type),
            //    new object[] { this, expression }
            //    );
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Console.WriteLine("CreateQuery<>: " + expression);
            return new Queryable<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            Console.WriteLine("Execute<>: " + expression);
            return (TResult)(123 as object);
        }
    }
}
