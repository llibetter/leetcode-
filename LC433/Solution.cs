using System.Collections.Generic;
public class Solution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        if (start == end) return 0;
        HashSet<string> hs = new HashSet<string>(bank);
        if (!hs.Contains(end)) return -1;

        hs.Add(start);
        List<string> l = new List<string>(bank);
        l.Add(start);
        Dictionary<string, HashSet<string>> dic = Generate(l.ToArray());

        Queue<string> q = new Queue<string>();
        q.Enqueue(end);
        int result = 0;
        while (q.Count != 0)
        {
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++)
            {
                string cur = q.Dequeue();
                if (cur == start)
                    return result;
                HashSet<string> tmp = dic[cur];
                foreach (var item in tmp)
                {
                    if (hs.Contains(item))
                    {
                        q.Enqueue(item);
                        hs.Remove(item);
                    }
                }
            }
            result++;
        }
        return -1;
    }

    public Dictionary<string, HashSet<string>> Generate(string[] bank)
    {
        Dictionary<string, HashSet<string>> dic = new Dictionary<string, HashSet<string>>();
        int len = bank.Length;
        for (int i = 0; i < len; i++)
        {
            if (dic.ContainsKey(bank[i]))
                continue;
            dic.Add(bank[i], new HashSet<string>());
            for (int j = 0; j < len; j++)
            {
                if (i == j) continue;
                if (valid(bank[i], bank[j]))
                {
                    dic[bank[i]].Add(bank[j]);
                }
            }
        }
        return dic;
    }

    public bool valid(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;
        int cnt = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
                cnt++;
        }
        return cnt == 1;
    }
}