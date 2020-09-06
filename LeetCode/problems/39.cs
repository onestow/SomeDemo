using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _39 : BaseClass
    {
        public override void Run()
        {
            var t = CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        List<IList<int>> ans;
        int[] oneAns;
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            ans = new List<IList<int>>();
            candidates = candidates.OrderByDescending(k => k).ToArray();
            oneAns = new int[target];
            dfs(candidates, 0, 0, target);
            return ans;
        }

        private void dfs(int[] arr, int si, int ai, int t)
        {
            if (t <= 0)
            {
                if (t == 0)
                    ans.Add(oneAns.Take(ai).ToArray());
                return;
            }
            for (int i = si; i < arr.Length; i++)
            {
                oneAns[ai] = arr[i];
                dfs(arr, i, ai + 1, t - arr[i]);
            }
        }
    }
}
