using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _632 : BaseClass
    {
        public override void Run()
        {
            int[] ans;
            ans = SmallestRange(new int[][]
            {
                new int[]{0, 4, 10, 15, 24, 26},
                new int[]{0, 9, 12, 20},
                new int[]{5, 18, 22, 30}
            });
            Assert(ans, new int[] { 20, 24 });

            var pars = new int[3500][];
            for (int i = 0; i < pars.Length; i++)
                pars[i] = Enumerable.Range(0, 100).ToArray();
            ans = SmallestRange(pars);
            Assert(ans, new int[] { 0, 0 });
        }

        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var len = nums.Sum(o => o.Count);
            var arr = new Tuple<int, int>[len];
            var arri = 0;
            for (int i = 0; i < nums.Count; i++)
                for (int j = 0; j < nums[i].Count; j++)
                    arr[arri++] = new Tuple<int, int>(nums[i][j], i);
            arr = arr.OrderBy(o => o.Item1).ToArray();

            int li = 0, ri = 0;
            var kns = new int[nums.Count];
            int cnt = 0;
            int min = int.MaxValue;
            var ans = new int[2];

            while (ri < len)
            {
                while (cnt < nums.Count && ri < len)
                {
                    var idx = arr[ri++].Item2;
                    if (kns[idx] == 0)
                        cnt += 1;
                    kns[idx] += 1;
                }
                if (cnt != nums.Count)
                    break;
                while (li < ri)
                {
                    var idx = arr[li].Item2;
                    kns[idx] -= 1;
                    if (kns[idx] == 0)
                    {
                        if (min > arr[ri - 1].Item1 - arr[li].Item1)
                        {
                            min = arr[ri - 1].Item1 - arr[li].Item1;
                            ans[0] = arr[li].Item1;
                            ans[1] = arr[ri - 1].Item1;
                        }
                        cnt -= 1;
                        li += 1;
                        break;
                    }
                    li += 1;
                }
            }
            return ans;
        }
    }
}
