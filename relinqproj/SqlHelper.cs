using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace relinqproj
{
    public class SqlHelper
    {
        public static IEnumerable<T> Query<T>(string sql)
        {
            using var conn = new SqliteConnection("Data Source=db.sqlite3");
            var command = new SqliteCommand(sql, conn);
            conn.Open();
            var reader = command.ExecuteReader();

            var func = GetReaderToEntityFunc<T>();
            while (reader.Read())
                yield return func(reader);
        }

        private static Func<SqliteDataReader, Tout> GetReaderToEntityFunc<Tout>()
        {
            var inType = typeof(SqliteDataReader);
            var parameterExp = Expression.Parameter(inType, "dataReader");

            Expression finalExp;
            if (typeof(Tout).IsValueType || typeof(Tout) == typeof(string))//值类型
            {
                var methodInfo = inType.GetMethod("GetFieldValue").MakeGenericMethod(typeof(Tout));
                finalExp = Expression.Call(parameterExp, methodInfo, Expression.Constant(0, typeof(int)));
            }
            else
            {
                int index = 0;
                finalExp = GetNewExpression(typeof(Tout), parameterExp, ref index);
            }
            return Expression.Lambda<Func<SqliteDataReader, Tout>>(finalExp, parameterExp).Compile();
        }

        private static Expression GetNewExpression(Type typeOut, ParameterExpression parameterExp, ref int index)
        {
            if (typeOut.GetConstructor(new Type[0]) == null)//针对匿名类
            {
                var props = typeOut.GetProperties();
                var constructor = typeOut.GetConstructor(props.Select(item => item.PropertyType).ToArray())
                    ?? throw new Exception("datareader转实体失败: 找不到指定参数的构造函数");

                var argExps = new List<Expression>();
                foreach(var prop in props)
                {
                    var callExp = GetReaderValueExp(prop, parameterExp, ref index);
                    argExps.Add(callExp);
                }

                return Expression.New(constructor, argExps);
            }
            else//有无参构造函数的类
            {
                List<MemberBinding> bindings = new List<MemberBinding>();

                var props = typeOut.GetProperties().Where(item => item.CanWrite);
                foreach(var outProp in props)
                {
                    var callExp = GetReaderValueExp(outProp, parameterExp, ref index);
                    var binding = Expression.Bind(outProp, callExp);
                    bindings.Add(binding);
                }

                return Expression.MemberInit(Expression.New(typeOut), bindings);
            }
        }

        private static Expression GetReaderValueExp(PropertyInfo prop, ParameterExpression parameterExp, ref int index)
        {
            if (prop.PropertyType.IsValueType || prop.PropertyType == typeof(string))
            {
                //var methodInfo = typeof(DataReaderExtensions).GetMethod("GetFieldValue").MakeGenericMethod(prop.PropertyType);
                //var callExp = Expression.Call(methodInfo, parameterExp, Expression.Constant(prop.Name));
                var methodInfo = parameterExp.Type.GetMethod("GetFieldValue").MakeGenericMethod(prop.PropertyType);
                var callExp = Expression.Call(parameterExp, methodInfo, Expression.Constant(index, typeof(int)));
                index += 1;
                return callExp;
            }
            else
                return GetNewExpression(prop.PropertyType, parameterExp, ref index);
        }
    }
}
