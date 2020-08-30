using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _312 : BaseClass
    {
        public override void Run()
        {
            int t;
            t = MaxCoins(new int[] { 3, 1, 5, 8 });
            Assert(t, 167);
            t = MaxCoins(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });
            Assert(t, 4338);
        }

        #region dfs
        int[,] visited;
        public int MaxCoins(int[] nums)
        {
            visited = new int[nums.Length + 2, nums.Length + 2];
            return Dfs(nums, -1, nums.Length);
        }

        /// <summary>
        /// 从0开始放气球，便于使用dfs和记忆化
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Dfs(int[] nums, int left, int right)
        {
            if (visited[left + 1, right + 1] != 0)
                return visited[left + 1, right + 1];
            int max = 0;
            //开区间
            for (int i = left + 1; i < right; i++)
            {
                int t = nums[i];
                if (left >= 0) t *= nums[left];
                if (right < nums.Length) t *= nums[right];
                max = Math.Max(max, t + Dfs(nums, left, i) + Dfs(nums, i, right));
            }
            return visited[left + 1, right + 1] = max;
        }
        #endregion
    }
}
