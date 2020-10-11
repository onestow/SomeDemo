using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _113 : BaseClass
    {
        public override void Run()
        {
            PathSum(TreeNode.BuildTree(new int?[] { 1, 2 }), 3);
        }

        List<IList<int>> listAns;
        List<int> ans;
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            listAns = new List<IList<int>>();
            ans = new List<int>();
            dfs(root, sum);
            return listAns;
        }

        void dfs(TreeNode node, int sum)
        {
            if (node == null)
                return;
            sum -= node.val;
            ans.Add(node.val);
            if (node.left == null && node.right == null)
            {
                if (sum == 0)
                    listAns.Add(ans.ToArray());
            }
            else
            {
                dfs(node.left, sum);
                dfs(node.right, sum);
            }
            ans.RemoveAt(ans.Count - 1);
        }
    }
}
