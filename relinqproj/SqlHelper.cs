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
            List<MemberBinding> bindings = new List<MemberBinding>();

            var outProps = typeof(Tout).GetProperties().Where(item => item.CanWrite);
            foreach(var outProp in outProps)
            {
                var methodInfo = typeof(DataReaderExtensions).GetMethod("GetFieldValue").MakeGenericMethod(outProp.PropertyType);
                var callExp = Expression.Call(methodInfo, parameterExp, Expression.Constant(outProp.Name));
                var binding = Expression.Bind(outProp, callExp);
                bindings.Add(binding);
            }

            var initExp = Expression.MemberInit(Expression.New(typeof(Tout)), bindings);
            return Expression.Lambda<Func<SqliteDataReader, Tout>>(initExp, parameterExp).Compile();
        }
    }
}
