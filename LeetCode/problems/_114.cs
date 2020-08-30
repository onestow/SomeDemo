using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _114 : BaseClass
    {
        public override void Run()
        {
            var ts = new TreeNode[7];
            for (int i = 1; i < 7; i++)
                ts[i] = new TreeNode(i);
            ts[1].left = ts[2];
            ts[1].right = ts[5];
            ts[2].left = ts[3];
            ts[2].right = ts[4];
            ts[5].right = ts[6];
            var root = ts[1];
            Flatten(root);
        }

        public void Flatten(TreeNode root)
        {
            var temp = new TreeNode();
            dfs(root, ref temp);
        }

        private TreeNode dfs(TreeNode currNode, ref TreeNode last)
        {
            if (currNode == null)
                return null;
            last = currNode;
            var l = dfs(currNode.left, ref last);
            var leftLast = last;
            var r = dfs(currNode.right, ref last);
            if (l == null)
                currNode.right = r;
            else
            {
                currNode.right = l;
                leftLast.right = r;
            }
            currNode.left = null;
            return currNode;
        }
    }
}
