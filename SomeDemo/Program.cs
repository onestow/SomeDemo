using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SomeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //new LinqDemo.LinqDemo2().Run();
                var res = new Solution().NumDistinct("bag", "g");
                Assert(res, 1);
                res = new Solution().NumDistinct("rabbbit", "rabbit");
                Assert(res, 3);
                res = new Solution().NumDistinct("babgbag", "bag");
                Assert(res, 5);
                var head = new ListNode(new int[] { 1, 2, 3, 4, 5, 6 });
                var newHead = new Solution().ReverseKGroup(head, 0);
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

    public class Solution
    {
        public int NumDistinct(string s, string t)
        {
            var map = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++)
                map[i, t.Length] = 1;

            for(int i = s.Length - 1;i>=0;i--)
                for(int j = t.Length-1;j>=0;j--)
                {
                    if (s[i] != t[j])
                        map[i, j] = map[i + 1, j];
                    else
                        map[i, j] = map[i + 1, j + 1] + map[i + 1, j];
                }
            return map[0, 0];
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
