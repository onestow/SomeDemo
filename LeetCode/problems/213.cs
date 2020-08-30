using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _213 : BaseClass
    {
        public override void Run()
        {
            var t = Rob(new int[] { 2, 3, 2 });
            Assert(t, 3);
            
            t = Rob(new int[] { 1, 2, 3, 1 });
            Assert(t, 4);

            t = Rob(new int[] { 2, 7, 9, 3, 1 });
            Assert(t, 11);

            t = Rob(new int[] { 10, 1, 1, 10 });
            Assert(t, 11);
        }

        public int Rob(int[] nums)
        {
            if (nums.Length < 4)
            {
                if (nums.Length == 0)
                    return 0;
                return nums.Max();
            }

            var dp = new int[nums.Length, 2];
            dp[0, 0] = nums[0];
            dp[0, 1] = nums[1];
            dp[1, 0] = Math.Max(nums[0], nums[1]);
            dp[1, 1] = Math.Max(nums[1], nums[2]);
            for (int i = 2; i < nums.Length - 1; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 2, 0] + nums[i], dp[i - 1, 0]);
                dp[i, 1] = Math.Max(dp[i - 2, 1] + nums[i + 1], dp[i - 1, 1]);
            }
            return Math.Max(dp[nums.Length - 2, 0], dp[nums.Length - 2, 1]);
        }

    }
}
