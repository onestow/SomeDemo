/*
 * @lc app=leetcode.cn id=257 lang=csharp
 *
 * [257] 二叉树的所有路径
 */

// @lc code=start

using System.Collections.Generic;
using System.Text;
/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/
public class Solution257 {
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    StringBuilder sb;
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        sb = new StringBuilder();
        List<string> ans = new List<string>();
        dfs(root, ans);
        return ans;
    }

    private void dfs(TreeNode node, List<string> ans)
    {
        if (node == null) return;
        if (node.left == null && node.right == null)
            ans.Add(sb.ToString() + node.val);
        else
        {
            var str = node.val + "->";
            sb.Append(str);
            dfs(node.left, ans);
            dfs(node.right, ans);
            sb.Remove(sb.Length - str.Length, str.Length);
        }
    }
}
// @lc code=end

