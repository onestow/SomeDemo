using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace relinqproj
{
    class SqlQueryable<T> : QueryableBase<T>
    {
        public SqlQueryable(IQueryProvider provider)
            : base(provider)
        {
        }

        public SqlQueryable(IQueryParser parser, IQueryExecutor executor)
            : base (parser, executor)
        {
        }

        public SqlQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        public SqlQueryable(IQueryExecutor executor)
            : this(QueryParser.CreateDefault(), executor)
        {
        }
    }
}
