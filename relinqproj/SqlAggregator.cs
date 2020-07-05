using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace relinqproj
{
    class SqlAggregator
    {
        public string SelectPart { get; set; }
        private List<string> FromParts { get; set; } = new List<string>();
        private List<string> WhereParts { get; set; } = new List<string>();
        private List<string> OrderByParts { get; set; } = new List<string>();
        private List<string> JoinParts { get; set; } = new List<string>();

        public void AddFromPart(IQuerySource querySource)
        {
            FromParts.Add($"{querySource.ItemType.Name} {querySource.ItemName}");
        }

        public void AddWherePart(string str)
        {
            WhereParts.Add(str);
        }

        public void AddOrderByPart(IEnumerable<string> orders)
        {
            OrderByParts.Insert(0, string.Join(", ", orders));
        }

        public void AddJoinPart(string joinType, IQuerySource querySource, string filter = null)
        {
            AddJoinPart(joinType, querySource.ItemType.Name, querySource.ItemName, filter);
        }

        public void AddJoinPart(string joinType, string tableName, string shortName, string filter = null)
        {
            var strJoin = $"{joinType} join {tableName} {shortName}";
            if (!string.IsNullOrWhiteSpace(filter))
                strJoin += " on " + filter;
            JoinParts.Add(strJoin);
        }

        public string GetSql()
        {
            if (string.IsNullOrWhiteSpace(SelectPart) || FromParts.Count == 0)
                throw new InvalidOperationException("select字段和from字段不能为空");

            var sql = $@"
select {SelectPart}
  from {string.Join(", ", FromParts)}
 {string.Join(Environment.NewLine, JoinParts)}";
            if (WhereParts.Count > 0)
                sql += Environment.NewLine + " where " + string.Join(" and ", WhereParts);
            if (OrderByParts.Count > 0)
                sql += Environment.NewLine + " order by " + string.Join(", ", OrderByParts);
            return sql;
        }
    }
}
