using System.Collections.Generic;
/*
144. 二叉树的前序遍历
给定一个二叉树，返回它的 前序 遍历。

 示例:

输入: [1,null,2,3]  
   1
    \
     2
    /
   3 

输出: [1,2,3]
*/

//常规题目，用栈遍历即可

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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root == null) return result;
        Stack<TreeNode> s = new Stack<TreeNode>();
        s.Push(root);
        while (s.Count != 0)
        {
            TreeNode cur = s.Pop();
            result.Add(cur.val);
            if (cur.right != null)
                s.Push(cur.right);
            if (cur.left != null)
                s.Push(cur.left);
        }
        return result;
    }
}