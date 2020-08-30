using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    //https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
    public class _350 : BaseClass
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();
            foreach(var n in nums1)
            {
                if (dict.TryGetValue(n, out int val))
                    dict[n] = val + 1;
                else
                    dict[n] = 1;
            }

            var ans = new List<int>();
            foreach(var n in nums2)
            {
                if (dict.TryGetValue(n, out int val))
                {
                    ans.Add(n);
                    if (val == 1)
                        dict.Remove(n);
                    else
                        dict[n] = val - 1;
                }
            }
            return ans.ToArray();
        }

        public override void Run()
        {
            var t = Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            Assert(t, new int[] { 2, 2 });

            t = Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            Assert(t, new int[] { 4, 9 });
        }
    }
}
