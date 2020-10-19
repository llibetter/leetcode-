using System;
public class Solution {
    public int BestTeamScore(int[] scores, int[] ages) {
        int len=scores.Length;
        int[][] matrix=new int[len][];
        for(int i=0;i<len;i++)
        {
            matrix[i]=new int[]{scores[i],ages[i]};
        }
        Array.Sort(matrix,(a,b)=>{
            if(a[1]!=b[1])
                return a[1]-b[1];
            else
                return a[0]-b[0];
        });
        int[] dp=new int[len];
        int result=0;
        for(int i=0;i<len;i++)
        {
            dp[i]=matrix[i][0];
            for(int j=0;j<i;j++)
            {
                if(matrix[j][0]<=matrix[i][0])
                {
                    dp[i]=Math.Max(dp[i],matrix[i][0]+dp[j]);
                }
            }
            result=Math.Max(result,dp[i]);    
        }
        return result;
     
    }
}