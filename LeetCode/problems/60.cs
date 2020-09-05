using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LeetCode.problems
{
    class _60 : BaseClass
    {
        public override void Run()
        {
            string t;
            t = GetPermutation(1, 1);
            Assert(t, "1");
            t = GetPermutation(3, 3);
            Assert(t, "213");
            t = GetPermutation(3, 2);
            Assert(t, "132");
            t = GetPermutation(4, 9);
            Assert(t, "2314");
            t = GetPermutation(4, 1);
            Assert(t, "1234");
        }

        public string GetPermutation(int n, int k)
        {
            var vs = new int[n + 1];
            vs[0] = 1;
            for (int i = 1; i <= n; i++)
                vs[i] = vs[i - 1] * i;

            k -= 1;
            var chs = new char[n];
            var nums = Enumerable.Range(1, n).ToList();
            for (int i = 0; i < n; i++)
            {
                var v = k / vs[n - i - 1];
                k %= vs[n - i - 1];
                chs[i] = (char)(nums[v] | 0x30);
                nums.RemoveAt(v);
            }
            return new string(chs);
        }
    }
}
