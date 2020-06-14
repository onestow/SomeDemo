using Remotion.Linq.Clauses.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace relinqproj
{
    public class SqlExpressionTreeVisitor : Remotion.Linq.Parsing.ThrowingExpressionVisitor
    {
        private StringBuilder sql = new StringBuilder();
        protected override Exception CreateUnhandledItemException<T>(T unhandledItem, string visitMethod)
        {
            return new NotSupportedException($"The expression '{unhandledItem}' (type: {typeof(T)}) is not supported by this LINQ provider.");
        }

        public static string GetSqlExpression(Expression exp)
        {
            var visitor = new SqlExpressionTreeVisitor();
            visitor.Visit(exp);
            return visitor.sql.ToString();
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
            sql.Append(expression.Value);
            return expression;
        }

        protected override Expression VisitMember(MemberExpression expression)
        {
            Log("Member: " + expression, logLevel++);
            Visit(expression.Expression);
            logLevel--;
            sql.Append("." + expression.Member.Name);
            return expression;
        }

        int logLevel = 0;
        private void Log(string msg, int level)
        {
            Console.WriteLine("".PadLeft(level * 4) + msg);
        }
    }
}
