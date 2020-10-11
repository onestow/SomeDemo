using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _771 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int NumJewelsInStones(string J, string S)
        {
            var set = new HashSet<char>(J);
            return S.Count(ch => set.Contains(ch));
        }
    }
}
