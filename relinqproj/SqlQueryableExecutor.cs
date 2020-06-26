using Remotion.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relinqproj
{
    class SqlQueryableExecutor : IQueryExecutor
    {
        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            var visitor = new Complex.SqlQueryableModelVisitor();
            //var visitor = new Simple.SqlQueryableModelVisitor();
            visitor.VisitQueryModel(queryModel);
            var sql = visitor.GetSql();
            Console.WriteLine("result sql: " + Environment.NewLine + sql);
            return SqlHelper.Query<T>(sql);
        }

        public T ExecuteScalar<T>(QueryModel queryModel)
        {
            return ExecuteCollection<T>(queryModel).Single();
        }

        public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
        {
            var res = ExecuteCollection<T>(queryModel);
            return returnDefaultWhenEmpty
                ? res.SingleOrDefault()
                : res.Single();
        }
    }
}
