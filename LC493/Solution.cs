public class Solution {
    public int ReversePairs(int[] nums) {
        if(nums==null||nums.Length<2) return 0;
        int len=nums.Length;
     
        return MergeSort(nums,0,len-1);
    }

    public int MergeSort(int[] nums,int l,int r)
    {
        if(l>=r) return 0;
        int mid=l+(r-l)/2;
        int res1=MergeSort(nums,l,mid);
        int res2=MergeSort(nums,mid+1,r);
        int[] tmp=new int[r-l+1];
        int index=0;
        int p1=l;
        int p2=mid+1;
        int res3=0;
        while(p1<=mid)
        {
         while(p1<=mid&&(long)nums[p1]<=(long)nums[p2]*2)
                p1++;
            if(p1<=mid)
            {
                res3+=mid-p1+1;
                p2++;
            }
        }
           
        p1=l;
        p2=mid+1;
        while(p1<=mid&&p2<=r)
        {
            if(nums[p1]<nums[p2])
                tmp[index++]=nums[p1++];
            else
            {
            
                tmp[index++]=nums[p2++];
            }
               
        }
        while(p1<=mid)
            tmp[index++]=nums[p1++];
        while(p2<=r)
            tmp[index++]=nums[p2++];
        
        for(int i=0;i<tmp.Length;i++)
            nums[l+i]=tmp[i];
        return res1+res2+res3;
    }
}