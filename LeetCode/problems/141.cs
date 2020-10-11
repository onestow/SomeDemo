using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _141 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }
        public bool HasCycle(ListNode head)
        {
            var fp = head?.next?.next;
            var lp = head?.next;
            while (fp != null && lp != null)
            {
                if (fp == lp)
                    return true;
                fp = fp.next?.next;
                lp = lp.next;
            }
            return false;
        }
    }
}
