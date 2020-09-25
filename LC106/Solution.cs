
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return helper(inorder,0,inorder.Length-1,postorder,0,postorder.Length-1);
    }

    public TreeNode helper(int[] inorder,int a,int b,int[] postorder,int c,int d)
    {
        if(a>b||c>d) return null;
        int i=a;
        while(inorder[i]!=postorder[d])
        {
            i++;
        }
        TreeNode root=new TreeNode(postorder[d]);
        root.left=helper(inorder,a,i-1,postorder,c,c-a+i-1);
        root.right=helper(inorder,i+1,b,postorder,c-a+i,d-1);
        return root;
    }
}