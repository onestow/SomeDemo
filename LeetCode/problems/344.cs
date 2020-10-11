using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _344 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public void ReverseString(char[] s)
        {
            int m = s.Length >> 1, r = s.Length - 1;
            char t;
            for (int i = 0; i < m; ++i, --r)
            {
                t = s[i];
                s[i] = s[r];
                s[r] = t;
            }
        }
    }
}
