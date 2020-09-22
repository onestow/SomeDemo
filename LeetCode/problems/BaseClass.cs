using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public abstract class BaseClass
    {
        public static BaseClass GetInst()
        {
            return new _968();
        }
        protected virtual void Assert<T>(T o1, T o2)
        {
            if (o1 is IList list1)
            {
                var list2 = o2 as IList;
                if (list1.Count == list2.Count)
                {
                    for (int i = 0; i < list1.Count; i++)
                        if (!list1[i].Equals(list2[i]))
                            throw new Exception(i + ": " + list1[i] + " " + list2[i]);
                }
            }
            else
            {
                if (o1.Equals(o2))
                    return;
                throw new Exception(o1 + " " + o2);
            }

        }

        public abstract void Run();
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public override string ToString()
        {
            return Dfs(this);
        }

        private string Dfs(TreeNode node)
        {
            if (node == null)
                return "_";
            //var str = string.Join(" ", new string[] { Dfs(node.left), node.val.ToString(), Dfs(node.right) });
            var str = string.Join(" ", new string[] { node.val.ToString(), Dfs(node.left), Dfs(node.right) });
            return str;
        }

        public static TreeNode BuildTree(IList<int?> vals)
        {
            if (vals == null || vals.Count == 0)
                return null;

            var root = new TreeNode(vals[0].Value);
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            for (int i = 1; i < vals.Count && q.Count > 0; i += 2)
            {
                var node = q.Dequeue();
                if (vals[i] != null)
                {
                    node.left = new TreeNode(vals[i].Value);
                    q.Enqueue(node.left);
                }
                if (i+1<vals.Count&&vals[i+1]!=null)
                {
                    node.right = new TreeNode(vals[i + 1].Value);
                    q.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}
