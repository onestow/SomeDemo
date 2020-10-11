using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _142 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode lp = head, fp = head;
            while (fp != null)
            {
                lp = lp.next;
                fp = fp.next?.next;
                if (lp == fp)
                    break;
            }
            if (fp == null)
                return null;
            var n3 = head;
            while (n3 != lp)
            {
                n3 = n3.next;
                lp = lp.next;
            }
            return lp;
        }
    }
}
