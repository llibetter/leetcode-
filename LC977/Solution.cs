public class Solution
{
    /*
    977. 有序数组的平方
给定一个按非递减顺序排序的整数数组 A，返回每个数字的平方组成的新数组，要求也按非递减顺序排序。
    */
    //由于输入数组非递减，那么数组平方和，从首尾两端开始向中间移动，是非递增的，
    //很容易想到双指针，先求平方，再利用双指针向中间靠近
    public int[] SortedSquares(int[] A)
    {
        if (A == null || A.Length == 0) return null;
        int len = A.Length;
        for (int i = 0; i < len; i++)
        {
            A[i] = A[i] * A[i];
        }
        int[] result = new int[len];
        int left = 0;
        int right = len - 1;
        for (int i = len - 1; i >= 0; i--)
        {
            if (A[left] >= A[right])
                result[i] = A[left++];
            else
                result[i] = A[right--];
        }
        return result;
    }
}