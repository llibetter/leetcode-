using System;

namespace LC617
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public TreeNode MergeTrees666(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return null;
            TreeNode root;
            int value = 0;
            if (t1 != null) value += t1.val;
            if (t2 != null) value += t2.val;
            root = new TreeNode(value);
            root.left = MergeTrees(t1?.left, t2?.left);
            root.right = MergeTrees(t1?.right, t2?.right);
            return root;
        }
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            t1.val += t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }
    }
}
