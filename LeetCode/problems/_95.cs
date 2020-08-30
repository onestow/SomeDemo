using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _95 : BaseClass
    {
        public override void Run()
        {
            var t = GenerateTrees(3);
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new TreeNode[0];
            return Dfs(1, n);
        }

        private List<TreeNode> Dfs(int l, int r)
        {
            if (l > r)
                return new List<TreeNode> { null };

            var trees = new List<TreeNode>();
            for (int i = l; i <= r; i++)
            {
                var lts = Dfs(l, i - 1);
                var rts = Dfs(i + 1, r);
                foreach (var lt in lts)
                    foreach (var rt in rts)
                    {
                        var currTree = new TreeNode(i);
                        currTree.left = lt;
                        currTree.right = rt;
                        trees.Add(currTree);
                    }
            }
            return trees;
        }

        private TreeNode Copy(TreeNode node)
        {
            if (node == null)
                return null;
            return new TreeNode(node.val, Copy(node.left), Copy(node.right));
        }
    }
}
