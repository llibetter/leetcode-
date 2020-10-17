
    /*
    52. N皇后 II
n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
给定一个整数 n，返回 n 皇后不同的解决方案的数量。
    */

//经典回溯题了，回溯的过程中要注意有效函数的判断。
public class Solution {
    int result=0;
    int N=0;
    public int TotalNQueens(int n) {
        N=n;
        char[,] matrix=new char[n,n];
        for(int i=0;i<n;i++)
            for(int j=0;j<n;j++)
                matrix[i,j]='.';
        BackTrack(matrix,0);
        return result;
    }

    public void BackTrack(char[,] matrix,int index)
    {
        if(index==N)
        {
            result++;
            return;
        }
        for(int i=0;i<N;i++)
        {
            if(IsVaild(matrix,index,i))
            {
                matrix[index,i]='Q';
                BackTrack(matrix,index+1);
                matrix[index,i]='.';
            }
        }
    }

    public bool IsVaild(char[,] matrix,int i,int j)
    {
        for(int row=0;row<i;row++)
        {
            if(matrix[row,j]=='Q') return false;
        }

        for(int row=i-1,col=j-1;row>=0&&col>=0;row--,col--)
        {
            if(matrix[row,col]=='Q') return false;
        }

        for(int row=i-1,col=j+1;row>=0&&col<N;row--,col++)
        {
            if(matrix[row,col]=='Q') return false;
        }
        return true;
    }
}