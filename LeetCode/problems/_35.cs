using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _35 : BaseClass
    {
        public override void Run()
        {
            var t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 1);
            Assert(t, 0);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 2);
            Assert(t, 0);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 3);
            Assert(t, 1);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 4);
            Assert(t, 1);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 9);
            Assert(t, 4);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 10);
            Assert(t, 4);
            t = SearchInsert(new int[] { 2, 4, 6, 8, 10 }, 11);
            Assert(t, 5);
        }

        public int SearchInsert(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            int ans = 0;

            while(l <= r)
            {
                var m = (l + r) >> 1;
                if (nums[m] >= target)
                {
                    r = m - 1;
                    ans = m;
                }
                else
                {
                    l = m + 1;
                    ans = l;
                }
            }
            return ans;
        }
    }
}
