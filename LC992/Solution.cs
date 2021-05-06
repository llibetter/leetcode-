public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        if(matrix==null||matrix.Length==0||matrix[0].Length==0) return -1;
        int row=matrix.Length;
        int col=matrix[0].Length;
        int ans=int.MinValue;
        for(int i=0;i<row;i++)
        {
            int[] sum=new int[col];
            for(int j=i;j<row;j++)
            {
                for(int m=0;m<col;m++)
                {
                    sum[m]+=matrix[j][m];
                    List<int> l=new List<int>();
                    l.Add(0);
                    int prefixSum=0;
                    for(int n=0;n<col;n++)
                    {
                        prefixSum+=sum[n];
                        int index=BinaryFind(l,prefixSum-k);
                        if(index!=l.Count)
                        {
                            ans=Math.Max(ans,prefixSum-l[index]);
                        }
                        BinaryInsert(l,prefixSum);
                    }
                }
            }
        }
        return ans;
    }

    public int BinaryFind(List<int> l,int val)
    {
        int left=0;
        int right=l.Count;
        while(left<right)
        {
            int mid=left+(right-left)/2;
            if(l[mid]<val)
                left=mid+1;
            else
                right=mid;
        }
        return left;
    }

    public void BinaryInsert(List<int> l,int val)
    {
        int index=BinaryFind(l,val);
        l.Insert(index,val);
    }
}