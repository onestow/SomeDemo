using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _198 : BaseClass
    {
        public override void Run()
        {
            var t = Rob(new int[] { 1, 2, 3, 1 });
            Assert(t, 4);

            t = Rob(new int[] { 2, 7, 9, 3, 1 });
            Assert(t, 12);

            t = Rob(new int[] { 10, 1, 1, 10 });
            Assert(t, 20);
        }

        public int Rob(int[] nums)
        {
            if (nums.Length < 3)
            {
                if (nums.Length == 0)
                    return 0;
                return nums.Max();
            }

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            return dp[nums.Length - 1];
        }
    }
}
