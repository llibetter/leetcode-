using System;
/*
845. 数组中的最长山脉
我们把数组 A 中符合下列属性的任意连续子数组 B 称为 “山脉”：

B.length >= 3
存在 0 < i < B.length - 1 使得 B[0] < B[1] < ... B[i-1] < B[i] > B[i+1] > ... > B[B.length - 1]
（注意：B 可以是 A 的任意子数组，包括整个数组 A。）

给出一个整数数组 A，返回最长 “山脉” 的长度。

如果不含有 “山脉” 则返回 0。

 

示例 1：

输入：[2,1,4,7,3,2,5]
输出：5
解释：最长的 “山脉” 是 [1,4,7,3,2]，长度为 5。
*/


/*
早上好，打工人们！

这题基本上有两个思路：

1、先遍历找山峰，再中心扩展，时间复杂度n2，空间复杂度1，如果利用辅助数组，空间换时间，时、空间复杂度均为n

2、从头开始，往后遍历找下一个山脚，如果找到下一个山脚则取较大者，如果没找到置left=i；
这种方法时间复杂度n，空间复杂度1，但是思路不太容易想到，代码也不太好写，下面代码是第二种方法。
*/

public class Solution {
    public int LongestMountain(int[] A) {
        if(A==null||A.Length<3) return 0;
        int len=A.Length;
        int result=0;
        int left=0;
        while(left+2<len)
        {
            int i=left+1;
            if(i<len&&A[i]>A[left])
            {
                while(i+1<len&&A[i]<A[i+1])
                    i++;
                if(i+1<len&&A[i+1]<A[i])
                {
                    while(i+1<len&&A[i+1]<A[i])
                        i++;
                    result=Math.Max(i-left+1,result);
                    left=i;
                }
                else
                    left=i;
            }
            else
                left=i;
        }
        return result;
    }
}