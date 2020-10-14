using System;

namespace LC1002
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] A=new string[]{"bella","label","roller"};
            var res= new Solution().CommonChars(A);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
            Console.Read();
        }
    }
}
