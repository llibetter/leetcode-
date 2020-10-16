using System;

namespace LC977
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] res=new Solution().SortedSquares(new int[]{-7,-3,2,3,11});
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
