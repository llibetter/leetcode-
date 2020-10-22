using System.Collections.Generic;
using System;
public class Solution {
    /*
    763. 划分字母区间
字符串 S 由小写字母组成。我们要把这个字符串划分为尽可能多的片段，同一个字母只会出现在其中的一个片段。返回一个表示每个字符串片段的长度的列表。
    */

    //这题和合并区间很像，写到这里，有一种他乡遇故知的感觉
    public IList<int> PartitionLabels111(string S) {
        if(S==null||S.Length==0) return null;
        int[][] arr=new int[26][];
        for (int i = 0; i <26; i++)
        {
            char c=(char)(i+'a');
            int start=-1;
            int end=-1;
            for (int j = 0; j < S.Length; j++)
            {
                if(S[j]==c)
                {
                    if(start==-1)
                    {
                        start=j;
                        end=j;
                    }
                    else
                        end=j;
                }
            }
            arr[i]=new int[]{i,start,end};
        }
        Array.Sort(arr,(a,b)=>{return a[1]-b[1];});
        IList<int> result=new List<int>();
        for(int i=0;i<26;i++)
        {
            int s=arr[i][1];
            int e=arr[i][2];
            if(s==-1) continue;
            while(i+1<26&&arr[i+1][1]<e)
            {
                e=Math.Max(e,arr[i+1][2]);
                i++;
            }
            result.Add(e-s+1);
        }
        return result;
    }

    public IList<int> PartitionLabels(string S){
        int[] end=new int[26];
        for(int i=0;i<S.Length;i++)
        {
            end[S[i]-'a']=i;
        }
        IList<int> result=new List<int>();
        for(int i=0;i<S.Length;i++)
        {
            int s=i;
            int e=end[S[i]-'a'];
            for(int j=s+1;j<e;j++)
            {
                e=Math.Max(e,end[S[j]-'a']);
            }
            result.Add(e-s+1);
            i=e;
        }
        return result;
    }
}