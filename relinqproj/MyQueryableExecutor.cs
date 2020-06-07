using Remotion.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace relinqproj
{
    class MyQueryableExecutor : IQueryExecutor
    {
        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            var visitor = new MyQueryableModelVisitor();
            yield return (T)(1 as object);
            yield return (T)(2 as object);
            yield return (T)(3 as object);
            yield return (T)(4 as object);
            yield return (T)(5 as object);
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
