using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _剑指Offer11 : BaseClass
    {
        public override void Run()
        {
            var t = MinArray(new int[] { 3, 4, 5, 1, 2 });
            Assert(t, 1);
            t = MinArray(new int[] { 2, 2, 2, 0, 1 });
            Assert(t, 0);
            t = MinArray(new int[] { 2, 2, 2 });
            Assert(t, 2);
            t = MinArray(new int[] { 1 });
            Assert(t, 1);
            t = MinArray(new int[] { 3, 1, 3 });
            Assert(t, 1);
        }

        public int MinArray(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (mid + 1 < nums.Length && nums[mid + 1] < nums[mid])
                    return nums[mid + 1];
                if (mid > 0 && nums[mid] < nums[mid - 1])
                    return nums[mid];
                if (nums[mid] == nums[r])
                    r -= 1;
                else if (nums[mid] > nums[r])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return nums[0];
        }
    }
}
