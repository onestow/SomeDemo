using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _841 : BaseClass
    {
        public override void Run()
        {
            var t = CanVisitAllRooms(new IList<int>[]
            {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{},
            });
            Assert(t, true);
            t = CanVisitAllRooms(new IList<int>[]
            {
                new int[]{1,3},
                new int[]{3, 0, 1},
                new int[]{2},
                new int[]{0},
            });
            Assert(t, false);
        }

        bool[] visited;
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            visited = new bool[rooms.Count];
            dfs(rooms, 0);
            return visited.All(b => b);
        }

        private void dfs(IList<IList<int>> rooms, int di)
        {
            visited[di] = true;
            foreach(var ndi in rooms[di])
            {
                if (visited[ndi])
                    continue;
                dfs(rooms, ndi);
            }
        }
    }
}
