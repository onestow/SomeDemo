using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _75 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public void SortColors(int[] nums)
        {
            var cnts = new int[3];
            foreach (var n in nums)
                cnts[n] += 1;
            int si = 0;
            for (int ci = 0; ci < 3; ++ci)
            {
                int cnt = cnts[ci];
                for (int i = 0; i < cnt; i++)
                    nums[i + si] = ci;
                si += cnt;
            }
        }
    }
}
