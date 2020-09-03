/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution7 {
    public int Reverse(int x) {
        long ans = 0;
        int sign = x >= 0 ? 1 : -1;
        x *= sign;
        while (x > 0)
        {
            ans = ans * 10 + x % 10;
            x /= 10;
        }
        ans *= sign;
        if (ans <= int.MaxValue && ans >= int.MinValue)
            return (int)ans;
        return 0;
    }
}
// @lc code=end

