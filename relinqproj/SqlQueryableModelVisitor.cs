using Remotion.Linq;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace relinqproj
{
    class SqlQueryableModelVisitor : QueryModelVisitorBase
    {
        private int logLevel = 0;
        private readonly SqlAggregator _queryParts;

        public SqlQueryableModelVisitor()
        {
            _queryParts = new SqlAggregator();
        }

        public string GetSql()
        {
            return _queryParts.GetSql();
        }

        public override void VisitQueryModel(QueryModel queryModel)
        {
            Log("VisitQueryModel: " + queryModel, logLevel++);
            //queryModel.SelectClause.Accept(this, queryModel);
            //queryModel.MainFromClause.Accept(this, queryModel);
            VisitSelectClause(queryModel.SelectClause, queryModel);
            VisitMainFromClause(queryModel.MainFromClause, queryModel);
            VisitBodyClauses(queryModel.BodyClauses, queryModel);
            VisitResultOperators(queryModel.ResultOperators, queryModel);
            logLevel--;
        }

        public override void VisitSelectClause(SelectClause selectClause, QueryModel queryModel)
        {
            Log("VisitSelectClause: " + selectClause, logLevel++);
            _queryParts.SelectPart = SqlExpressionTreeVisitor.GetSqlExpression(selectClause.Selector) + ".*";
            base.VisitSelectClause(selectClause, queryModel);
            logLevel--;
        }

        public override void VisitMainFromClause(MainFromClause fromClause, QueryModel queryModel)
        {
            Log("VisitMainFromClause: " + fromClause, logLevel++);
            _queryParts.AddFromPart(fromClause);
            base.VisitMainFromClause(fromClause, queryModel);
            logLevel--;
        }

        protected override void VisitBodyClauses(ObservableCollection<IBodyClause> bodyClauses, QueryModel queryModel)
        {
            Log("VisitBodyClauses: " + bodyClauses, logLevel++);
            base.VisitBodyClauses(bodyClauses, queryModel);
            logLevel--;
        }

        protected override void VisitResultOperators(ObservableCollection<ResultOperatorBase> resultOperators, QueryModel queryModel)
        {
            Log("VisitResultOperators: " + resultOperators, logLevel++);
            base.VisitResultOperators(resultOperators, queryModel);
            logLevel--;
        }

        public override void VisitWhereClause(WhereClause whereClause, QueryModel queryModel, int index)
        {
            Log($"VisitWhereClause({index}): " + whereClause, logLevel++);
            _queryParts.AddWherePart(SqlExpressionTreeVisitor.GetSqlExpression(whereClause.Predicate));
            base.VisitWhereClause(whereClause, queryModel, index);
            logLevel--;
        }

        public override void VisitOrderByClause(OrderByClause orderByClause, QueryModel queryModel, int index)
        {
            Log($"VisitOrderByClause({index}): " + orderByClause, logLevel++);
            _queryParts.AddOrderByPart(orderByClause.Orderings.Select(item => SqlExpressionTreeVisitor.GetSqlExpression(item.Expression)));
            base.VisitOrderByClause(orderByClause, queryModel, index);
            logLevel--;
        }

        public override void VisitJoinClause(JoinClause joinClause, QueryModel queryModel, int index)
        {
            Log($"VisitJoinClause({index}): " + joinClause, logLevel++);
            _queryParts.AddFromPart(joinClause);
            _queryParts.AddWherePart($"({SqlExpressionTreeVisitor.GetSqlExpression(joinClause.OuterKeySelector)} = {SqlExpressionTreeVisitor.GetSqlExpression(joinClause.InnerKeySelector)})");
            base.VisitJoinClause(joinClause, queryModel, index);
            logLevel--;
        }

        private void Log(string msg, int level)
        {
            return;
            Console.WriteLine("".PadLeft(level * 4) + msg);
        }
    }
}
