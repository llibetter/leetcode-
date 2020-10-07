public class Solution {

    /*
    给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。

此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。

注意:
不能使用代码库中的排序函数来解决这道题。

示例:

输入: [2,0,2,1,1,0]
输出: [0,0,1,1,2,2]

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/sort-colors
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


双指针定位下一个0和2应该放置的位置，注意i循环到right，而不是nums.Length
    */
    public void SortColors(int[] nums) {
        int left=0;
        int right=nums.Length-1;
        for(int i=0;i<=right;i++)
        {
            if(nums[i]==0)
            {
                nums[i]=nums[left];
                nums[left++]=0;
            }
            else if(nums[i]==2)
            {
                nums[i]=nums[right];
                nums[right--]=2;
                i--;
            }          
        }     
    }
}