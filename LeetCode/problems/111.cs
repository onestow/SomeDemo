using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace LeetCode.problems
{
    public class _111 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        int minDepth;
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            minDepth = int.MaxValue;
            dfs(root, 1);
            return minDepth;
        }

        private void dfs(TreeNode node, int level)
        {
            if (level >= minDepth && node == null)
                return;
            if (node.left == null && node.right == null)
            {
                if (level < minDepth)
                    minDepth = level;
                return;
            }

            dfs(node.left, level + 1);
            dfs(node.right, level + 1);
        }
    }
}
