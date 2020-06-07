using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace relinqproj
{
    class MyQueryable<T> : QueryableBase<T>
    {
        public MyQueryable(IQueryProvider provider)
            : base(provider)
        {
        }

        public MyQueryable(IQueryParser parser, IQueryExecutor executor)
            : base (parser, executor)
        {
        }

        public MyQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

    }
}
