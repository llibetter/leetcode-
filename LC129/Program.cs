using System;

namespace LC129
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(4);
            root.left=new TreeNode(9);
            root.right=new TreeNode(0);
            root.left.left=new TreeNode(5);
            root.left.right=new TreeNode(1);

            int res=new Solution().SumNumbers(root);
            Console.WriteLine(res);

            Console.Read();
        }
    }
}
