using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _17 : BaseClass
    {
        public override void Run()
        {
            var aaaa = LetterCombinations("23");
        }

        List<string> ans;
        char[] chs;
        char[][] maps;
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new string[] { "" };
            ans = new List<string>();
            chs = new char[digits.Length];
            maps = new char[8][]
            {
                new char[]{'a', 'b', 'c' },
                new char[]{'d', 'e', 'f' },
                new char[]{'g', 'h', 'i' },
                new char[]{'j', 'k', 'l' },
                new char[]{'m', 'n', 'o' },
                new char[]{'p', 'q', 'r', 's' },
                new char[]{'t', 'u', 'v' },
                new char[]{'w', 'x', 'y', 'z' },
            };
            dfs(digits, 0, 0);
            return ans;
        }

        public void dfs(string digits, int di, int ci)
        {
            if (ci == chs.Length)
            {
                ans.Add(new string(chs));
                return;
            }
            var arr = maps[(digits[di] & 0x0f) - 2];
            foreach(var ch in arr)
            {
                chs[ci] = ch;
                dfs(digits, di + 1, ci + 1);
            }
        }
    }
}
