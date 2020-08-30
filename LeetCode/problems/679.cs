using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCode.problems
{
    public class _679 : BaseClass
    {
        public override void Run()
        {
            bool f;
            f = JudgePoint24(new int[] { 8, 4, 5, 5 });
            Assert(f, true);
            f = JudgePoint24(new int[] { 1, 9, 1, 2 });
            Assert(f, true);
            f = JudgePoint24(new int[] { 1, 5, 9, 1 });
            Assert(f, false);
            f = JudgePoint24(new int[] { 1, 3, 4, 6 });
            Assert(f, true);
            f = JudgePoint24(new int[] { 4, 1, 8, 7 });
            Assert(f, true);
            f = JudgePoint24(new int[] { 1, 2, 1, 2 });
            Assert(f, false);
        }

        HashSet<Arrs> visited;
        Func<decimal, decimal, decimal>[] funcs = new Func<decimal, decimal, decimal>[]
        {
            (a, b) => a+b,
            (a, b) => a-b,
            (a, b) => a*b,
            (a, b) => b-a,
            (a, b) => {if(b==0) return decimal.MaxValue; return a/b; },
            (a, b) => {if(a==0) return decimal.MaxValue; return b/a; },
        };
        public bool JudgePoint24(int[] nums)
        {
            visited = new HashSet<Arrs>();
            return dfs(new List<decimal>(nums.Select(item => (decimal)item)));
        }

        private bool dfs(List<decimal> arr)
        {
            if (arr.Count == 1)
                return Math.Abs(arr[0] - 24) < 0.000001m;

            if (visited.Contains(new Arrs(arr)))
                return false;

            for (int i = 1; i < arr.Count; i++)
                for (int j = 0; j < i; j++)
                {
                    var newArr = new List<decimal>(arr);
                    newArr.RemoveAt(i);
                    newArr.RemoveAt(j);
                    newArr.Add(0);

                    int lastIdx = newArr.Count - 1;
                    foreach(var func in funcs)
                    {
                        newArr[lastIdx] = func(arr[i], arr[j]);
                        if (newArr[lastIdx] == decimal.MaxValue)
                            continue;
                        if (dfs(newArr))
                            return true;
                        else
                            visited.Add(new Arrs(arr));
                    }
                }
            return false;
        }

        class Arrs
        {
            public List<decimal> vals;
            public Arrs(List<decimal> ld)
            {
                vals = new List<decimal>(ld);
            }
            public override int GetHashCode()
            {
                int len = vals.Count;
                int hash = 0x7a + len * 100011000 * (int)vals.Max();
                foreach (var item in vals)
                    hash += 117 * (int)(item * 100);
                return hash;
            }

            public override bool Equals(object obj)
            {
                if (obj is Arrs oth)
                {
                    if (oth.vals.Count != vals.Count)
                        return false;
                    for (int i = 0; i < vals.Count; i++)
                        if (vals[i] != oth.vals[i])
                            return false;
                    return true;
                }
                return false;
            }
        }
    }
}
