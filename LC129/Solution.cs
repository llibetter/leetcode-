public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
public class Solution {
    int result=0;
    public int SumNumbers(TreeNode root) {
        if(root==null) return 0;
        helper(root,0);
        return result;
    }

    public void helper(TreeNode root,int num)
    {
        num=num*10+root.val;
        if(root.left==root.right)
        {
            result+=num;
            return;
        }
        if(root.left!=null)
            helper(root.left,num);
        if(root.right!=null)
            helper(root.right,num);
    }
}