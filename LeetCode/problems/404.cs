using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _404 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }
        public int SumOfLeftLeaves(TreeNode root)
        {
            return dfs(root, 0);
        }

        int dfs(TreeNode node, int isLeft)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null)
                return node.val * isLeft;
            return dfs(node.left, 1) + dfs(node.right, 0);
        }
    }
}
