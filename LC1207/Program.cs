using System;

namespace LC1207
{
    class Program
    {
        static void Main(string[] args)
        {
            bool res=new Solution().UniqueOccurrences(new int[]{1,2,2,1,1,3});
            Console.WriteLine(res);

            Console.Read();
        }
    }
}
