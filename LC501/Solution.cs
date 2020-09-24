
using System.Collections.Generic;
public class TreeNode
{
    public int val;//
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    List<int> result = new List<int>();
    int maxTime = 0;
    int curTime = 0;
    TreeNode pre = null;
    public int[] FindMode(TreeNode root)
    {
        InOrder(root);
        return result.ToArray();
    }

    public void InOrder(TreeNode root)
    {
        if (root == null) return;
        InOrder(root.left);
        if (pre == null || pre.val == root.val)
            curTime++;
        else
            curTime = 1;

        if (curTime == maxTime)
        {
            result.Add(root.val);
        }
        else if (curTime > maxTime)
        {
            result.Clear();
            result.Add(root.val);
            maxTime = curTime;
        }
        pre = root;
        InOrder(root.right);
    }
}