/*
给定一个只包含正整数的非空数组。是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。

注意:

每个数组中的元素不会超过 100
数组的大小不会超过 200

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/partition-equal-subset-sum
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


/*
1、等和即各占一半，首先求和，若奇数必不可能，若偶数则动态规划

2、动态规划时，首先看最后一位，若不取，则考虑在前面数位取和， 若取，则考虑在前面数位取差值，思考到这里转移方程就呼之欲出了

3、编码实现时注意DP数组长宽，可以各增一位，避免过多的边界条件处理
*/

using System.Linq;
public class Solution {
    public bool CanPartition(int[] nums) {
        int sum=nums.Sum();
        if(sum%2==1) return false;
        int h=nums.Length+1;
        int w=sum/2+1;
        bool[,] dp=new bool[h,w];
        for(int i=0;i<h;i++) dp[i,0]=true;
        for(int j=1;j<w;j++) dp[0,j]=false;
        for(int i=1;i<h;i++)
            for(int j=1;j<w;j++)
            {
                if(nums[i-1]>j)
                    dp[i,j]=dp[i-1,j];
                else 
                    dp[i,j]=dp[i-1,j]||dp[i-1,j-nums[i-1]];
            }
        return dp[h-1,w-1];
    }
}