using System;

namespace LC57
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[5][];
            input[0] = new int[] { 1, 2 };
            input[1] = new int[] { 3, 5 };
            input[2] = new int[] { 6, 7 };
            input[3] = new int[] { 8, 10 };
            input[4] = new int[] { 12, 16 };

            int[] input2 = new int[] { 4, 8 };

            int[][] result=new Solution().Insert(input,input2);
            foreach(var item in result)
            {
                Console.WriteLine($"[{item[0]},{item[1]}]");
            }
            Console.Read();
        }
    }
}
