using System.Collections.Generic;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root == null) return result;
        TreeNode p = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(p);
        while (stack.Count != 0)
        {
            p = stack.Pop();
            result.Insert(0, p.val);
            
            if (p.left != null)
                stack.Push(p.left);
            if (p.right != null)
                stack.Push(p.right);
        }
        return result;
    }
}