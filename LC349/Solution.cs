using System.Collections.Generic;
using System.Linq;
/*
349. 两个数组的交集
给定两个数组，编写一个函数来计算它们的交集。

示例 1：

输入：nums1 = [1,2,2,1], nums2 = [2,2]
输出：[2]
*/
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> res=new HashSet<int>();
        HashSet<int> hs=new HashSet<int>(nums2);
        foreach(var item in nums1)
        {
            if(hs.Contains(item))
                res.Add(item);
        }
        return res.ToArray();
    }
}