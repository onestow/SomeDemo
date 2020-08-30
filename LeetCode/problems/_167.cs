using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _167 : BaseClass
    {
        public override void Run()
        {
            var t = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert(t, new int[] { 1, 2 });
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                var sum = numbers[left] + numbers[right];
                if (sum == target)
                    return new int[] { left + 1, right + 1 };
                if (sum > target)
                    right -= 1;
                else
                    left += 1;
            }
            return new int[0];
        }
    }
}
