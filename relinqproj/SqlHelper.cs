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
            if (typeof(Tout).IsValueType)//值类型
            {
                var methodInfo = inType.GetMethod("GetFieldValue").MakeGenericMethod(typeof(Tout));
                finalExp = Expression.Call(parameterExp, methodInfo, Expression.Constant(0, typeof(int)));
            }
            else if (typeof(Tout).GetConstructor(new Type[0]) == null)//针对匿名类
            {
                var props = typeof(Tout).GetProperties();
                var constructor = typeof(Tout).GetConstructor(props.Select(item => item.PropertyType).ToArray())
                    ?? throw new Exception("datareader转实体失败: 找不到指定参数的构造函数");

                var argExps = new List<Expression>();
                foreach(var prop in props)
                {
                    var callExp = GetReaderValueExp(prop, parameterExp);
                    argExps.Add(callExp);
                }

                finalExp = Expression.New(constructor, argExps);
            }
            else//有无参构造函数的类
            {
                List<MemberBinding> bindings = new List<MemberBinding>();

                var props = typeof(Tout).GetProperties().Where(item => item.CanWrite);
                foreach(var outProp in props)
                {
                    var callExp = GetReaderValueExp(outProp, parameterExp);
                    var binding = Expression.Bind(outProp, callExp);
                    bindings.Add(binding);
                }

                finalExp = Expression.MemberInit(Expression.New(typeof(Tout)), bindings);
            }
            return Expression.Lambda<Func<SqliteDataReader, Tout>>(finalExp, parameterExp).Compile();
        }

        private static MethodCallExpression GetReaderValueExp(PropertyInfo prop, ParameterExpression parameterExp)
        {
            var methodInfo = typeof(DataReaderExtensions).GetMethod("GetFieldValue").MakeGenericMethod(prop.PropertyType);
            var callExp = Expression.Call(methodInfo, parameterExp, Expression.Constant(prop.Name));
            return callExp;
        }
    }
}
