using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    /// <summary>
    /// 不同的二叉搜索树
    /// </summary>
    public class _96 : BaseClass
    {
        public override void Run()
        {
            var t = NumTrees2(3);
            Assert(t, 5);
            t = NumTrees2(2);
            Assert(t, 2);
            t = NumTrees2(1);
            Assert(t, 1);
        }

        public int NumTrees(int n)
        {
            if (n == 0 || n == 1) return 1;
            return Enumerable.Range(0, n).Sum(i => NumTrees(i) * NumTrees(n - i - 1));
        }

        public int NumTrees2(int n)
        {
            if (n == 0)
                return 0;
            var arr = new int[n + 1];
            arr[0] = arr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                var lim = i >> 1;
                for (int j = 0; j < lim; j++)
                    arr[i] += arr[j] * arr[i - j - 1] * 2;
                if ((i & 1) == 1)
                    arr[i] += arr[lim] * arr[lim];
            }
            return arr[n];
        }
    }
}
