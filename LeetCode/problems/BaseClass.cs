using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public abstract class BaseClass
    {
        public static BaseClass GetInst()
        {
            return new _60();
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
    }
}
