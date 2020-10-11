using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;

namespace LeetCode.problems
{
    class LCP19 : BaseClass
    {
        public override void Run()
        {
            int t;
            t = MinimumOperations("yry");
            Assert(t, 3);
            t = MinimumOperations("ryrrrrryyyyyyyyyyyyyyyyyyyyryrr");
            Assert(t, 2);
            t = MinimumOperations("rrryyyrryyyrr");
            Assert(t, 2);
            t = MinimumOperations("ryr");
            Assert(t, 0);
        }

        public int MinimumOperations(string leaves)
        {
            int r = 1, ry = 1, ryr = 0xffff;
            if (leaves[0] == 'r')
                r = ry = 0;
            for (int i = 1; i < leaves.Length; i++)
            {
                if (i > 1)
                    ryr = Math.Min(ry, ryr);
                ry = Math.Min(ry, r);
                if (leaves[i] == 'r')
                    ry += 1;
                else
                {
                    r += 1;
                    ryr += 1;
                }
            }
            return ryr;
        }
    }
}
