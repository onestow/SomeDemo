using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeDemo
{
    class ThreadTest
    {
        public void Run()
        {
            Thread.Sleep(20 * 1000);
            int len = 10000;
            var tasks = new Thread[len];
            int cnt = 0;
            for (int i = 0; i < len; i++)
            {
                var t = new Thread(() =>
                {
                    var index = Interlocked.Increment(ref cnt);
                    Console.WriteLine("----" + index);
                    Thread.Sleep(10 * 60 * 60 * 1000);
                });
                t.Start();
                tasks[i] = t;
            }
            Console.WriteLine("processing...");
            foreach (var t in tasks)
                t.Join();
            Console.WriteLine("done");
            Console.ReadKey(true);
        }
    }
}
