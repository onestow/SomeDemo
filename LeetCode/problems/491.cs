using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _491 : BaseClass
    {
        public override void Run()
        {
            var f = FindSubsequences(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            Console.WriteLine("done");

            //var line = f.Select(item => string.Join(", ", item));
            //Console.WriteLine(string.Join(Environment.NewLine, line));

            Console.ReadKey(true);
        }

        int[] cur;
        List<IList<int>> ans;
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            cur = new int[nums.Length];
            ans = new List<IList<int>>();
            dfs(nums, 0, 0);
            return ans;
        }

        private void dfs(int[] nums, int si, int ri)
        {
            if (ri > 1)
                ans.Add(cur.Take(ri).ToArray());
            var set = new HashSet<int>();
            for (int i = si; i < nums.Length; i++)
            {
                if (ri > 0 && nums[i] < cur[ri - 1])
                    continue;
                if (!set.Add(nums[i]))
                    continue;
                cur[ri] = nums[i];
                dfs(nums, i + 1, ri + 1);
            }
        }
    }
}
