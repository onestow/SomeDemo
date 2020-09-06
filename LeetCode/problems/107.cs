using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _107 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null)
                return new int[0][];
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var ans = new List<IList<int>>();

            while (q.Count > 0)
            {
                var cnt = q.Count;
                var oneAns = new int[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    var node = q.Dequeue();
                    oneAns[i] = node.val;
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
                ans.Add(oneAns);
            }
            ans.Reverse();
            return ans;
        }
    }
}
