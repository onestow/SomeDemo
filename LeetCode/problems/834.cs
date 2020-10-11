using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _834 : BaseClass
    {
        public override void Run()
        {
            SumOfDistancesInTree(6, new int[][]{
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{2, 3},
                new int[]{2, 4},
                new int[]{2, 5},
            });
        }

        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            var dictEdge = edges.GroupBy(edge => edge[0]).ToDictionary(g => g.Key, g => g.Select(item => item[1]).ToArray());
            return null;
        }

        void dfs(TeNode node)
        {
        }

        class TeNode
        {
            public int val;
            public List<TeNode> childs;
            public int leftDis;
            public int rightDis;
            public TeNode(int val)
            {
                childs = new List<TeNode>();
                this.val = val;
                leftDis = rightDis = -1;
            }
            public static TeNode BuildTree(int[][] edges, int n)
            {
                var nodes = Enumerable.Range(0, n).Select(idx=>new TeNode(idx)).ToArray();
                var ingree = new int[n];
                foreach (var edge in edges.Distinct())
                {
                    nodes[edge[0]].childs.Add(nodes[edge[1]]);
                    ingree[edge[1]] += 1;
                }
                for (int i = 0; i < n; i++)
                    if (ingree[i] == 0)
                        return nodes[ingree[i]];
                throw new Exception("我太难了");
            }
        }
    }
}
