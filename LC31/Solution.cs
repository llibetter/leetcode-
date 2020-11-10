
/*
31. 下一个排列
实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。

如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。

必须原地修改，只允许使用额外常数空间。

以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
1,2,3 → 1,3,2
3,2,1 → 1,2,3
1,1,5 → 1,5,1
*/

/*
其实就是寻找字典序的下一个数，分三步走就行了。

1、逆序寻找降序索引index

2、从后向前寻找比index-1大的索引index2，交换值

3、把后半部逆序部分倒序

*/
public class Solution {
    public void NextPermutation(int[] nums) {
        if(nums==null||nums.Length<2) return;
        int len=nums.Length;
        int index=len-1;
        while(index>0&&nums[index]<=nums[index-1])
            index--;
        int index2;
        if(index!=0)
        {
            index2=len-1;
            while(nums[index2]<=nums[index-1])
                index2--;
            Swap(nums,index-1,index2);
        }
        index2=len-1;
        while(index<index2)
        {
            Swap(nums,index,index2);
            index++;
            index2--;
        }
    }

    public void Swap(int[] nums,int index1,int index2)
    {
        int temp=nums[index1];
        nums[index1]=nums[index2];
        nums[index2]=temp;
    }
}