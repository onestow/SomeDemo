using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _2 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var root = new ListNode();
            var cur = root;
            int jw = 0;
            while (l1 != null || l2 != null || jw > 0)
            {
                var v = (l1?.val ?? 0) + (l2?.val ?? 0) + jw;
                cur.next = new ListNode(v % 10);
                jw = v / 10;
                cur = cur.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            return root.next;
        }
    }
}
