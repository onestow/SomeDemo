using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _392 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsSubsequence(string s, string t)
        {
            int si = 0, ti = 0;
            int lent = t.Length, lens = s.Length;
            while (ti < lent && si < lens)
            {
                if (s[si] == t[ti])
                    ++ti;
                ++si;
            }
            return ti == lent;
        }
    }
}
