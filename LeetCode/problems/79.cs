using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _79 : BaseClass
    {
        public override void Run()
        {
            bool t;
            char[][] board;
            board = new char[29][];
            for (int i = 0; i < board.Length; i++)
                board[i] = "".PadLeft(30, 'A').ToArray();
            board[0][0] = 'b';
            t = Exist(board, "bAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Assert(t, false);

            board = new char[][] { new char[] { 'a' } };
            t = Exist(board, "a");
            Assert(t, true);

            board = new char[][]
            {
                  new char[]{'A','B','C','E'},
                  new char[]{'S','F','C','S'},
                  new char[]{'A','D','E','E'}
            };
            t = Exist(board, "ABCCED");
            Assert(t, true);
            t = Exist(board, "SEE");
            Assert(t, true);
            t = Exist(board, "ABCB");
            Assert(t, false);
        }

        string _word;
        int cnt;
        public bool Exist(char[][] board, string word)
        {
            _word = word;
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[0].Length; j++)
                {
                    cnt = 0;
                    if (dfs(board, i, j, 0))
                        return true;
                }
            return false;
        }

        bool dfs(char[][] m, int x, int y, int wi)
        {
            cnt += 1;
            if (m[x][y] != _word[wi])
                return false;
            if (wi == _word.Length - 1)
                return true;

            char tmp = m[x][y];
            m[x][y] = '0';
            if (x > 0 && dfs(m, x - 1, y, wi + 1))
                return true;
            if (x < m.Length - 1 && dfs(m, x + 1, y, wi + 1))
                return true;
            if (y > 0 && dfs(m, x, y - 1, wi + 1))
                return true;
            if (y < m[0].Length - 1 && dfs(m, x, y + 1, wi + 1))
                return true;
            m[x][y] = tmp;

            return false;
        }
    }
}
