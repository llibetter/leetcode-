using System;
using System.Collections.Generic;
namespace LC763
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> res=new Solution().PartitionLabels("ababcbacadefegdehijhklij");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------------------------");
            IList<int> res1=new Solution().PartitionLabels111("ababcbacadefegdehijhklij");
            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
