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
        class A
        {
            public virtual void test()
            {
                Console.WriteLine("A");
            }
        }
        class B : A
        {
            public override void test()
            {
                Console.WriteLine("B");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                new ThreadTest().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }

        static void Assert<T>(T o1, T o2)
        {
            if (o1 is IList list1)
            {
                var list2 = o2 as IList;
                if (list1.Count == list2.Count)
                {
                    for (int i = 0; i < list1.Count; i++)
                        if (!list1[i].Equals(list2[i]))
                            throw new Exception(i + ": " + list1[i] + " " + list2[i]);
                }
            }
            else
            {
                if (o1.Equals(o2))
                    return;
                throw new Exception(o1 + " " + o2);
            }
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
}
