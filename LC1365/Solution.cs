using System;
using System.Collections.Generic;

/*
1365. 有多少小于当前数字的数字
给你一个数组 nums，对于其中每个元素 nums[i]，请你统计数组中比它小的所有数字的数目。

换而言之，对于每个 nums[i] 你必须计算出有效的 j 的数量，其中 j 满足 j != i 且 nums[j] < nums[i] 。

以数组形式返回答案。

 

示例 1：

输入：nums = [8,1,2,2,3]
输出：[4,0,1,1,3]
解释： 
对于 nums[0]=8 存在四个比它小的数字：（1，2，2 和 3）。 
对于 nums[1]=1 不存在比它小的数字。
对于 nums[2]=2 存在一个比它小的数字：（1）。 
对于 nums[3]=2 存在一个比它小的数字：（1）。 
对于 nums[4]=3 存在三个比它小的数字：（1，2 和 2）。
*/

//本质还是想考察计数排序，直接看第三种写法吧，哎喉咙痛，枯了😪😪😪
public class Solution {
    public int[] SmallerNumbersThanCurrent111(int[] nums) {
        int len=nums.Length;
        int[][] arr=new int[len][];
        for(int i=0;i<len;i++)
        {
            arr[i]=new int[]{nums[i],i};
        }
        Array.Sort(arr,(a,b)=>{
            return a[0]-b[0];
        });
        int last=arr[0][0];
        int cnt=1;
        arr[0][0]=0;
        for(int i=1;i<len;i++)
        {
            if(arr[i][0]==last)
            {
                arr[i][0]=arr[i-1][0];
                cnt++;
            }
            else
            {
                last=arr[i][0];
                arr[i][0]=arr[i-1][0]+cnt;
                cnt=1;
            }
        }
        Array.Sort(arr,(a,b)=>{
            return a[1]-b[1];
        });
        int[] result=new int[len];
        for(int i=0;i<len;i++)
        {
            result[i]=arr[i][0];
        }
        return result;
    }

    public int[] SmallerNumbersThanCurrent(int[] nums) {
        int[] result=new int[nums.Length];
        Dictionary<int,int> dic=new Dictionary<int,int>();
        foreach(int  i in nums)
        {
            if(dic.ContainsKey(i)) dic[i]++;
            else dic.Add(i,1);
        }
        for(int i=0;i<result.Length;i++)
        {
            foreach(var item in dic)
            {
                if(item.Key<nums[i])
                 result[i]+=item.Value;
            }
        }
        return result;
    }

    public int[] SmallerNumbersThanCurrent222(int[] nums) {
        int[] result=new int[nums.Length];
        int[] freq=new int[101];
        foreach(int i in nums)
        {
            freq[i]++;
        }
        for(int i=1;i<101;i++)
        {
            freq[i]+=freq[i-1];
        }
        for(int i=0;i<result.Length;i++)
        {
           if(nums[i]==0) continue;
           result[i]=freq[nums[i]-1];
        }
        return result;
    }
}