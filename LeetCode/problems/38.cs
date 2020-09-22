using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _38 : BaseClass
    {
        public override void Run()
        {
            for (int i = 1; i <= 5; i++)
                Console.WriteLine(CountAndSay(i));
            Console.ReadKey();
        }

        public string CountAndSay(int n)
        {
            string ans = "1";
            for (int ni = 1; ni < n; ni++)
            {
                var sb = new StringBuilder();
                int si = 0, i = 1;
                while (si < ans.Length)
                {
                    while (i < ans.Length && ans[si] == ans[i])
                        i++;
                    sb.Append((i - si).ToString() + ans[si]);
                    si = i;
                    i += 1;
                }
                ans = sb.ToString();
            }
            return ans;
        }
    }
}
