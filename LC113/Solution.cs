using System.Collections.Generic;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> PathSum(TreeNode root, int sum)
    {
        BackTrack(root, sum, new List<int>());
        return result;
    }
    public void BackTrack(TreeNode root, int sum, IList<int> res)
    {
        if (root == null) return;
        res.Add(root.val);
        if (root.val == sum && root.left == null && root.right == null)
        {
            result.Add(new List<int>(res));
        }
        else
        {
            BackTrack(root.left, sum - root.val, res);
            BackTrack(root.right, sum - root.val, res);
        }
        res.RemoveAt(res.Count - 1);
    }
}