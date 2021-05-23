using System.Collections.Generic;
using System;
public class Solution
{
    public int[] MaximizeXor(int[] nums, int[][] queries)
    {
        Trie root = new Trie();
        foreach (var item in nums)
        {
            root.Insert(item);
        }
     
        int len = queries.Length;
        int[] result = new int[len];
        for (int i = 0; i < len; i++)
        {
            result[i] = root.Find(queries[i][0], queries[i][1]);
        }
        return result;
    }
}

public class Trie
{
    public Trie[] children;
    public int minValue;
    public Trie()
    {
        children = new Trie[2];
        minValue=int.MaxValue;
    }

    public void Insert(int val)
    {
        Trie p = this;
        for (int i = 30; i >= 0; i--)
        {
            int index = (val >> i) & 1;
            if (p.children[index] == null)
            {
                p.children[index] = new Trie();
            }
            p = p.children[index];
            p.minValue=Math.Min(p.minValue,val);
      
        }
    }

  

    public int Find(int a, int b)
    {
        Trie p = this;
        int result = 0;
        for (int i = 30; i >= 0; i--)
        {
            int index = (a >> i) & 1;
            if (index == 0)
            {
                bool flag = false;
                bool flag2 = false;

                if (p.children[1] != null && p.children[1].minValue <= b)
                {
                    flag = true;
                    result += (1 << i);
                    p = p.children[1];
                }

                if (!flag)
                {

                    if (p.children[0] != null && p.children[0].minValue <= b)
                    {
                        flag2 = true;
                        p = p.children[0];
                    }
                }
                if (!flag && !flag2) return -1;
            }
            else
            {
                bool flag = false;
                bool flag2 = false;


                if (p.children[0] != null && p.children[0].minValue <= b)
                {
                    flag = true;
                    result += (1 << i);
                    p = p.children[0];
                }

                if (!flag)
                {
                    if (p.children[1] != null && p.children[1].minValue <= b)
                    {
                        flag2 = true;
                        p = p.children[1];

                    }
                }
                if (!flag && !flag2) return -1;
            }
        }
        return result;
    }
}