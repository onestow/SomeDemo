using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _416 : BaseClass
    {
        public override void Run()
        {
            var t = CanPartition(new int[] { 1, 5, 11, 5 });
            Assert(t, true);
            t = CanPartition(new int[] { 1, 2, 3, 8 });
            Assert(t, false);
        }

        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 == 1)
                return false;
            int target = sum >> 1;
            var dp = new int[target + 1];
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = target; j >= nums[i]; --j)
                    dp[j] = Math.Max(dp[j - nums[i]] + nums[i], dp[j]);
                if (dp[target] == target)
                    return true;
            }
            return false;
        }
    }
}
