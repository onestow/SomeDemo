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
                var ffff = (5 % -2);
                var s = new Solution();
                int r;

                Assert(s.CanArrange(new int[] { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 }, 5), true);
                Assert(s.CanArrange(new int[] { 1, 2, 3, 4, 5, 6 }, 7), true);
                Assert(s.CanArrange(new int[] { 1, 2, 3, 4, 5, 6 }, 10), false);
                Assert(s.CanArrange(new int[] { -10, 10 }, 2), true);
                Assert(s.CanArrange(new int[] { -1, 1, -2, 2, -3, 3, -4, 4 }, 3), true);

                var head = new ListNode(new int[] { 1, 2, 3, 4, 5, 6 });
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

    public class Solution
    {
        public bool CanArrange(int[] arr, int k)
        {
            var modCnt = new int[k];
            for (int i = 0; i < arr.Length; i++)
            {
                var mod = arr[i] % k;
                if (mod < 0)
                    mod += k;

                modCnt[mod] += 1;
            }

            if (modCnt[0] % 2 == 1) 
                return false;

            var halfLen = k / 2;
            for (int i = 1; i < halfLen; i++)
            {
                if (modCnt[i] != modCnt[k - i])
                    return false;
            }
            return true;
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
