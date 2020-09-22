using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace LeetCode.problems
{
    class _968 : BaseClass
    {
        public override void Run()
        {
            var r = TreeNode.BuildTree(new int?[] { 0, 0, null, 0, null, 0 });
            var f = MinCameraCover(r);
            Assert(f, 2);

            r = TreeNode.BuildTree(new int?[] { 0, 0, null, 0, 0 });
            f = MinCameraCover(r);
            Assert(f, 1);

            r = TreeNode.BuildTree(new int?[] { 0, 0, null, 0, null, 0, null, null, 0 });
            f = MinCameraCover(r);
            Assert(f, 2);

            //var r = new TreeNode(0);
            //var r1 = new TreeNode(0);
            //var r21 = new TreeNode(0);
            //var r22 = new TreeNode(0);
            //var r31 = new TreeNode();
            //var r42 = new TreeNode();
            //r.left = r1;
            //r1.left = r21;
            ////r1.right = r22;
            //r21.left = r31;
            ////r31.right = r42;
            //var f = MinCameraCover(r);
        }

        public int MinCameraCover(TreeNode root)
        {
            if (root == null)
                return 0;
            dfs(root, out int v1, out int v2, out int v3);
            return Math.Min(v2, v3);
        }

        void dfs(TreeNode node, out int notwatched, out int watcher, out int watched)
        {
            if (node == null)
            {
                notwatched = watched = 0;
                watcher = 10000;
                return;
            }

            dfs(node.left, out int lnotwatch, out int lwatcher, out int lwatched);
            dfs(node.right, out int rnotwatch, out int rwatcher, out int rwatched);
            notwatched = lwatched + rwatched;
            watcher = 1 + Min(lnotwatch, lwatcher, lwatched) + Min(rnotwatch, rwatcher, rwatched);
            watched = Min(lwatcher + rwatcher, lwatcher+ rwatched, lwatched + rwatcher);
        }

        int Min(int v1, int v2, int v3)
        {
            var t = v1 > v2 ? v2 : v1;
            return t > v3 ? v3 : t;
        }
    }
}
