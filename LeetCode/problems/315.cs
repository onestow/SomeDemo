using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode.problems
{
    public class _315 : BaseClass
    {
        public override void Run()
        {
            var t = CountSmaller(new int[] { 5, 2, 6, 1 });
            Assert(t, new int[] { 2, 1, 1, 0 });
            Console.WriteLine("done");
            Console.ReadKey();
        }

        public IList<int> CountSmaller(int[] nums)
        {
            var distinctNums = nums.Distinct().OrderBy(item => item).ToArray();
            var treeArr = new int[distinctNums.Length];

            var ansArr = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                var index = Find(distinctNums, nums[i]);
                Update(treeArr, index, 1);
                ansArr[i] = Sum(treeArr, index - 1);
            }
            return ansArr;
        }

        private int Find(int[] arr, int val)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (arr[m] == val)
                    return m;
                if (arr[m] > val)
                    r = m - 1;
                else
                    l = m + 1;
            }
            return -1;
        }

        private int Lowbit(int value)
        {
            return value & -value;
        }

        private void Update(int[] arr, int index, int val)
        {
            if (val == 0)
                return;
            while (index < arr.Length)
            {
                arr[index] += val;
                index += Lowbit(index + 1);
            }
        }

        private int Sum(int[] arr, int index)
        {
            int ans = 0;
            while (index >= 0)
            {
                ans += arr[index];
                index -= Lowbit(index + 1);
            }
            return ans;
        }
        #region 树状数组测试
        private void Test()
        {
            var arr = new int[] { 4, 7, 3, 8, 5, 6, 7, 0, 1, 4, 6, 7, 2, 12, 5453, 35, 12456, 63 };
            var treeArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                Update(treeArr, i, arr[i]);
            for (int i = 0; i < arr.Length; i++)
                Assert(arr.Take(i + 1).Sum(), Sum(treeArr, i));

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += i;
                Update(treeArr, i, i);
            }
            for (int i = 0; i < arr.Length; i++)
                Assert(arr.Take(i + 1).Sum(), Sum(treeArr, i));
        }

        #endregion
    }
}
