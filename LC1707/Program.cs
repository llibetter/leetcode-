using System;

namespace LC1707
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b1=false;
            if(false)
            if(true)
            {
                Console.WriteLine(1111);

            }
            Console.WriteLine("Hello World!");
            new Solution().MaximizeXor(new int[]{0,1,2,3,4},new int[2][]{new int[]{1,3},new int[]{5,6}});
        }
    }
}


/*

[0,1,2,3,4]
[[3,1],[1,3],[5,6]]
*/
