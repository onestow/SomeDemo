using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _733 : BaseClass
    {
        public override void Run()
        {
            var iame= FloodFill(new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } }, 1, 1, 2);
        }

        int rn, cn;
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var oldColor = image[sr][sc];
            if (oldColor == newColor)
                return image;

            rn = image.Length;
            cn = image[0].Length;

            return image;
        }

        private void dfs(int[][] image, int r, int c, int oldColor, int newColor)
        {
            if (image[r][c] != oldColor)
                return;

            image[r][c] = newColor;
            if (r != rn)
                dfs(image, r + 1, c, oldColor, newColor);
            if (r != 0)
                dfs(image, r - 1, c, oldColor, newColor);
            if (c != cn)
                dfs(image, r, c + 1, oldColor, newColor);
            if (c != 0)
                dfs(image, r, c - 1, oldColor, newColor);
        }
    }
}
