using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _235 : BaseClass
    {
        public override void Run()
        {
            LowestCommonAncestor(
                TreeNode.BuildTree(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 }),
                new TreeNode(2),
                new TreeNode(4)
                );
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var sv = p.val > q.val ? q.val : p.val;
            var bv = p.val < q.val ? q.val : p.val;
            var node = root;
            while(true)
            {
                if (node.val == sv || node.val == bv)
                    break;
                if (node.val < bv && node.val > sv)
                    break;
                if (node.val > bv)
                    node = node.left;
                else
                    node = node.right;
            }
            return node;
        }
    }
}
