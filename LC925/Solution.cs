public class Solution
{
    /*
    925. 长按键入
你的朋友正在使用键盘输入他的名字 name。偶尔，在键入字符 c 时，按键可能会被长按，而字符可能被输入 1 次或多次。

你将会检查键盘输入的字符 typed。如果它对应的可能是你的朋友的名字（其中一些字符可能被长按），那么就返回 True。
    */

    //递归
    public bool IsLongPressedName11(string name, string typed)
    {
        return IsValid(name, 0, typed, 0);
    }

    public bool IsValid(string name, int a, string typed, int b)
    {
        if (a == name.Length && b == typed.Length) return true;
        else if (a == name.Length || b == typed.Length) return false;
        if (name[a] != typed[b]) return false;
        int i = b;
        while (i < typed.Length && typed[i] == name[a])
        {
            if (IsValid(name, a + 1, typed, i + 1)) return true;
            i++;
        }
        return false;
    }
    //迭代
    public bool IsLongPressedName(string name, string typed)
    {

        int m = name.Length;
        int n = typed.Length;
        if (m > n) return false;
        int i = 0;
        int j = 0;
        while (j < n)
        {
            if (i < m && name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (j - 1 >= 0 && typed[j] == typed[j - 1])
            {
                j++;
            }
            else
                return false;
        }
        return i == m;
    }
}