using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _685 : BaseClass
    {
        public override void Run()
        {
            var ans = FindRedundantDirectedConnection(new int[][]
            {
                new int[]{1,2 },
                new int[]{1,3 },
                new int[]{2,3 },
            });
            Assert(ans, new int[] { 2, 3 });

            ans = FindRedundantDirectedConnection(new int[][]
            {
                new int[]{1,2 },
                new int[]{2,3 },
                new int[]{3,4 },
                new int[]{4,1 },
                new int[]{1,5 },
            });
            Assert(ans, new int[] { 4, 1 });
        }

        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            var inEdge = new int[edges.Length + 1];//记录每个点的入度
            var listLink = new List<int>[edges.Length + 1];//保存为邻接表, 方便遍历
            for (int i = edges.Length - 1; i >= 0; i--)
            {
                inEdge[edges[i][1]] += 1;
                if (listLink[edges[i][0]] == null)
                    listLink[edges[i][0]] = new List<int>();
                listLink[edges[i][0]].Add(edges[i][1]);
            }

            //找根节点, 如果找不到则证明根节点被多余的一条边占了
            int root = -1;
            for (int i = inEdge.Length - 1; i > 0; i--)
                if (inEdge[i] == 0)
                {
                    root = i;
                    break;
                }

            int curRoot;
            for (int i = edges.Length - 1; i >= 0; i--)
            {
                //获取根节点
                if (root == -1)
                {
                    if (inEdge[edges[i][1]] != 1)
                        continue;
                    curRoot = edges[i][1];
                }
                else
                {
                    if (inEdge[edges[i][1]] == 1)
                        continue;
                    curRoot = root;
                }
                //广搜判断是不是树
                if (IsTree(edges[i], listLink, curRoot))
                    return edges[i];
            }
            return null;
        }

        /// <summary>
        /// 广搜判断是不是树
        /// </summary>
        /// <param name="excludeEdge">被排除的边</param>
        /// <param name="listLink">邻接表</param>
        /// <param name="root">根节点</param>
        /// <returns></returns>
        private bool IsTree(int[] excludeEdge, List<int>[] listLink, int root)
        {
            var visited = new bool[listLink.Length - 1];
            var q = new Queue<int>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                var v = q.Dequeue();
                if (visited[v-1])
                    return false;
                visited[v-1] = true;
                if (listLink[v] == null) continue;
                foreach (var nv in listLink[v])
                    if (excludeEdge[0] != v || excludeEdge[1] != nv)
                        q.Enqueue(nv);
            }
            return visited.All(_ => _);
        }
    }
}
