/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
using System.Collections.Generic;
using System.Linq;

public class Solution51
{
    bool[] visV, visS, visD;
    IList<IList<string>> ans;
    int[] queueLocations;
    string[] rows;
    public IList<IList<string>> SolveNQueens(int n)
    {
        visV = new bool[n];
        visS = new bool[n << 1];
        visD = new bool[n << 1];
        queueLocations = new int[n];
        rows = new string[n];
        string baseRow = "".PadLeft(n - 1, '.');
        for (int i = 0; i < n; i++)
            rows[i] = baseRow.Insert(i, "Q");
        ans = new List<IList<string>>();
        dfs(0, n);
        return ans;
    }
    private void dfs(int ci, int n)
    {
        if (ci == n)
        {
            ans.Add(queueLocations.Select(i => rows[i]).ToArray());
            return;
        }
        for (int i = 0; i < n; i++)
        {
            if (visV[i] || visS[i + ci] || visD[i - ci + n])
                continue;
            visV[i] = visS[i + ci] = visD[i - ci + n] = true;
            queueLocations[ci] = i;
            dfs(ci + 1, n);
            visV[i] = visS[i + ci] = visD[i - ci + n] = false;
        }
    }
}
// @lc code=end

