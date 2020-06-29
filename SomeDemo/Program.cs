using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SomeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var s = new Solution();
                int r;

                r = s.FindKthLargest(new int[] { 5, 3, 5, 4 }, 3);
                Assert(r, 4);
                r = s.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4);
                Assert(r, 4);
                r = s.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);
                Assert(r, 5);
                r = s.FindKthLargest(new int[] { 5, 7, 3, 1, 6, 9 }, 4);
                Assert(r, 5);
                r = s.FindKthLargest(new int[] { 7, 6, 5, 4, 3, 2, 1 }, 5);
                Assert(r, 3);

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
