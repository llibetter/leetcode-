using System;
using System.Collections.Generic;
public class Solution
{
    public int MinChanges(int[] nums, int k)
    {
        Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();
        Dictionary<int, int> dicCount = new Dictionary<int, int>();
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            int group = i % k;
            if (!dicCount.ContainsKey(group))
                dicCount.Add(group, 1);
            else
                dicCount[group]++;
            if (!dic.ContainsKey(group))
                dic.Add(group, new Dictionary<int, int>());
            if (!dic[group].ContainsKey(nums[i]))
                dic[group].Add(nums[i], 1);
            else
                dic[group][nums[i]]++;
        }
        int maxLength = 1 << 10;
        int[,] dp = new int[k, maxLength];
        int minValue = int.MaxValue;
        for (int col = 0; col < maxLength; col++)
        {
            if (dic[0].ContainsKey(col))
                dp[0, col] = dicCount[0] - dic[0][col];
            else
                dp[0, col] = dicCount[0];
            minValue = Math.Min(minValue, dp[0, col]);
        }
        for (int i = 1; i < k; i++)
        {
            int tmp = int.MaxValue;
            for (int j = 0; j < maxLength; j++)
            {
                dp[i, j] = minValue;
                foreach (var item in dic[i])
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j ^ item.Key] - item.Value);
                }
                dp[i, j] += dicCount[i];
                tmp = Math.Min(tmp, dp[i, j]);
            }
            minValue = tmp;
        }
        return dp[k - 1, 0];
    }
}