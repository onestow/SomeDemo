using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _529 : BaseClass
    {
        public override void Run()
        {
            var f = UpdateBoard(new char[][]
            {
                new char[]{'E','E','E','E','E','E','E','E'},
                new char[]{'E','E','E','E','E','E','E','M'},
                new char[]{'E','E','M','E','E','E','E','E'},
                new char[]{'M','E','E','E','E','E','E','E'},
                new char[]{'E','E','E','E','E','E','E','E'},
                new char[]{'E','E','E','E','E','E','E','E'},
                new char[]{'E','E','E','E','E','E','E','E'},
                new char[]{'E','E','M','M','E','E','E','E'}
            }, new int[] { 0, 0 });

            var res = string.Join(Environment.NewLine, f.Select(ff => string.Join("", ff)));
        }

        int rn, cn;
        short[,] mCnts;
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            if (board[click[0]][click[1]] == 'M')
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }

            rn = board.Length;
            cn = board[0].Length;
            mCnts = new short[rn, cn];
            CalMCnt(board);

            dfs(board, click[0], click[1]);
            return board;
        }

        private void CalMCnt(char[][] board)
        {
            var dir = new int[8][]
            {
                new int[]{-1, -1},
                new int[]{-1, 0},
                new int[]{-1, 1},
                new int[]{1, -1},
                new int[]{1, 0},
                new int[]{1, 1},
                new int[]{0, -1},
                new int[]{0, 1},
            };
            for (int i = 0; i < rn; i++)
                for (int j = 0; j < cn; j++)
                {
                    if (board[i][j] == 'M')
                    {
                        foreach (var d in dir)
                        {
                            int x = i + d[0], y = j + d[1];
                            if (x >= 0 && x < rn && y >= 0 && y < cn)
                                mCnts[x, y] += 1;
                        }
                    }
                }
        }

        private void dfs(char[][] board, int x, int y)
        {
            if (x < 0 || x == rn || y < 0 || y == cn)
                return;
            if (board[x][y] != 'E')
                return;
            var mCnt = mCnts[x, y];
            if (mCnt != 0)
            {
                board[x][y] = (char)(mCnt + 0x30);
                return;
            }

            board[x][y] = 'B';
            dfs(board, x, y + 1);
            dfs(board, x, y - 1);
            dfs(board, x - 1, y - 1);
            dfs(board, x - 1, y);
            dfs(board, x - 1, y + 1);
            dfs(board, x + 1, y - 1);
            dfs(board, x + 1, y);
            dfs(board, x + 1, y + 1);
        }
    }
}
