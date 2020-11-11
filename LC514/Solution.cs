/*
514. 自由之路
电子游戏“辐射4”中，任务“通向自由”要求玩家到达名为“Freedom Trail Ring”的金属表盘，并使用表盘拼写特定关键词才能开门。

给定一个字符串 ring，表示刻在外环上的编码；给定另一个字符串 key，表示需要拼写的关键词。您需要算出能够拼写关键词中所有字符的最少步数。

最初，ring 的第一个字符与12:00方向对齐。您需要顺时针或逆时针旋转 ring 以使 key 的一个字符在 12:00 方向对齐，然后按下中心按钮，以此逐个拼写完 key 中的所有字符。

旋转 ring 拼出 key 字符 key[i] 的阶段中：

您可以将 ring 顺时针或逆时针旋转一个位置，计为1步。旋转的最终目的是将字符串 ring 的一个字符与 12:00 方向对齐，并且这个字符必须等于字符 key[i] 。
如果字符 key[i] 已经对齐到12:00方向，您需要按下中心按钮进行拼写，这也将算作 1 步。按完之后，您可以开始拼写 key 的下一个字符（下一阶段）, 直至完成所有拼写。
示例：

 
输入: ring = "godding", key = "gd"
输出: 4
解释:
 对于 key 的第一个字符 'g'，已经在正确的位置, 我们只需要1步来拼写这个字符。 
 对于 key 的第二个字符 'd'，我们需要逆时针旋转 ring "godding" 2步使它变成 "ddinggo"。
 当然, 我们还需要1步进行拼写。
 因此最终的输出是 4。
*/


/*
这种把动态规划融于实际场景的题目真是妙呀！绝妙！

第一次匹配字符会影响后续匹配字符的次数，所以应该从最后一次匹配字符开始思考，从后往前，典型的DP

画个DP表，填表，然后用代码实现就可以了
*/
using System;
using System.Collections.Generic;
public class Solution111 {
    public int FindRotateSteps(string ring, string key) {
        int len1=ring.Length;
        int len2=key.Length;
        int[,] dp=new int[len1,len2];
        for(int j=len2-1;j>=0;j--)
            for(int i=len1-1;i>=0;i--)
            {
                dp[i,j]=int.MaxValue;
                char target=key[j];
                int index=0;
                while(index<len1)
                {
                    int pos=(i+index)%len1;
                    if(ring[pos]==target)
                    {
                        int min=Math.Min(index,len1-index);
                        if(j!=len2-1)
                            min+=dp[pos,j+1];
                        dp[i,j]=Math.Min(dp[i,j],min+1);
                    }
                    index++;
                }
            }
        return dp[0,0];
    }
}

/*
最里面的循环可以用空间换时间，优化一下，

先这样，再这样，最后这样，看，好了吧！
*/
public class Solution {
    public int FindRotateSteps(string ring, string key) {
        int len1=ring.Length;
        int len2=key.Length;
        int[,] dp=new int[len1,len2];
        List<int>[] position=new List<int>[26];
        for(int i=0;i<len1;i++)
        {
            int index=ring[i]-'a';
            if(position[index]==null)
                position[index]=new List<int>();
            position[index].Add(i);
        }

        for(int j=len2-1;j>=0;j--)
            for(int i=len1-1;i>=0;i--)
            {
                dp[i,j]=int.MaxValue;
                char target=key[j];
                int index=target-'a';
                for(int k=0;k<position[index].Count;k++)
                {
                    int gap=Math.Abs(position[index][k]-i);
                    int min=Math.Min(gap,len1-gap);
                    if(j!=len2-1)
                        min+=dp[position[index][k],j+1];
                    dp[i,j]=Math.Min(dp[i,j],min+1);
                }
            }
        return dp[0,0];
    }
}