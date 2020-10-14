using System.Collections.Generic;
using System;
public class Solution {
    /*
    给定仅有小写字母组成的字符串数组 A，返回列表中的每个字符串中都显示的全部字符（包括重复字符）组成的列表。
    例如，如果一个字符在每个字符串中出现 3 次，但不是 4 次，则需要在最终答案中包含该字符 3 次。

你可以按任意顺序返回答案。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/find-common-characters
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */

    //此题属于简单题，不涉及常规算法，先统计字符组成，再取各个字符最小值，即可
    //统计字符组成时，用数组或哈希表均可，一般来说选择更简单的数组
    
    public IList<string> CommonChars(string[] A) {
        if(A==null||A.Length==0) return null;
        int len=A.Length;
        int[,] arr=new int[len,26];
        for(int i=0;i<len;i++)
        {
            foreach(var item in A[i])
            {
                arr[i,item-'a']++;
            }
        }
        IList<string> result=new List<string>();
        for(int i=0;i<26;i++)
        {
            int cnt=int.MaxValue;
            for(int j=0;j<len;j++)
            {
                cnt=Math.Min(cnt,arr[j,i]);
            }
            while(cnt>0)
            {
                result.Add(((char)(i+'a')).ToString());
                cnt--;
            }
        }
        return result;
    }
}