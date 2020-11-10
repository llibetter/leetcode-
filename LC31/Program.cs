using System;

namespace LC31
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input=new int[]{1,4,3,7,6,1};

            new Solution().NextPermutation(input);

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
