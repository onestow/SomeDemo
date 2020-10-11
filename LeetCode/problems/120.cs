using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    /// <summary>
    /// 三角形最小路径和
    /// </summary>
    public class _120 : BaseClass
    {
        public override void Run()
        {
            var tri = new List<IList<int>>
            {
               new List<int>{ 2 },
               new List<int>{ 3, 4 },
               new List<int>{ 6, 5, 7 },
               new List<int>{ 4, 1, 8, 3 },
            };
            var t = MinimumTotal(tri);
            Assert(t, 11);
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int h = triangle.Count;
            var dp = new int[h + 1];
            for (int hi = h - 1; hi >= 0; hi--)
                for (int i = 0; i <= hi; i++)
                {
                    if (dp[i] > dp[i + 1])
                        dp[i] = dp[i + 1];
                    dp[i] += triangle[hi][i];
                }
            return dp[0];
        }
    }
}
