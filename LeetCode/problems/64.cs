using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _64 : BaseClass
    {
        public override void Run()
        {
            var t = MinPathSum(new int[][]
            {
                new int[]{1,3, 1},
                new int[]{1,5, 1},
                new int[]{4,2, 1},
            });
            Assert(t, 7);
        }

        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            if (m == 0)
                return 0;
            int n = grid[0].Length;
            if (n == 0)
                return 0;
            var dp = new int[n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        dp[j] = grid[i][j];
                    else
                    {
                        var t = int.MaxValue;
                        if (j > 0)
                            t = Math.Min(dp[j - 1], t);
                        if (i > 0)
                            t = Math.Min(dp[j], t);
                        dp[j] = grid[i][j] + t;
                    }
                }
            return dp[n - 1];
        }
    }
}
