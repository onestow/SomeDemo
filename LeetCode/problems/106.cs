using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _106 : BaseClass
    {
        public override void Run()
        {
            var root = BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
            root = BuildTree(new int[] { 2,1}, new int[] { 2,1});
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        TreeNode BuildTree(int[] inorder, int lin, int rin, int[] postorder, int lp, int rp)
        {
            if (lin == rin)
                return new TreeNode(inorder[lin]);
            if (lin > rin)
                return null;

            var val = postorder[rp];

            int idxin = lin;
            while (idxin <= rin && inorder[idxin] != val)
                idxin += 1;

            var mp = idxin - lin + lp;
            return new TreeNode(val,
                BuildTree(inorder, lin, idxin - 1, postorder, lp, mp-1),
                BuildTree(inorder, idxin + 1, rin, postorder, mp, rp - 1)
                );
        }
    }
}
