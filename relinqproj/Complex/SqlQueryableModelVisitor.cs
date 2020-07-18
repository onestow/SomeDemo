using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Clauses.Expressions;
using Remotion.Linq.Clauses.ResultOperators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace relinqproj.Complex
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
            _queryParts.SelectPart = SqlExpressionTreeVisitor.GetSqlExpression(selectClause.Selector, ",");
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

        public override void VisitResultOperator(ResultOperatorBase resultOperator, QueryModel queryModel, int index)
        {
            base.VisitResultOperator(resultOperator, queryModel, index);
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

            var orderings = orderByClause.Orderings;
            _queryParts.AddOrderByPart(orderings.Select(item => SqlExpressionTreeVisitor.GetSqlExpression(item.Expression) + " " + item.OrderingDirection));
            base.VisitOrderByClause(orderByClause, queryModel, index);
            logLevel--;
        }

        public override void VisitJoinClause(JoinClause joinClause, QueryModel queryModel, int index)
        {
            Log($"VisitJoinClause({index}): " + joinClause, logLevel++);
            _queryParts.AddJoinPart("inner", joinClause, GetFilter(joinClause));
            base.VisitJoinClause(joinClause, queryModel, index);
            logLevel--;
        }

        Dictionary<string, GroupJoinClause> dictGroupJoin = new Dictionary<string, GroupJoinClause>();
        public override void VisitJoinClause(JoinClause joinClause, QueryModel queryModel, GroupJoinClause groupJoinClause)
        {
            dictGroupJoin.Add(groupJoinClause.ItemName, groupJoinClause);
            base.VisitJoinClause(joinClause, queryModel, groupJoinClause);
        }

        public override void VisitAdditionalFromClause(AdditionalFromClause fromClause, QueryModel queryModel, int index)
        {
            string joinType;
            if (fromClause.FromExpression is ConstantExpression)
            {
                joinType = "cross";
                _queryParts.AddJoinPart(joinType, fromClause);
            }
            else
            {
                QuerySourceReferenceExpression qsrExp;
                if (fromClause.FromExpression is SubQueryExpression sqExp)
                {
                    if (sqExp.QueryModel.ResultOperators.Count != 1 || !(sqExp.QueryModel.ResultOperators.First() is DefaultIfEmptyResultOperator))
                        throw new MethodAccessException("from语句中只能使用DefaultIfEmpty方法");
                    joinType = "left";
                    qsrExp = sqExp.QueryModel.MainFromClause.FromExpression as QuerySourceReferenceExpression;
                }
                else
                {
                    joinType = "inner";
                    qsrExp = fromClause.FromExpression as QuerySourceReferenceExpression;
                }
                if (qsrExp == null)
                    throw new Exception("无法获取QuerySourceReferenceExpression");
                var joinClause = dictGroupJoin[qsrExp.ReferencedQuerySource.ItemName].JoinClause;
                var strFilter = GetFilter(joinClause, fromClause.ItemName);
                _queryParts.AddJoinPart(joinType, fromClause, strFilter);
            }
            base.VisitAdditionalFromClause(fromClause, queryModel, index);
        }

        private string GetFilter(JoinClause joinClause, string newItemName = null)
        {
            //TODO
            var filter = $"({SqlExpressionTreeVisitor.GetSqlExpression(joinClause.OuterKeySelector)} = {SqlExpressionTreeVisitor.GetSqlExpression(joinClause.InnerKeySelector)})";
            if (newItemName != null)
                filter = filter.Replace($"\"{joinClause.ItemName}\".", $"\"{newItemName}\".");
            return filter;
        }

        private void Log(string msg, int level)
        {
            return;
            Console.WriteLine("".PadLeft(level * 4) + msg);
        }
    }
}
