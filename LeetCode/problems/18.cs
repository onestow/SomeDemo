using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _18 : BaseClass
    {
        public override void Run()
        {
            var t = FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);

            t = FourSum(new int[] { -3, -2, -1, 0, 0, 1, 2, 3 }, 0);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var ansList = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    int l = j + 1, r = nums.Length - 1;
                    var lev = target - nums[i] - nums[j];
                    while (l < r)
                    {
                        var sum = nums[l] + nums[r];
                        if (sum > lev)
                            r -= 1;
                        else if (sum < lev)
                            l += 1;
                        else
                        {
                            if (l == j + 1 || nums[l] != nums[l - 1])
                                ansList.Add(new int[] { nums[i], nums[j], nums[l], nums[r] });
                            r -= 1;
                            l += 1;
                        }
                    }
                }
            }
            return ansList;
        }
    }
}
