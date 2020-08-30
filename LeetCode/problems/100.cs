using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _100 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p?.val != q?.val)
                return false;
            if (p == null || q == null)
                return p == q;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
