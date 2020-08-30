using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _201 : BaseClass
    {
        public override void Run()
        {
            int t;
            t = RangeBitwiseAnd(5, 7);
            Assert(t, 4);
            t = RangeBitwiseAnd(4, 8);
            Assert(t, 0);
            t = RangeBitwiseAnd(12, 12);
            Assert(t, 12);
            t = RangeBitwiseAnd(2147483646, 2147483647);
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            int len = 0;
            while (m < n)
            {
                m >>= 1;
                n >>= 1;
                len += 1;
            }
            return m << len;
        }
    }
}
