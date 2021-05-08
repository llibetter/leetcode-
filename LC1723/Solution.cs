using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    /*
输入：
[5,5,4,4,4]
2
输出：
13
预期结果：
12


[12,13,14,17,25]
3
无法按照由大到小的策略，依次排，得不到最小值
    */
    public int MinimumTimeRequired33(int[] jobs, int k) {
        //错误思路
        int len=jobs.Length;
        Array.Sort(jobs);
        if(k>=len) return jobs[len-1];
        List<int> l=new List<int>();
        for(int i=len-1;i>=0;i--)
        {
            if(i>=len-k)
            {
                l.Add(jobs[i]);
            }
            else
            {
                int sum=l[k-1]+jobs[i];
                l.RemoveAt(k-1);
                BinaryInsert(l,sum);
            }
        } 
        return l[0];
    }

    public void BinaryInsert(List<int> l,int val)
    {
        int left=0;
        int right=l.Count;
        while(left<right)
        {
            int mid=left+(right-left)/2;
            if(l[mid]<=val)
                right=mid;
            else
                left=mid+1;
        }
        l.Insert(left,val);
    }




    public int MinimumTimeRequired66(int[] jobs, int k) {
        //错误思路
        if(jobs==null||jobs.Length==0) return 0;
        int len=jobs.Length;
        Array.Sort(jobs);
        int min=jobs[len-1];
        int max=jobs.Sum();
        while(min<max)
        {
            int mid=min+(max-min)/2;
            if(IsValid(jobs,k,mid))
                max=mid;
            else
                min=mid+1;
        }
        return max;
    }

    public bool IsValid(int[] jobs,int k,int val)
    {
        int len=jobs.Length;
        int res=1;
        int cur=0;
        bool[] used=new bool[len];
        for(int i=len-1;i>=0;i--)
        {
            if(used[i]) continue;
            if(cur+jobs[i]<=val)
            {
                cur+=jobs[i];
                for(int j=i-1;j>=0;j--)
                {
                    if(used[j]) continue;
                    if(cur+jobs[j]>val) continue;
                    used[j]=true;
                    cur+=jobs[j];
                }
            }
            else
            {
                res++;
                cur=jobs[i];
            }
        }
        return res<=k;
    }



     public int MinimumTimeRequired(int[] jobs, int k) {
        if(jobs==null||jobs.Length==0) return 0;
        int len=jobs.Length;
        Array.Sort(jobs);
        int left=jobs[len-1];
        int right=jobs.Sum();
        while(left<right)
        {
            int mid=left+(right-left)/2;
            int[] workload=new int[k];
            if(IsValid(jobs,0,workload,mid))
                right=mid;
            else
                left=mid+1;
        }
        return right;
    }

    public bool IsValid(int[] jobs,int index,int[] workload,int limit)
    {
        if(index==jobs.Length) return true;
        int cur=jobs[index];
        for(int i=0;i<workload.Length;i++)
        {
            if(workload[i]+cur>limit) continue;
            workload[i]+=cur;
            if(IsValid(jobs,index+1,workload,limit))
                return true;
            workload[i]-=cur;
        }
        return false;
    }

      
}