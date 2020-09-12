using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LeetCode.problems
{
    public class _347 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        Dictionary<int, int> dict;
        public int[] TopKFrequent(int[] nums, int k)
        {
            dict = new Dictionary<int, int>();
            foreach(var num in nums)
                if (dict.TryGetValue(num, out int cnt))
                    dict[num] = cnt + 1;
                else
                    dict[num] = 1;

            return dict.OrderByDescending(kv => kv.Value).Take(k).Select(kv => kv.Key).ToArray();
        }
    }
}
