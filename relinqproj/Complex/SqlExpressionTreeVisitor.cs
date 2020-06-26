using Remotion.Linq.Clauses.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace relinqproj.Complex
{
    public class SqlExpressionTreeVisitor : Remotion.Linq.Parsing.ThrowingExpressionVisitor
    {
        private StringBuilder sql = new StringBuilder();
        private string separator;
        protected override Exception CreateUnhandledItemException<T>(T unhandledItem, string visitMethod)
        {
            return new NotSupportedException($"The expression '{unhandledItem}' (type: {typeof(T)}) is not supported by this LINQ provider.");
        }

        public SqlExpressionTreeVisitor(string separator)
        {
            this.separator = separator;
        }

        public static string GetSqlExpression(Expression exp, string separator = "")
        {
            var visitor = new SqlExpressionTreeVisitor(separator);
            visitor.Visit(exp);
            var str = visitor.sql.ToString();
            if (separator.Length > 0 && str.Length > 0)
                str = str.Remove(str.Length - separator.Length);
            return str;
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            Log("MethodCall: " + expression, logLevel++);
            if (expression.Method == typeof(string).GetMethod("Contains"))
            {
                sql.Append("(");
                Visit(expression.Object);
                sql.Append(" like '%");
                Visit(expression.Arguments[0]);
                sql.Append("%')");
                logLevel--;
                return expression;
            }
            else
                return base.VisitMethodCall(expression);
        }

        protected override Expression VisitQuerySourceReference(QuerySourceReferenceExpression expression)
        {
            Log("QuerySourceReference: " + expression, logLevel++);
            sql.Append(expression.ReferencedQuerySource.ItemName);
            logLevel--;
            return expression;
        }

        protected override Expression VisitBinary(BinaryExpression expression)
        {
            Log("Binary: " + expression, logLevel++);
            sql.Append("(");
            Visit(expression.Left);
            switch (expression.NodeType)
            {
                case ExpressionType.Equal:
                    sql.Append(" = ");
                    break;
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    sql.Append(" and ");
                    break;
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    sql.Append(" or ");
                    break;
                default:
                    return base.VisitBinary(expression);
            }
            Visit(expression.Right);
            sql.Append(")");
            logLevel--;
            return expression;
        }

        protected override Expression VisitConstant(ConstantExpression expression)
        {
            if (expression.Type == typeof(string))
                sql.Append('\'').Append(expression.Value).Append('\'');
            else
                sql.Append(expression.Value);
            return expression;
        }

        protected override Expression VisitMember(MemberExpression expression)
        {
            Log("Member: " + expression, logLevel++);
            Visit(expression.Expression);
            logLevel--;
            sql.Append("." + expression.Member.Name + separator);
            return expression;
        }

        protected override Expression VisitNew(NewExpression expression)
        {
            foreach (var item in expression.Arguments)
                Visit(item);
            return expression;
        }

        int logLevel = 0;
        private void Log(string msg, int level)
        {
            Console.WriteLine("".PadLeft(level * 4) + msg);
        }
    }
}
