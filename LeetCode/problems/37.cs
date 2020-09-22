using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _37 : BaseClass
    {
        public override void Run()
        {
            var board = new char[][]
            {
new char[]{'5','3','.','.','7','.','.','.','.'},
new char[]{'6','.','.','1','9','5','.','.','.'},
new char[]{'.','9','8','.','.','.','.','6','.'},
new char[]{'8','.','.','.','6','.','.','.','3'},
new char[]{'4','.','.','8','.','3','.','.','1'},
new char[]{'7','.','.','.','2','.','.','.','6'},
new char[]{'.','6','.','.','.','.','2','8','.'},
new char[]{'.','.','.','4','1','9','.','.','5'},
new char[]{'.','.','.','.','8','.','.','7','9'}
            };
            SolveSudoku(board);

            for (int i = 0; i < 9; i++)
                Console.WriteLine(new string(board[i]));
            Console.ReadKey(true);
        }

        int[] vi, vj, vz;
        public void SolveSudoku(char[][] board)
        {
            vi = new int[9];
            vj = new int[9];
            vz = new int[9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (board[i][j] != '.')
                        Set(i, j, board[i][j], true);
            dfs(board, 0, 0);
        }

        void Set(int i, int j, char ch, bool isAdd)
        {
            var v = ch & 0xf;
            if (isAdd)
            {
                vi[i] |= 1 << v;
                vj[j] |= 1 << v;
                vz[i / 3 * 3 + j / 3] |= 1 << v;
            }
            else
            {
                vi[i] ^= 1 << v;
                vj[j] ^= 1 << v;
                vz[i / 3 * 3 + j / 3] ^= 1 << v;
            }
        }

        public bool dfs(char[][] board, int i, int j)
        {
            if (i == 9)
                return true;

            int ni, nj;
            if (j == 8)
            {
                ni = i + 1;
                nj = 0;
            }
            else
            {
                ni = i;
                nj = j + 1;
            }
            if (board[i][j] != '.')
                return dfs(board, ni, nj);
            for (char v = '1'; v <= '9'; v++)
            {
                if (!Check(i, j, v & 0xf))
                    continue;
                Set(i, j, v, true);
                board[i][j] = v;
                if (dfs(board, ni, nj))
                    return true;
                Set(i, j, v, false);
                board[i][j] = '.';
            }
            return false;
        }

        bool Check(int i, int j, int v)
        {
            var ov = vi[i] | vj[j] | vz[i / 3 * 3 + j / 3];
            var b = 1 << v;
            if ((ov & b) == b)
                return false;
            return true;
        }
    }
}
