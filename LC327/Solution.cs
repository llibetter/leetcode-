/*
327. 区间和的个数
给定一个整数数组 nums，返回区间和在 [lower, upper] 之间的个数，包含 lower 和 upper。
区间和 S(i, j) 表示在 nums 中，位置从 i 到 j 的元素之和，包含 i 和 j (i ≤ j)。

说明:
最直观的算法复杂度是 O(n2) ，请在此基础上优化你的算法。

示例:

输入: nums = [-2,5,-1], lower = -2, upper = 2,
输出: 3 
解释: 3个区间分别是: [0,0], [2,2], [0,2]，它们表示的和分别为: -2, -1, 2。
*/



/*
1、前缀和+暴力遍历，时间复杂度n2，超时

2、利用前缀和问题转化为”找到两下标，差在给定区间“，再利用归并排序，找到下标对数

3、思路和求逆序数那题一模一样，可以放一起写写
*/
public class Solution {
    //前缀和+暴力遍历，时间复杂度n2，超时
    public int CountRangeSum111(int[] nums, int lower, int upper) {
        if(nums==null||nums.Length==0) return 0;
        int len=nums.Length;
        long[] presum=new long[len+1];
        for(int i=1;i<presum.Length;i++)
        {
            presum[i]=presum[i-1]+nums[i-1];
        }
        int result=0;
        for(int i=0;i<len;i++)
            for(int j=i;j<len;j++)
            {
                long sum=(presum[j+1]-presum[i]);
                if(sum>=lower&&sum<=upper)
                    result++;
            }
        return result;
    }

    int result=0;
    int LeftValue=0;
    int RightValue=0;
    public int CountRangeSum(int[] nums, int lower, int upper){
        LeftValue=lower;
        RightValue=upper;
        int len=nums.Length;
        long[] prefixsum=new long[len+1];
        for(int i=1;i<=len;i++)
        {
            prefixsum[i]=prefixsum[i-1]+nums[i-1];
        }
        MergeSort(prefixsum,0,len);
        return result;
    }

    public void MergeSort(long[] nums,int left,int right)
    {
        if(left>=right) return;
        int mid=left+(right-left)/2;
        MergeSort(nums,left,mid);
        MergeSort(nums,mid+1,right);
        int leftIndex=mid+1;
        int rightIndex=0;
        for(int k=left;k<=mid;k++)
        {
            while(leftIndex<=right&&nums[k]+LeftValue>nums[leftIndex])
                leftIndex++;
            rightIndex=leftIndex;
            while(rightIndex<=right&&nums[rightIndex]<=nums[k]+RightValue)
                rightIndex++;
            result+=rightIndex-leftIndex;
        }
        long[] tmp=new long[right-left+1];
        int index=0;
        int i=left;
        int j=mid+1;
        while(i<=mid&&j<=right)
        {
            if(nums[i]<=nums[j])
            {
                tmp[index++]=nums[i++];
            }
            else
                tmp[index++]=nums[j++];
        } 
        while(i<=mid)
        {
            tmp[index++]=nums[i++];
        }
        while(j<=right)
        {
            tmp[index++]=nums[j++];
        }
        index=0;
        for(int k=left;k<=right;k++)
        {
            nums[k]=tmp[index++];
        }
    }

}