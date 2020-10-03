using System.Collections.Generic;
//两数之和
//哈希表，典型的空间换时间
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> dic=new Dictionary<int,int>();
        for(int i=0;i<nums.Length;i++)
        {
            int diff=target-nums[i];
            if(dic.ContainsKey(diff))
                return new int[]{i,dic[diff]};
            dic[nums[i]]=i;
        }
        return null;
    }
}