using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SomeDemo
{
    public class ExpressionDemo
    {
        public void Run()
        {
            var arr = new List<int[]>();
            arr.Add(new int[] { 1, 2, 3 });
            arr.Add(new int[] { 4 });
            arr.Add(new int[] { 5, 6 });
            var res = arr.SelectMany((item, i)=> $"{i}").ToArray();
            Test1();
        }

        public void Test0()
        {
            var loopBody = Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Hello"));
            var loop = Expression.Loop(loopBody);
            var exp = Expression.Lambda<Action>(loop);
            exp.Compile().Invoke();
        }

        public void Test1()
        {
            var number1Par = Expression.Parameter(typeof(int), "number");
            var number2Par = Expression.Parameter(typeof(int), "number");
            var block = Expression.Block(
                new[] { number1Par, number2Par },
                Expression.Assign(number1Par, Expression.Constant(2)),
                Expression.AddAssign(number1Par, Expression.Constant(5)),
                Expression.DivideAssign(number1Par, Expression.Constant(2)),
                Expression.Constant(7)
                );
            //A:  怎么定义输出什么值
            //Q:  最后一个式子的值为返回值
            //A:  怎么主动调用return
            var res = Expression.Lambda<Func<int>>(block).Compile().Invoke();
            Console.WriteLine(res);

        }

        public void Test2()
        {
            ParameterExpression par = Expression.Parameter(typeof(TestObj), "obj");
            MemberExpression mem = Expression.Property(par, "A");
            var exp2 = Expression.Lambda<Func<TestObj, string>>(mem, par);
            var f2 = exp2.Compile();
            Console.WriteLine(exp2 + " " + f2(new TestObj() { A = "12gn" }));
        }

        public T_Out Copy<T_In, T_Out>(List<T_In> objs)
            where T_Out : new()
        {
            var typeIn = typeof(T_In);
            var typeOut = typeof(T_Out);
            foreach(var propIn in typeIn.GetProperties(BindingFlags.Public))
            {
                var propOut = typeOut.GetProperty(propIn.Name);
                if (propOut == null)
                    continue;

                if (propOut.PropertyType != propIn.PropertyType)
                    continue;


            }
            return default(T_Out);
            //var copyObjs = new List<T_Out>();
        }
    }
    public class TestObj
    {
        public string A { get; set; }
        public int B { get; set; }
    }
}
