#define CODE1

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeDemo
{
    public class AsyncDemo
    {
        public void Run()
        {
            MutexTest();
        }

        /// <summary>
        /// 线程间同步, 可以暂时释放锁
        /// TryEnter、Enter用于获取锁
        /// Exit用于释放锁
        /// Wait用于暂时释放锁，让其他线程获取锁
        /// Pulse用于唤醒处于wait状态的线程
        /// lock(obj) {...} 等效于 try { Monitor.Enter(obj, ref token); ...} finally { if (token) Monitor.Exit(obj); }
        /// </summary>
        private void MonitorTest()
        {
            var lck = new object();
            var token = false;
            var t1 = Task.Run(() =>
            {
                Output("1 start");
                Monitor.TryEnter(lck, 500, ref token);
                if (token)
                {
                    Output("1 Enter");
                    Thread.Sleep(3000);
                    Monitor.Wait(lck);
                    Output("1 wait end");
                    Monitor.Exit(lck);
                }
                else
                    Output("1 Pass");
                Output("1 end");
            });

            Thread.Sleep(100);//为了让t1先获取锁
            Output("2 start");
            lock (lck)
            {
                Output("Enter 2");
                Thread.Sleep(3000);
                Monitor.Pulse(lck);
                Output("2 pulse end");
                Thread.Sleep(3000);
            }
            Output("2 end");
            Task.WaitAll(t1);
        }

        /// <summary>
        /// 为多个线程共享的变量提供原子操作
        /// 为变更的加、减等操作提醒原子操作
        /// </summary>
        private void InterLockedTest()
        {
#if CODE1
            //计数demo
            int cnt = 0;
            var tt1 = new Task(() =>
            {
                for (int i = 0; i < 10000000; i++)
                    //lock(this)
                    {
                    Interlocked.Increment(ref cnt);
                        //cnt += 1;
                    }
            });
            var tt2 = new Task(() =>
            {
                for (int i = 0; i < 10000000; i++)
                    //lock(this)
                    {
                    Interlocked.Increment(ref cnt);
                        //cnt += 1;
                    }
            });
            var ms = GetRunTime(() =>
            {
                tt1.Start();
                tt2.Start();
                Task.WaitAll(tt1, tt2);
            });
            Console.WriteLine(ms + " " + cnt);
#else
            //用interlock保证只运行一次
            int flag = 0;
            var tasksWithoutInterLocked = Enumerable.Range(0, 1000000).Select(_i => new Task(() =>
            {
                if (flag != 0)
                    return;
                Thread.Sleep(1);//模拟时间差
                    flag = 1;
                Console.WriteLine("maybe one");
            })).ToArray();
            foreach (var t in tasksWithoutInterLocked)
                t.Start();
            Task.WaitAll(tasksWithoutInterLocked);
            Console.WriteLine("无InterLocked任务运行结束");

            flag = 0;
            var tasksWithInterLocked = Enumerable.Range(0, 1000000).Select(_i => new Task(() =>
            {
                if (0 == Interlocked.Exchange(ref flag, 1))
                    Console.WriteLine("only one");
            })).ToArray();
            foreach (var t in tasksWithInterLocked)
                t.Start();
            Task.WaitAll(tasksWithInterLocked);
            Console.WriteLine("InterLocked任务运行结束");
#endif
        }

        /// <summary>
        /// 用于在两个线程之间进行信号发送, 保证不同线程间的执行顺序
        /// 构造函数的 initialState 可以理解为门的状态，true表示门是开着的，false表示门的关闭的
        /// 调用waitone的时候如果门是打开状态就直接进门然后自动关门, 如果门是关闭状态则等门开后进入
        /// 调用Set表示开门, 然后第一个调用waitone的线程进入
        /// 调用Reset表示关门
        /// </summary>
        private void AutoResetEventTest()
        {
            var are = new AutoResetEvent(true);
            int loopTimes = 100;
            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < loopTimes; i++)
                {
                    are?.WaitOne();
                    Output("1: " + i);
                    Thread.Sleep(1);
                    are?.Set();
                }
            });

            for (int i = 0; i < loopTimes; i++)
            {
                are?.WaitOne();
                Output("----2: " + i);
                Thread.Sleep(1);
                are?.Set();
            }
            Task.WaitAll(t1);
        }

        /// <summary>
        /// ManualResetEvent 基本与 AutoResetEvent 一致
        /// 区别在于 AutoResetEvent 在WaitOne 后自动调用 Reset, ManualResetEvent 需要手动调用Reset对WaitOne进行阻塞
        /// </summary>
        private void ManualResetEventTest()
        { }

        private void MethodImplAttributeTest()
        {
            var tasks = Enumerable.Range(0, 5).Select(_i => new Task(FuncWithMethidImpl)).ToArray();
            foreach (var t in tasks)
                t.Start();
            Task.WaitAll(tasks);
        }

        /// <summary>
        /// 整个方法上锁
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void FuncWithMethidImpl()
        {
            Output("");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 读写锁
        /// 使用ReaderWriterLock进行资源访问时,如果在某一时刻资源并没有获取写的独占权,那么可以获得多个读的访问权,单个写入的独占权,如果某一时 刻已经获取了写入的独占权,那么其它读取的访问权必须进行等待
        /// AcquireReaderLock / ReleaseReaderLock 用于申请/释放读锁
        /// AcquireWriterLock / ReleaseWriterLock 用于申请/释放写锁
        /// </summary>
        private void ReaderWriterLockTest()
        {
            var lck = new ReaderWriterLock();

            var funcRead = new Action(() =>
            {
                lck.AcquireReaderLock(int.MaxValue);
                Output("read lock get");
                Thread.Sleep(2000);
                Output("read lock release");
                lck.ReleaseReaderLock();
            });

            var funcWrite = new Action(() =>
            {
                Thread.Sleep(5);//为了让读锁先获取
                lck.AcquireWriterLock(int.MaxValue);
                Output("write lock get");
                Thread.Sleep(2000);
                Output("write lock release");
                lck.ReleaseWriterLock();
            });

            var tr1 = new Task(funcRead);
            var tr2 = new Task(funcRead);
            var tr3 = new Task(funcRead);
            var tw1 = new Task(funcWrite);
            var tw2 = new Task(funcWrite);

            //先申请两个读锁再申请两个写锁再申请一个读锁
            tr1.Start();
            tr2.Start();
            tw1.Start();
            tw2.Start();
            Thread.Sleep(100);
            tr3.Start();

            Task.WaitAll(tr1, tr2, tr3, tw1, tw2);
        }

        /// <summary>
        /// 互斥锁，可用于进程间同步
        /// 构造函数的 name 在操作系统中唯一
        /// WaitOne加锁
        /// ReleaseMutex解锁
        /// WaitOne的执行次数和ReleaseMutex一定要一致
        /// </summary>
        private void MutexTest()
        {
            using (var mutex = new Mutex(true, "whosyourdaddy", out bool isNew))
            {
                if (isNew)
                    Console.WriteLine("启动成功, 任意键退出");
                else
                {
                    Console.WriteLine("启动失败, 等待其他程序退出");
                    mutex.WaitOne();
                    Console.WriteLine("启动成功, 任意键退出");
                }
                Console.ReadKey();
                mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// 信号量, 用来控制同时访问某个特定资源的操作数量,可用于进程间同步
        /// WaitOne、Release
        /// </summary>
        private void SemaphoreTest()
        {
            using (Semaphore sem = new Semaphore(3, 3, "greedisgood"))
            {
                Console.WriteLine("start");
                sem.WaitOne();
                Console.WriteLine("enter");
                Console.ReadKey();
                sem.Release();
                Console.WriteLine("exit");
            }
        }

        private void Output(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString("mm:ss.fff") + ": " + msg);
        }

        private long GetRunTime(Action action)
        {
            var watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
