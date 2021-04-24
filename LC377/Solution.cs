public class Solution
{
    //错误解法
    public int CombinationSum4xxx(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0) return 0;
        int len = nums.Length;
        int[,] dp = new int[len + 1, target + 1];
        for (int i = 0; i <= len; i++)
            dp[i, 0] = 1;
        for (int i = 1; i <= len; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (nums[i - 1] > j)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - nums[i - 1]];
                }
            }
        }
        return dp[len, target];
    }
    ///正确解法
    public int CombinationSum4(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0) return 0;
        int len = nums.Length;
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i <= target; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (nums[j] <= i)
                {
                    dp[i] += dp[i - nums[j]];
                }
            }
        }
        return dp[target];
    }
}