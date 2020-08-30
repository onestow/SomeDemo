using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _337 : BaseClass
    {
        public override void Run()
        {
            var n1 = new TreeNode(3);
            var n21 = new TreeNode(2);
            var n22 = new TreeNode(3);
            var n32 = new TreeNode(3);
            var n34 = new TreeNode(1);

            n1.left = n21;
            //n1.right = n22;
            //n21.right = n32;
            //n22.right = n34;

            var t = Rob(n1);
            Assert(t, 7);
        }

        Dictionary<TreeNode, int> dict;
        public int Rob(TreeNode root)
        {
            dict = new Dictionary<TreeNode, int>();
            return dfs(root);
        }
        public int dfs(TreeNode node)
        {
            if (node == null)
                return 0;

            if (dict.TryGetValue(node, out int ans))
                return ans;

            ans = Math.Max(dfs(node.left) + dfs(node.right),
                           dfs(node.left?.left) + dfs(node.left?.right) + dfs(node.right?.left) + dfs(node.right?.right) + node.val);
            dict.Add(node, ans);
            return ans;
        }

    }
}
