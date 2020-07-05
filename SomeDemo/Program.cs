using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SomeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var c = "".FirstOrDefault();
                var s = new Solution();
                bool t;
                t = s.IsMatch("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb",
"**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb");
                Assert(t, true);
                t = s.IsMatch("b",
                              "?*?");
                Assert(t, false);
                t = s.IsMatch("leetcode",
                              "*e*t?d*");
                Assert(t, false);
                t = s.IsMatch("aab", "*a*?a*");
                Assert(t, false);
                t = s.IsMatch("sissip",
                              "*ss*?i*");
                Assert(t, false);
                t = s.IsMatch("abab", "abab");
                Assert(t, true);
                t = s.IsMatch("abab", "abab*");
                Assert(t, true);
                t = s.IsMatch("abab", "*abab");
                Assert(t, true);
                t = s.IsMatch("abab", "a*b*b");
                Assert(t, true);
                t = s.IsMatch("abab", "a*b");
                Assert(t, true);
                t = s.IsMatch("abab", "a*");
                Assert(t, true);
                t = s.IsMatch("abab", "*b");
                Assert(t, true);
                t = s.IsMatch("abab", "a");
                Assert(t, false);
                t = s.IsMatch("abab", "ab");
                Assert(t, false);
                t = s.IsMatch("aabab", "**b**b**");
                Assert(t, true);
                t = s.IsMatch("aabab", "?ab*b*");
                Assert(t, true);
                t = s.IsMatch("aabab", "*b*b*");
                Assert(t, true);
                t = s.IsMatch("aaaabaaaabbbbaabbbaabbaababbabbaaaababaaabbbbbbaabbbabababbaaabaabaaaaaabbaabbbbaababbababaabbbaababbbba", "*****b*aba***babaa*bbaba***a*aaba*b*aa**a*b**ba***a*a*");
                Assert(t, true);
                t = s.IsMatch("babbbbaabababaabbababaababaabbaabababbaaababbababaaaaaabbabaaaabababbabbababbbaaaababbbabbbbbbbbbbaabbb", "b**bb**a**bba*b**a*bbb**aba***babbb*aa****aabb*bbb***a");
                Assert(t, false);
                var head = new ListNode(new int[] { 1, 2, 3, 4, 5 });
                var newHead = s.ReverseKGroup(head, 0);
                Console.WriteLine(newHead.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }

        static void Assert<T>(T o1, T o2)
        {
            if (o1.Equals(o2))
                return;
            throw new Exception(o1 + " " + o2);
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class Solution
    {
        public bool IsMatchByRegex(string s, string p)
        {
            p = "^" + p.Replace("**", "*").Replace("**", "*").Replace("*", "[a-z]*").Replace("?", "[a-z]") + "$";
            return Regex.IsMatch(s, p, RegexOptions.None);
        }

        public bool IsMatch(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0)
                return true;
            if (p.Length == 0)
                return false;
            var ps = p.Split('*');

            if (p[0] != '*')//去头
            {
                if (!StartWith(s, 0, ps[0]))
                    return false;
                s = s.Substring(ps[0].Length);
                ps = ps.Skip(1).ToArray();
                if (ps.Length == 0 && s.Length > 0)
                    return false;
            }
            if (p.Last() != '*' && ps.Length > 0)//去尾
            {
                var lastP = ps.Last();
                if (!StartWith(s, s.Length - lastP.Length, lastP))
                    return false;
                s = s.Substring(0, s.Length - lastP.Length);
                ps = ps.Take(ps.Length - 1).ToArray();
            }
            ps = ps.Where(item => item != "").ToArray();
            Map = new int[s.Length, ps.Length];
            return DFS(s, 0, ps, 0);
        }

        int[,] Map;

        private bool DFS(string s, int si, string[] ps, int psi)
        {
            if (ps.Length == psi)
                return true;
            if (s.Length == si)
                return false;
            if (Map[si, psi] != 0)
                return Map[si, psi] > 0;
            var listSi = FindIndexes(s, si, ps[psi]);
            for (int i = 0; i < listSi.Count; i++)
            {
                if (DFS(s, listSi[i] + ps[psi].Length, ps, psi + 1))
                {
                    Map[si, psi] = 1;
                    return true;
                }
            }
            Map[si, psi] = -1;
            return false;
        }

        private List<int> FindIndexes(string s, int si, string p)
        {
            var indexes = new List<int>();
            for (int i = si; i <= s.Length - p.Length; i++)
                if (StartWith(s, i, p))
                    indexes.Add(i);
            return indexes;
        }

        private bool StartWith(string s, int si, string p)
        {
            if (p.Length > s.Length - si || si < 0 || si >= s.Length)
                return false;
            for (int pi = 0; pi < p.Length; pi++)
            {
                if (p[pi] == '?' || s[si] == p[pi])
                    si += 1;
                else
                    return false;
            }
            return true;
        }

        public int KthSmallest(int[][] matrix, int k)
        {
            var arr = new int[matrix.Length * matrix[0].Length];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                    arr[index++] = matrix[i][j];
            Array.Sort(arr);
            return arr[k - 1];
        }
        public int FindLength(int[] A, int[] B)
        {
            int max = 0;
            var map = new int[B.Length + 1];
            for (int i = A.Length - 1; i >= 0; i--)
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                    {
                        map[j] = 1 + map[j + 1];
                        if (max < map[j])
                            max = map[j];
                    }
                    else
                        map[j] = 0;
                }
            return max;
        }

        Random random = new Random((int)DateTime.Now.Ticks);
        public int FindKthLargest(int[] nums, int k)
        {
            return PartQuickSort(nums, 0, nums.Length, k - 1);
        }

        private int PartQuickSort(int[] nums, int si, int len, int k)
        {
            if (si == k && len == 1)
                return nums[si];
            var bi = random.Next(si, si + len);
            var bv = nums[bi];
            int i = si, j = si + len - 1;
            while (i <= j)
            {
                while (bi <= j && nums[j] <= bv) j--;
                if (bi <= j)
                {
                    nums[bi] = nums[j];
                    bi = j;
                }
                while (i <= bi && nums[i] >= bv) i++;
                if (i <= bi)
                {
                    nums[bi] = nums[i];
                    bi = i;
                }
            }
            if (bi == k)
                return bv;
            nums[bi] = bv;

            if (bi > k)
                return PartQuickSort(nums, si, bi - si, k);
            else
                return PartQuickSort(nums, bi + 1, len - bi + si - 1, k);
        }

        private void QuickSort(int[] nums, int si, int len)
        {
            if (len < 2)
                return;
            var bi = random.Next(si, si + len);
            var bv = nums[bi];
            int i = si, j = si + len - 1;
            while (i <= j)
            {
                while (bi <= j && nums[j] <= bv) j--;
                if (bi <= j)
                {
                    nums[bi] = nums[j];
                    bi = j;
                }
                while (i <= bi && nums[i] >= bv) i++;
                if (i <= bi)
                {
                    nums[bi] = nums[i];
                    bi = i;
                }
            }
            nums[bi] = bv;

            QuickSort(nums, si, bi - si);
            QuickSort(nums, bi + 1, len - bi + si - 1);
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var kStart = head;
            var prev = head;
            var curr = head.next;
            var next = curr?.next;

            int cnt = 2;
            while (curr != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                next = next?.next;
                if (cnt%k==0)
                {
                    kStart.next = null;
                }
            }
            return prev;
        }

        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            var kStart = head;
            var prev = head;
            var curr = head.next;
            var next = curr?.next;

            head.next = null;
            while (curr != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                next = next?.next;
            }
            return prev;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            var vals = new List<int>() { val };
            var curr = next;
            while (curr != null)
            {
                vals.Add(curr.val);
                curr = curr.next;
            }

            return string.Join(", ", vals);
        }

        public ListNode(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                throw new ArgumentException(nameof(arr));

            val = arr[0];
            if (arr.Length > 1)
                next = new ListNode(arr.Skip(1).ToArray());
        }
    }


    class A
    {
        public void test(int i)
        {
            Console.WriteLine(i);
            lock (this)
            {
                if (i > 10)
                {
                    i--;
                    test(i);
                }
            }
        }
        public string Val { get; set; }
        public override bool Equals(object obj)
        {
            Console.WriteLine("equ");
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            Console.WriteLine("hash");
            return base.GetHashCode();
        }
    }
}
