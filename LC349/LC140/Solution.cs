using System.Collections.Generic;
/*
140. 单词拆分 II
给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。

说明：

分隔时可以重复使用字典中的单词。
你可以假设字典中没有重复的单词。
示例 1：

输入:
s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
输出:
[
  "cats and dog",
  "cat sand dog"
]
*/
//记忆化回溯
public class Solution
{
    Dictionary<string, IList<string>> dic;
    HashSet<string> hs;
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        dic = new Dictionary<string, IList<string>>();
        hs = new HashSet<string>(wordDict);
        DFS(s);
        return dic[s];
    }

    public IList<string> DFS(string s)
    {
        if (dic.ContainsKey(s)) return dic[s];
        if (string.IsNullOrEmpty(s)) return null;
        IList<string> oneres = new List<string>();
        foreach (var item in hs)
        {
            if (s.Length<item.Length|| s.Substring(0, item.Length) != item) continue;
            IList<string> tmp = DFS(s.Substring(item.Length));
            if (tmp == null)
            {
                oneres.Add(item);
            }
            else
            {
                foreach (var item1 in tmp)
                {
                    oneres.Add(item + " " + item1);
                }
            }
        }
        dic.Add(s, oneres);
        return oneres;
    }
}