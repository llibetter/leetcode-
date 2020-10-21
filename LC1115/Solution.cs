using System.Threading;
using System;
namespace LC1115
{
    /*
    1115. 交替打印FooBar
    两个不同的线程将会共用一个 FooBar 实例。其中一个线程将会调用 foo() 方法，另一个线程将会调用 bar() 方法。

请设计修改程序，以确保 "foobar" 被输出 n 次。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/print-foobar-alternately
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */

    //使用两个Semaphore控制交替打印
    //Semaphore ['seməfɔː(r)]
    //Semaphore ['seməfɔː(r)]
    //Semaphore ['seməfɔː(r)]
    public class FooBar2
    {
        private int n;

        public FooBar2(int n)
        {
            this.n = n;
        }
        Semaphore f = new Semaphore(1, 1);
        Semaphore b = new Semaphore(0, 1);
        public void Foo()
        {

            for (int i = 0; i < n; i++)
            {
                f.WaitOne();
                // printFoo() outputs "foo". Do not change or remove this line.
                Console.WriteLine($"Foo{i}");
                b.Release();
            }
        }

        public void Bar()
        {

            for (int i = 0; i < n; i++)
            {
                b.WaitOne();
                // printBar() outputs "bar". Do not change or remove this line.
                Console.WriteLine($"Bar{i}");
                f.Release();
            }
        }
    }
    //使用一个共享变量，记录访问次数，配合Sleep控制交替
    public class FooBar
    {
        private int n;
        int k = 0;
        //private static readonly object obj=new object();
        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo()
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                while (k % 2 == 1)
                    Thread.Sleep(1);
                Console.WriteLine($"Foo{i}");
                k++;
            }
        }

        public void Bar()
        {

            for (int i = 0; i < n; i++)
            {

                // printBar() outputs "bar". Do not change or remove this line.
                while (k % 2 == 0)
                    Thread.Sleep(1);
                Console.WriteLine($"Bar{i}");
                k++;
            }
        }
    }
}