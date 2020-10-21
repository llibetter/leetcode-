using System;
using System.Threading.Tasks;
namespace LC1115
{
    class Program
    {
        static void Main(string[] args)
        {
            FooBar fooBar=new FooBar(10);
            var t1=Task.Run(()=>{fooBar.Foo();});
            var t2=Task.Run(()=>{fooBar.Bar();});
            t1.Wait();
            t2.Wait();
            Console.WriteLine("------------------------------------------------");
            FooBar2 fooBar2=new FooBar2(10);
            Task.Run(()=>{fooBar2.Foo();});
            Task.Run(()=>{fooBar2.Bar();});

            Console.Read();
        }
    }
}
