public class Solution
{
    public bool ValidMountainArray111(int[] A)
    {
        if (A == null || A.Length < 3) return false;
        int len = A.Length;
        if (A[0] >= A[1] || A[len - 2] <= A[len - 1]) return false;

        bool b = true;
        for (int i = 1; i < len - 2; i++)
        {
            if (A[i] == A[i + 1]) return false;
            else if (A[i] < A[i + 1])
            {
                if (b)
                    continue;
                else return false;
            }
            else
            {
                if (b)
                {
                    b = false; continue;
                }
                else continue;
            }
        }
        return true;
    }
    /*
    941. 有效的山脉数组
给定一个整数数组 A，如果它是有效的山脉数组就返回 true，否则返回 false。

让我们回顾一下，如果 A 满足下述条件，那么它是一个山脉数组：

A.length >= 3
在 0 < i < A.length - 1 条件下，存在 i 使得：
A[0] < A[1] < ... A[i-1] < A[i]
A[i] > A[i+1] > ... > A[A.length - 1]
 
    */

    //双指针找山峰，再看山峰是否相等
    public bool ValidMountainArray(int[] A)
    {
        if (A == null || A.Length < 3) return false;
        int len = A.Length;
        int left = 0;
        int right = len - 1;
        while (left < len - 1 && A[left] < A[left + 1])
            left++;
        while (right > 0 && A[right - 1] > A[right])
            right--;

        return left == right && left > 0 && left < len - 1;
    }
}