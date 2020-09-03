using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace LeetCode.problems
{
    class _22 : BaseClass
    {
        public override void Run()
        {
            var ans = GenerateParenthesis(0);
            Console.WriteLine("Pl");
        }

        List<string> ans;
        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 0)
                return new string[0];
            ans = new List<string>();
            dfs(new char[n << 1], n, n);
            return ans;
        }

        private void dfs(char[] curChs, int nl, int nr)
        {
            if (nl == 0 && nr == 0)
            {
                ans.Add(new string(curChs));
                return;
            }

            int idx = curChs.Length - nl - nr;
            if (nl > 0)
            {
                curChs[idx] = '(';
                dfs(curChs, nl - 1, nr);
            }
            if (nr > nl)
            {
                curChs[idx] = ')';
                dfs(curChs, nl, nr - 1);
            }
        }
    }
}
