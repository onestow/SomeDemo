using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _647 : BaseClass
    {
        public override void Run()
        {
            Assert(CountSubstrings("aaa"), 6);
        }

        public int CountSubstrings(string s)
        {
            int ans = s.Length;
            for (int i = s.Length - 1; i > 0; i--)
            {
                for (int j = 1; i + j < s.Length && i - j >= 0 && s[i + j] == s[i - j]; j++)
                    ans += 1;
                for (int j = 1; i + j <= s.Length && i - j >= 0 && s[i + j - 1] == s[i - j]; j++)
                    ans += 1;
            }
            return ans;
        }
    }
}
