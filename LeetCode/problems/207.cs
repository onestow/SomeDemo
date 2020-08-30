using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _207 : BaseClass
    {
        public override void Run()
        {
            bool t;
            t = CanFinish(2, new int[][]
            {
                new int[]{1, 0}
            });
            Assert(t, true);
            t = CanFinish(2, new int[][]
            {
                new int[]{1, 0},
                new int[]{0, 1}
            });
            Assert(t, false);
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var cntIns = new int[numCourses];
            var visited = new bool[numCourses];
            var outs = new List<int>[numCourses];

            for (int i = 0; i < prerequisites.Length; i++)
            {
                var from = prerequisites[i][1];
                var to = prerequisites[i][0];

                cntIns[to] += 1;
                if (outs[from] == null)
                    outs[from] = new List<int>();
                outs[from].Add(to);
            }

            var cnt = numCourses;
            while (cnt > 0)
            {
                bool flag = false;
                for (int i = 0; i < numCourses; i++)
                    if (!visited[i] && cntIns[i] == 0)
                    {
                        flag = true;
                        visited[i] = true;
                        cnt -= 1;
                        if (outs[i] != null)
                        {
                            foreach (var to in outs[i])
                                cntIns[to] -= 1;
                        }
                    }
                if (!flag)
                    break;
            }
            return cnt == 0;
        }
    }
}
