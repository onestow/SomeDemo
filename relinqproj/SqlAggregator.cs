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

        public string GetSql()
        {
            if (string.IsNullOrWhiteSpace(SelectPart) || FromParts.Count == 0)
                throw new InvalidOperationException("select字段和from字段不能为空");

            var sql = $@"
select {SelectPart}
  from {string.Join(", ", FromParts)}";
            if (WhereParts.Count > 0)
                sql += Environment.NewLine + " where " + string.Join(" and ", WhereParts);
            if (OrderByParts.Count > 0)
                sql += Environment.NewLine + " order by " + string.Join(", ", OrderByParts);
            return sql;
        }
    }
}
