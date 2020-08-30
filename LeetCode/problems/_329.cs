using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _329 : BaseClass
    {
        public override void Run()
        {
            var t = LongestIncreasingPath(new int[][]
            {
                new int[]{9,9,4},
                new int[]{6,6,8},
                new int[]{2,1,1},
            });
            Assert(t, 4);

            t = LongestIncreasingPath(new int[][]
            {
                new int[]{3,4,5},
                new int[]{3,2,6},
                new int[]{2,2,1}
            });
            Assert(t, 4);
        }

        int[,] visited;
        int r, c;
        public int LongestIncreasingPath(int[][] matrix)
        {
            r = matrix.Length;
            if (r == 0)
                return 0;
            c = matrix[0].Length;
            visited = new int[r, c];

            int max = int.MinValue;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    max = Math.Max(dfs(i, j, matrix), max);
            return max;
        }

        int dfs(int x, int y, int[][] mat)
        {
            if (visited[x, y] != 0)
                return visited[x, y];
            int max = 1;
            if (x > 0 && mat[x][y] < mat[x - 1][y])
                max = Math.Max(dfs(x - 1, y, mat) + 1, max);
            if (x < r - 1 && mat[x][y] < mat[x + 1][y])
                max = Math.Max(dfs(x + 1, y, mat) + 1, max);
            if (y > 0 && mat[x][y] < mat[x][y - 1])
                max = Math.Max(dfs(x, y - 1, mat) + 1, max);
            if (y < c - 1 && mat[x][y] < mat[x][y + 1])
                max = Math.Max(dfs(x, y + 1, mat) + 1, max);
            visited[x, y] = max;
            return max;
        }
    }
}
