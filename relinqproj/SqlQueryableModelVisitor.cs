using Remotion.Linq;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace relinqproj
{
    class SqlQueryableModelVisitor : QueryModelVisitorBase
    {
        private readonly SqlAggregator _queryParts = new SqlAggregator();

        public override void VisitQueryModel(QueryModel queryModel)
        {
            //queryModel.SelectClause.Accept(this, queryModel);
            //queryModel.MainFromClause.Accept(this, queryModel);
            VisitSelectClause(queryModel.SelectClause, queryModel);
            VisitMainFromClause(queryModel.MainFromClause, queryModel);
            VisitBodyClauses(queryModel.BodyClauses, queryModel);
            VisitResultOperators(queryModel.ResultOperators, queryModel);
        }

        public override void VisitSelectClause(SelectClause selectClause, QueryModel queryModel)
        {
            base.VisitSelectClause(selectClause, queryModel);
        }
    }
}
