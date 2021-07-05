using System.Collections.Generic;
using System.Text;
public class Solution
{
    public string CountOfAtoms(string formula)
    {
        if (formula == null || formula.Length == 0) return formula;
        Stack<Dictionary<string, int>> s = new Stack<Dictionary<string, int>>();
        s.Push(new Dictionary<string, int>());
        int len = formula.Length;
        for (int i = 0; i < len; i++)
        {
            if (formula[i] == '(')
            {
                s.Push(new Dictionary<string, int>());
            }
            else if (formula[i] == ')')
            {
                i++;
                int num = parseNum(formula, ref i);
                i--;
                var tmp = s.Pop();
                var cur = s.Peek();
                foreach (var item in tmp)
                {
                    if (cur.ContainsKey(item.Key))
                        cur[item.Key] += tmp[item.Key] * num;
                    else
                        cur.Add(item.Key, tmp[item.Key] * num);
                }
            }
            else
            {
                string str = parseLetter(formula, ref i);
                int cnt = parseNum(formula, ref i);
                i--;
                var cur = s.Peek();
                if (cur.ContainsKey(str))
                    cur[str] += cnt;
                else
                    cur.Add(str, cnt);
            }
        }
        var list = new List<(string, int)>();
        foreach (var item in s.Peek())
        {
            list.Add((item.Key, item.Value));
        }
        list.Sort((x, y) =>
        {
            return x.Item1.CompareTo(y.Item1);
        });
        StringBuilder result = new StringBuilder();
        foreach (var item in list)
        {
            if (item.Item2 == 1)
                result.Append($"{item.Item1}");
            else
                result.Append($"{item.Item1}{item.Item2}");
        }
        return result.ToString();
    }

    private string parseLetter(string formula, ref int cur)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(formula[cur++]);
        int len = formula.Length;
        while (cur < len && char.IsLetter(formula[cur]) && formula[cur]>=97)
        {
            sb.Append(formula[cur++]);
        }
        return sb.ToString();
    }

    private int parseNum(string formula, ref int cur)
    {
        StringBuilder sb = new StringBuilder();
        int len = formula.Length;
        while (cur < len && char.IsDigit(formula[cur]))
        {
            sb.Append(formula[cur++]);
        }
        var str = sb.ToString();
        return string.IsNullOrEmpty(str) ? 1 : int.Parse(str);
    }
}