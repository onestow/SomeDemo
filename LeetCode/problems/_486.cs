using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _486 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        int[,,] visited;
        public bool PredictTheWinner(int[] nums)
        {
            visited = new int[nums.Length, nums.Length, 2];
            return dfs(nums, 0, nums.Length-1, 1) >= 0;
        }

        private int dfs(int[] nums, int l, int r, int turn)
        {
            if (visited[l, r, (turn + 1) >> 1] != 0)
                return visited[l, r, (turn + 1) >> 1];
            if (l == r)
                return nums[l] * turn;

            var takeL = nums[l] * turn + dfs(nums, l + 1, r, -turn);
            var takeR = nums[r] * turn + dfs(nums, l, r - 1, -turn);
            if (turn == 1)
                visited[l, r, 1] = Math.Max(takeL, takeR);
            else
                visited[l, r, 0] = Math.Min(takeL, takeR);
            return visited[l, r, (turn + 1) >> 1];
        }
    }
}