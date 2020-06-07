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
            var ss = new Queryable<int>();

            var t = from item in ss
                         where item == 123
                         select item;

            Console.WriteLine(t.FirstOrDefault().ToString());
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
            AnalysisExpression(expression);
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

        public void AnalysisExpression(Expression exp, int level = 0)
        {
            Console.WriteLine("".PadRight(level * 4) + exp.NodeType.ToString().PadRight(10) + ": " + exp);
            switch (exp.NodeType)
            {
                case ExpressionType.Call:
                    var mce = exp as MethodCallExpression;
                    //Console.WriteLine("The Method Is {0}", mce.Method.Name);
                    for (int i = 0; i < mce.Arguments.Count; i++)
                        AnalysisExpression(mce.Arguments[i], level + 1);
                    break;
                case ExpressionType.Quote:
                    var ue = exp as UnaryExpression;
                    AnalysisExpression(ue.Operand, level + 1);
                    break;
                case ExpressionType.Lambda:
                    var le = exp as LambdaExpression;
                    AnalysisExpression(le.Body, level + 1);
                    break;
                case ExpressionType.Equal:
                    var be = exp as BinaryExpression;
                    //Console.WriteLine("The Method Is {0}", exp.NodeType.ToString());
                    AnalysisExpression(be.Left, level + 1);
                    AnalysisExpression(be.Right, level + 1);
                    break;
                case ExpressionType.Constant:
                    var ce = exp as ConstantExpression;
                    //Console.WriteLine("The Value Type Is {0}", ce.Value.ToString());
                    break;
                case ExpressionType.Parameter:
                    var pe = exp as ParameterExpression;
                    //Console.WriteLine("The Parameter Is {0}", pe.Name);
                    break;
                default:
                    Console.Write("UnKnow");
                    break;
            }
        }
    }
}
