using System.Collections.Generic;
public class Solution
{
    //利用双指针，空间复杂度1
    public bool BackspaceCompare11(string S, string T)
    {
        int p1 = S.Length - 1;
        int p2 = T.Length - 1;
        int cnt1 = 0;
        int cnt2 = 0;
        while (p1 >= 0 || p2 >= 0)
        {
            while (p1 >= 0)
            {
                if (S[p1] == '#')
                {
                    cnt1++;
                    p1--;
                }
                else if (cnt1 > 0)
                {
                    cnt1--;
                    p1--;
                }
                else
                    break;
            }

            while (p2 >= 0)
            {
                if (T[p2] == '#')
                {
                    cnt2++;
                    p2--;
                }
                else if (cnt2 > 0)
                {
                    cnt2--;
                    p2--;
                }
                else
                    break;
            }

            if (p1 >= 0 && p2 >= 0)
            {
                if (S[p1] == T[p2])
                {
                    p1--;
                    p2--;
                }
                else return false;
            }
            else if (p1 < 0 && p2 < 0) return true;
            else return false;
        }
        return true;
    }
    //利用栈，空间复杂度n
    public bool BackspaceCompare(string S, string T)
    {
        Stack<char> s1 = new Stack<char>();
        Stack<char> s2 = new Stack<char>();
        foreach (var item in S)
        {
            if (item == '#')
            {
                if (s1.Count > 0)
                    s1.Pop();
            }
            else
                s1.Push(item);
        }
        foreach (var item in T)
        {
            if (item == '#')
            {
                if (s2.Count > 0)
                    s2.Pop();
            }
            else
                s2.Push(item);
        }

        return string.Join("", s1) == string.Join("", s2);
    }
}