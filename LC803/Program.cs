using System;
using System.Collections.Generic;
namespace LC803
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
            [[1,0,0,0],[1,1,1,0]]
            [[1,0]]
            */
            var input1 = new List<int[]>();
            input1.Add(new int[] { 1 });
            input1.Add(new int[] { 1 }); input1.Add(new int[] { 1 }); input1.Add(new int[] { 1 }); input1.Add(new int[] { 1 });


            var input2 = new List<int[]>();
            input2.Add(new int[] { 3, 0 });
            input2.Add(new int[] { 4, 0 });
            input2.Add(new int[] { 1, 0 });
            input2.Add(new int[] { 2, 0 });
            input2.Add(new int[] { 0, 0 });

            new Solution().HitBricks(input1.ToArray(), input2.ToArray());
        }
    }
}
