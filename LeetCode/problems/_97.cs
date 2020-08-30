using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _97 : BaseClass
    {
        public override void Run()
        {
            var t = IsInterleave("aabcc", "dbbca", "aadbbcbcac");
            Assert(t, true);
            t = IsInterleave("aabcc", "dbbca", "aadbbbaccc");
            Assert(t, false);
            t = IsInterleave("a", "", "c");
            Assert(t, false);
            t = IsInterleave("", "", "");
            Assert(t, true);
        }

        #region dfs
        string s1, s2, s3;
        int[,] visited;
        public bool IsInterleave2(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            visited = new int[s1.Length + 1, s2.Length + 1];
            visited[s1.Length, s2.Length] = 1;
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            return dfs(0, 0);
        }

        private bool dfs(int i1, int i2)
        {
            if (visited[i1, i2] == 0)
            {
                if (i1 < s1.Length && s1[i1] == s3[i1 + i2] && dfs(i1 + 1, i2)
                    || i2 < s2.Length && s2[i2] == s3[i1 + i2] && dfs(i1, i2 + 1))
                    visited[i1, i2] = 1;
                else
                    visited[i1, i2] = -1;
            }
            return visited[i1, i2] == 1;
        }
        #endregion

        #region dp
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            var dp = new bool[s2.Length + 1];
            var lastVal = false;
            for (int i1 = 0; i1 <= s1.Length; i1++)
                for (int i2 = 0; i2 <= s2.Length; i2++)
                {
                    var i3 = i1 + i2 - 1;
                    if (i1 > 0 && dp[i2] && s1[i1 - 1] == s3[i3]
                        || i2 > 0 && lastVal && s2[i2 - 1] == s3[i3])
                        dp[i2] = true;
                    else
                        dp[i2] = false;
                    if (i1 == 0 && i2 == 0) dp[0] = true;
                    lastVal = dp[i2];
                }
            return dp[s2.Length];
        }
        #endregion
    }
}
