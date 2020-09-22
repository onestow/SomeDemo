using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _40 : BaseClass
    {
        public override void Run()
        {
            var t = CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            ans = new List<IList<int>>();
            oneAns = new int[target];
            Array.Sort(candidates);
            dfs(candidates, 0, 0, target);
            return ans;
        }


        List<IList<int>> ans;
        int[] oneAns;
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
                if (i > si && arr[i] == arr[i - 1])
                    continue;
                oneAns[ai] = arr[i];
                dfs(arr, i + 1, ai + 1, t - arr[i]);
            }
        }
    }
}
