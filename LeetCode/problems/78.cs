using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _78 : BaseClass
    {
        public override void Run()
        {
            Subsets(new int[] { 1, 2, 3 });
            var listStr = listAns.Select(item => string.Join(",", item));
            Console.WriteLine(string.Join(Environment.NewLine, listStr));
            Console.ReadKey(true);
        }

        int[][] listAns;
        int[] ans;
        int idx;
        public IList<IList<int>> Subsets(int[] nums)
        {
            int ansCnt = 1, top = nums.Length, buttom = 1;
            idx = -1;
            for (int i = 1; i <= nums.Length; i++)
            {
                ansCnt += top / buttom;
                top *= nums.Length - i;
                buttom *= i + 1;
            }
            ans = new int[nums.Length];
            listAns = new int[ansCnt][];
            dfs(nums, 0, 0);
            return listAns;
        }

        void dfs(int[] nums, int si, int ai)
        {
            listAns[++idx] = ans.Take(ai).ToArray();
            for (int i = si; i < nums.Length; i++)
            {
                ans[ai] = nums[i];
                dfs(nums, i + 1, ai + 1);
            }
        }
    }
}
