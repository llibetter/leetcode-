using System;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

//给你一棵所有节点为非负值的二叉搜索树，请你计算树中任意两节点的差的绝对值的最小值。

//根据BST的特性：中序遍历为递增序列，两节点差的最小值必定出现在中序遍历相邻两节点上
//问题转化为中序遍历，计算当前值与上一节点值，再把当前节点赋值为上一节点
//代码如下，空间复杂度O1 时间复杂度On
public class Solution
{
    int pre = int.MinValue;
    int result = int.MaxValue;
    public int GetMinimumDifference(TreeNode root)
    {
        InOrder(root);
        return result;
    }

    public void InOrder(TreeNode root)
    {
        if (root == null) return;
        InOrder(root.left);
        if (pre != int.MinValue)
        {
            result = Math.Min(result, root.val - pre);
        }
        pre = root.val;
        InOrder(root.right);
    }
}