/*
57. 插入区间
给出一个无重叠的 ，按照区间起始端点排序的区间列表。

在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。

 

示例 1：

输入：intervals = [[1,3],[6,9]], newInterval = [2,5]
输出：[[1,5],[6,9]]
*/


//分三段平铺直叙，一次AC就很nice😛😛😛
using System.Collections.Generic;
using System; 
public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> list=new List<int[]>();
        int len=intervals.Length;
        int index=0;
        while(index<len&&intervals[index][1]<newInterval[0])
        {
            list.Add(intervals[index]);
            index++;
        }
        while(index<len&&newInterval[1]>=intervals[index][0])
        {
            newInterval[0]=Math.Min(newInterval[0],intervals[index][0]);
            newInterval[1]=Math.Max(newInterval[1],intervals[index][1]);
            index++;
        }
        list.Add(newInterval);
        while(index<len)
        {
            list.Add(intervals[index]);
            index++;
        }
        return list.ToArray();
    }
}