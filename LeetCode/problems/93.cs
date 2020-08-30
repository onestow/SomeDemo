using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _93 : BaseClass
    {
        public override void Run()
        {
            var t = RestoreIpAddresses("1111");
            Assert(t, new string[] { "1.1.1.1" });
            t = RestoreIpAddresses("010010");
            Assert(t, new string[] { "0.10.0.10", "0.100.1.0" });
            t = RestoreIpAddresses("25525511135");
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            if (s.Length > 12 || s.Length < 4)
                return new string[0];
            var ansList = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (!IsLessThan256(s, 0, i))
                    break;
                for (int j = i + 1; j < s.Length && j - i < 4; j++)
                {
                    if (!IsLessThan256(s, i + 1, j))
                        break;
                    for (int k = j + 1; k < s.Length - 1 && k - j < 4; k++)
                    {
                        if (!IsLessThan256(s, j + 1, k))
                            break;
                        if (s.Length - k > 4)
                            continue;
                        if (!IsLessThan256(s, k + 1, s.Length - 1))
                            continue;
                        ansList.Add($"{s.Substring(0, i + 1)}.{s.Substring(i + 1, j - i)}.{s.Substring(j + 1, k - j)}.{s.Substring(k + 1)}");
                    }
                }
            }
            return ansList;
        }

        private bool IsLessThan256(string s, int start, int end)
        {
            if (start == end)
                return true;
            if (end - start > 2)
                return false;
            if (s[start] == '0')
                return false;
            if (end - start == 1)
                return true;
            if (s[start] > '2')
                return false;
            if (s[start] == '1')
                return true;
            if (s[start + 1] > '5')
                return false;
            if (s[start + 1] < '5')
                return true;
            return s[start + 2] < '6';
        }
    }
}
