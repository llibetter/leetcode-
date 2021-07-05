using System.Text;
using System;
public class Solution
{
    public string LargestNumber(int[] cost, int target)
    {
        if (cost == null || cost.Length == 0) return "0";
        int len = cost.Length;
        (int, int)[,] dp = new (int, int)[len + 1, target + 1];
        for(int j=1;j<=target;j++)
            dp[0,j]=(int.MinValue,0);
        for (int i = 1; i <= len; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (j < cost[i - 1])
                {
                    dp[i, j] = (dp[i - 1, j].Item1, 0);
                }
                else
                {
                    if (dp[i - 1, j].Item1 > dp[i, j - cost[i - 1]].Item1 + 1)
                        dp[i, j] = (dp[i - 1, j].Item1, 0);
                    else
                        dp[i, j] = (dp[i, j - cost[i - 1]].Item1 + 1, i);
                }
            }
        }
        int count = dp[len, target].Item1;
        Console.WriteLine(count);
        StringBuilder result = new StringBuilder();
        while (count > 0)
        {
            if (dp[len, target].Item2 != 0)
            {
                result.Append(dp[len, target].Item2);
                target -= cost[dp[len, target].Item2-1];
                 count--;

            }
            else
            {
                len--;
            }
           
        }
        return result.ToString();
    }
}