using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _99 : BaseClass
    {
        public override void Run()
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            //n3.left = n1;
            //n3.right = n4;
            //n4.left = n2;
            n1.left = n3;
            n3.right = n2;
            RecoverTree(n1);
        }

        List<TreeNode> nodes;
        TreeNode prevNode;
        public void RecoverTree(TreeNode root)
        {
            nodes = new List<TreeNode>();
            prevNode = null;
            Ldr(root);

            var t = nodes[0].val;
            nodes[0].val = nodes[1].val;
            nodes[1].val = t;
        }

        private void Ldr(TreeNode node)
        {
            if (node == null)
                return;
            Ldr(node.left);
            if (prevNode != null && node.val < prevNode.val)
            {
                if (nodes.Count == 0)
                {
                    nodes.Add(prevNode);
                    nodes.Add(node);
                }
                else
                    nodes[1] = node;
            }
            prevNode = node;
            Ldr(node.right);
        }
    }
}
