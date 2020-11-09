using System;

/*
973. 最接近原点的 K 个点
我们有一个由平面上的点组成的列表 points。需要从中找出 K 个距离原点 (0, 0) 最近的点。

（这里，平面上两点之间的距离是欧几里德距离。）

你可以按任何顺序返回答案。除了点坐标的顺序之外，答案确保是唯一的。

 

示例 1：

输入：points = [[1,3],[-2,2]], K = 1
输出：[[-2,2]]
解释： 
(1, 3) 和原点之间的距离为 sqrt(10)，
(-2, 2) 和原点之间的距离为 sqrt(8)，
由于 sqrt(8) < sqrt(10)，(-2, 2) 离原点更近。
我们只需要距离原点最近的 K = 1 个点，所以答案就是 [[-2,2]]。
*/

//直接调用排序函数，简单点

public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        Array.Sort(points,(a,b)=>{
            return a[0]*a[0]+a[1]*a[1]-b[0]*b[0]-b[1]*b[1];
        });
        int[][] result=new int[K][];
        for(int i=0;i<K;i++)
        {
            result[i]=points[i];
        }
        return result;
    }
}