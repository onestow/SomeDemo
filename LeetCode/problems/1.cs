using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _1 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; ++i)
            {
                if (dict.TryGetValue(target - nums[i], out int idx))
                    return new int[] { i, idx };
                dict[nums[i]] = i;
            }
            return new int[0];
        }
    }
}
