using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public class _315 : BaseClass
    {
        public override void Run()
        {
            Test();
        }

        public IList<int> CountSmaller(int[] nums)
        {
            return null;
        }

        private int Lowbit(int value)
        {
            return value & -value;
        }

        #region 树状数组demo
        private void Test()
        {
            var arr = new int[] { 4, 7, 3, 8, 5, 6, 7, 0, 1, 4, 6, 7, 2, 12, 5453, 35, 12456, 63 };
            var treeArr = new int[arr.Length];
            treeArr[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if ((i & 1) == 0)
                    treeArr[i] = arr[i];
                else
                    treeArr[i] = arr[i] + Sum(treeArr, i - 1) - Sum(treeArr, i - Lowbit(i + 1));

            for (int i = 0; i < arr.Length; i++)
                Assert(arr.Take(i + 1).Sum(), Sum(treeArr, i));
        }

        private void Update(int[] arr, int index, int val)
        {

        }

        private int Sum(int[] arr, int index)
        {
            if (index < 0)
                return 0;
            int ans = 0;
            do
            {
                ans += arr[index];
                index -= Lowbit(index + 1);
            } while (index >= 0);
            return ans;
        }
        #endregion
    }
}
