using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    /// <summary>
    /// 判断二分图
    /// </summary>
    public class _785 : BaseClass
    {
        public override void Run()
        {
            var t = IsBipartite(new int[][]
            {
                new int[]{ 1, 3 },
                new int[]{ 0, 2 },
                new int[]{ 1, 3 },
                new int[]{ 0, 2 },
            });
            Assert(t, true);
            t = IsBipartite(new int[][]
            {
                new int[]{ 1, 2, 3 },
                new int[]{ 0, 2 },
                new int[]{ 0, 1, 3 },
                new int[]{ 0, 2 },
            });
            Assert(t, false);
        }

        public bool IsBipartite(int[][] graph)
        {
            var visited = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
                if (visited[i] == 0 && dfs(i, graph, visited, 1) == false)
                    return false;
            return true;
        }

        private bool dfs(int currNode, int[][] graph, int[] visited, int direct)
        {
            if (visited[currNode] != 0)
                return visited[currNode] == direct;
            visited[currNode] = direct;

            var nextDirect = direct == 1 ? -1 : 1;
            for (int i = 0; i < graph[currNode].Length; i++)
                if (!dfs(graph[currNode][i], graph, visited, nextDirect))
                    return false;
            return true;
        }
    }
}
