using System;
/*
1024. 视频拼接
你将会获得一系列视频片段，这些片段来自于一项持续时长为 T 秒的体育赛事。这些片段可能有所重叠，也可能长度不一。

视频片段 clips[i] 都用区间进行表示：开始于 clips[i][0] 并于 clips[i][1] 结束。我们甚至可以对这些片段自由地再剪辑，例如片段 [0, 7] 可以剪切成 [0, 1] + [1, 3] + [3, 7] 三部分。

我们需要将这些片段进行再剪辑，并将剪辑后的内容拼接成覆盖整个运动过程的片段（[0, T]）。返回所需片段的最小数目，如果无法完成该任务，则返回 -1 。

 

示例 1：

输入：clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]], T = 10
输出：3
解释：
我们选中 [0,2], [8,10], [1,9] 这三个片段。
然后，按下面的方案重制比赛片段：
将 [1,9] 再剪辑为 [1,2] + [2,8] + [8,9] 。
现在我们手上有 [0,2] + [2,8] + [8,10]，而这些涵盖了整场比赛 [0, 10]。
*/

//DP或贪心，DP比较好理解，贪心真的难想，掏底了，我写不出贪心😢😢😢
public class Solution
{
    public int VideoStitching111(int[][] clips, int T)
    {
        int[] dp = new int[T + 1];
        for (int i = 1; i <= T; i++)
            dp[i] = int.MaxValue;
        for (int i = 1; i <= T; i++)
        {
            for (int j = 0; j < clips.Length; j++)
            {
                if (clips[j][0] <= i && i <= clips[j][1])
                {
                    if (clips[j][0] <= T && dp[clips[j][0]] != int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[clips[j][0]]);
                    }
                }
            }
        }
        return dp[T] == int.MaxValue ? -1 : dp[T];
    }

    public int VideoStitching(int[][] clips, int T)
    {
        int[] array = new int[T];
        foreach (var item in clips)
        {
            if (item[0] >= T) continue;
            array[item[0]] = Math.Max(array[item[0]], item[1]);
        }
        int result = 0;
        int pre = 0;
        int tmp = 0;
        for (int i = 0; i < T; i++)
        {
            tmp = Math.Max(tmp, array[i]);
            if (i == pre)
            {
                result++;
                pre = tmp;
            }

            if (i == tmp) return -1;
        }
        return result;
    }
}