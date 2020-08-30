using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _696 : BaseClass
    {
        public override void Run()
        {
            var t = CountBinarySubstrings("00110011");
            Assert(t, 6);
            t = CountBinarySubstrings("");
            Assert(t, 0);
            t = CountBinarySubstrings("100111001");
            Assert(t, 0);
        }

        public int CountBinarySubstrings(string s)
        {
            int pre = 0, cur = 1, res = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    cur += 1;
                else
                {
                    res += cur > pre ? pre : cur;
                    pre = cur;
                    cur = 1;
                }
            }
            return res + Math.Min(cur, pre);
        }
    }
}
