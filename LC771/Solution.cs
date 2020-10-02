using System.Collections.Generic;

//时间与空间的抉择
//空间n，时间n
//空间1，时间n2
public class Solution {
    public int NumJewelsInStones(string J, string S) {
        int result=0;
        HashSet<char> hs=new HashSet<char>();
        foreach(var item in J)
            hs.Add(item);
        foreach(var item in S)
        {
            if(hs.Contains(item))
                result++;
        }
        return result;
    }
}