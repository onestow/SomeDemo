using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems.problems
{
    public class _104 : BaseClass
    {
        public override void Run()
        {
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
