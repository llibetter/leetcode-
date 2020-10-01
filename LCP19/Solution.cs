using System;
/*
LCP 19. 秋叶收藏集
小扣出去秋游，途中收集了一些红叶和黄叶，他利用这些叶子初步整理了一份秋叶收藏集 leaves， 
字符串 leaves 仅包含小写字符 r 和 y， 其中字符 r 表示一片红叶，字符 y 表示一片黄叶。
出于美观整齐的考虑，小扣想要将收藏集中树叶的排列调整成「红、黄、红」三部分。
每部分树叶数量可以不相等，但均需大于等于 1。每次调整操作，小扣可以将一片红叶替换成黄叶或者将一片黄叶替换成红叶。
请问小扣最少需要多少次调整操作才能将秋叶收藏集调整完毕。

https://leetcode-cn.com/problems/UlBDOe/

常规DP题，先画个用例填表，慢慢就有分三层的想法了

有些同学可能会问，怎么想得到分三种转换状态，这里解释下，

首先有一个字符串，接着右边加了个r，那么满足条件的前面可以是ry或ryr，直接取最小即可，那如果加的是y，就是最小+1

那么问题变为，字符转换为ry最小数，同理，需要前边字符串是r或ry，如果加y，直接取最小，如果加r，再次+1

问题此时变为，字符串全是r最小转换数，这个计算就显而易见了

这么思考下来，是不是觉得划分三种转换状态，也不是太难想到了呢，嘻嘻

国庆第一天，祝大家刷题愉快😁😁😁
*/
public class Solution
{
    public int MinimumOperations(string leaves)
    {
        int len = leaves.Length;
        int[,] dp = new int[3, len];
        dp[0, 0] = int.MaxValue;
        dp[0, 1] = int.MaxValue;
        dp[1, 0] = int.MaxValue;
        for (int i = 2; i >= 0; i--)
            for (int j = 2 - i; j < len; j++)
            {
                if (i == 2)
                {
                    if (j == 0)
                        dp[i, j] = leaves[j] == 'r' ? 0 : 1;
                    else
                        dp[i, j] = dp[i, j - 1] + (leaves[j] == 'r' ? 0 : 1);
                }
                else if (i == 1)
                {
                    dp[i, j] = Math.Min(dp[i, j - 1], dp[i + 1, j - 1]);
                    if (leaves[j] == 'r')
                        dp[i, j]++;
                }
                else if (i == 0)
                {
                    dp[i, j] = Math.Min(dp[i, j - 1], dp[i + 1, j - 1]);
                    if (leaves[j] == 'y')
                        dp[i, j]++;
                }
            }
        return dp[0, len - 1];
    }
}