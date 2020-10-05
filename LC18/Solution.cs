using System.Collections.Generic;
using System;

/*
给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，
使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。

注意：

答案中不可以包含重复的四元组。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/4sum
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

四数之和，先固定两个数，再利用左右指针，需要注意四个指针均需要判定去重
*/
public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        int len = nums.Length;
        for (int i = 0; i <= len - 4; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            for (int j = i + 1; j <= len - 3; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                int left = j + 1;
                int right = len - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[j] + nums[left] + nums[right];
                    if (sum < target)
                        left++;
                    else if (sum > target)
                        right--;
                    else
                    {
                        IList<int> tmp = new List<int>() { nums[i], nums[j], nums[left], nums[right] };
                        result.Add(tmp);
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        right--;
                    }
                }
            }
        }
        return result;
    }
}