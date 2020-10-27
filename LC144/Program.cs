using System.Collections.Generic;
using System;
namespace LC144
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(1);
            root.right=new TreeNode(2);
            root.right.left=new TreeNode(3);
            IList<int> res= new Solution().PreorderTraversal(root);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
