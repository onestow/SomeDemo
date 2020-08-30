using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _332 : BaseClass
    {
        public override void Run()
        {
            var fff = FindItinerary(new IList<string>[]
            {
new string[]{"MUC", "LHR" }, new string[]{"JFK", "MUC" }, new string[]{"SFO", "SJC" }, new string[]{ "LHR", "SFO" }
            });
        }

        string[] ans;
        bool[] visited;
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var orderArr = tickets.OrderBy(item => item[1]).ToArray();
            ans = new string[tickets.Count + 1];
            visited = new bool[tickets.Count];
            ans[0] = "JFK";
            dfs(orderArr, 0);
            return ans;
        }

        private bool dfs(IList<string>[] arr, int ai)
        {
            if (ai == arr.Length)
                return true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (visited[i] || arr[i][0] != ans[ai])
                    continue;

                visited[i] = true;
                ans[ai+1] = arr[i][1];
                if (dfs(arr, ai + 1))
                    return true;
                visited[i] = false;
            }
            return false;
        }
    }
}
