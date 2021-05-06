using System;
public class Solution
{
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        for (int i = 0; i < m; i++)
            houses[i]--;
        int[,,] dp = new int[m, n, target];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < target; k++)
                    dp[i, j, k] = int.MaxValue;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (houses[i] != -1 && houses[i] != j) continue;
                for (int k = 0; k < target; k++)
                {
                    for (int j0 = 0; j0 < n; j0++)
                    {
                        if (j0 == j)
                        {
                            if (i == 0)
                            {
                                if (k == 0) dp[i, j, k] = 0;
                            }
                            else
                                dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j, k]);
                        }
                        else if (i > 0 && k > 0)
                            dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j0, k - 1]);
                    }
                    if (dp[i, j, k] != int.MaxValue && houses[i] == -1)
                    {
                        dp[i, j, k] += cost[i][j];
                    }
                }
            }
        }
        int ans = int.MaxValue;
        for (int j = 0; j < n; ++j)
        {
            ans = Math.Min(ans, dp[m - 1, j, target - 1]);
        }
        return ans == int.MaxValue ? -1 : ans;

    }
}