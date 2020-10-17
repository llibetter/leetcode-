using System;

namespace LC52
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt=new Solution().TotalNQueens(4);
            Console.WriteLine(cnt);

            Console.Read();
        }
    }
}
