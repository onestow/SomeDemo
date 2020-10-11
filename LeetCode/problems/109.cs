using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _109 : BaseClass
    {
        public override void Run()
        {
            var node = SortedListToBST(ListNode.BuildList(new int[] { -10, -3, 0, 5, 9 }));
        }

        List<int> list;
        public TreeNode SortedListToBST(ListNode head)
        {
            list = new List<int>();
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            return BuildTree(0, list.Count - 1);
        }

        private TreeNode BuildTree(int left, int right)
        {
            if (left > right)
                return null;

            var idx = (left + right) >> 1;
            var node = new TreeNode(list[idx]);

            node.left = BuildTree(left, idx - 1);
            node.right = BuildTree(idx + 1, right);

            return node;
        }
    }
}
