using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _49 : BaseClass
    {
        public override void Run()
        {
            var t = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>(new Comparer());
            foreach(var str in strs)
            {
                if (dict.TryGetValue(str, out List<string> list))
                    list.Add(str);
                else
                    dict.Add(str, new List<string> { str });
            }
            return dict.Values.ToArray();
        }

        public class Comparer : IEqualityComparer<string>
        {
            private int[] rs;
            private Dictionary<string, string> sorted;
            public Comparer()
            {
                Random r = new Random();
                sorted = new Dictionary<string, string>();
                rs = new int[26];
                for (int i = 0; i < 26; i++)
                    rs[i] = r.Next(3, 20);
            }
            public bool Equals([AllowNull] string x, [AllowNull] string y)
            {
                return GetSortedString(x) == GetSortedString(y);
            }

            private string GetSortedString(string s)
            {
                if (!sorted.TryGetValue(s, out string sortedStr))
                {
                    var chs = s.ToArray();
                    Array.Sort(chs);
                    sortedStr = new string(chs);
                    sorted.Add(s, sortedStr);
                }
                return sortedStr;
            }

            public int GetHashCode([DisallowNull] string obj)
            {
                return obj.Sum(ch => (ch - 'a' + 1) << rs[ch - 'a']);
            }
        }
    }
}
