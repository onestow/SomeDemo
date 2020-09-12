using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _637 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null)
                return new double[0];

            var listAns = new List<double>();
            var list = new List<TreeNode>() { root };
            while (list.Count > 0)
            {
                long sum = 0;
                var tmp = new List<TreeNode>(list.Capacity);
                foreach (var node in list)
                {
                    sum += node.val;
                    if (node.left != null)
                        tmp.Add(node.left);
                    if (node.right != null)
                        tmp.Add(node.right);
                }
                listAns.Add(sum * 1.0 / list.Count);
                list = tmp;
            }
            return listAns;
        }
    }
}
