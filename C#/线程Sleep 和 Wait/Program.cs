using System;
using System.Threading;

class Program
{
    // 共享锁对象（就像一个厕所/微波炉）
    private static readonly object sharedLock = new object();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Sleep vs Wait 演示 ===\n");

        // 演示 Sleep
        Console.WriteLine("【演示 1：Sleep - 带着锁睡觉】");
        DemoThreadWithSleep();

        Thread.Sleep(1000);
        Console.WriteLine("\n====================================\n");

        // 演示 Wait
        Console.WriteLine("【演示 2：Wait - 释放锁等待通知】");
        DemoThreadWithWait();

        Console.ReadLine();
    }

    /// <summary>
    /// 演示 Sleep：线程A拿到锁后 Sleep，线程B被阻塞
    /// </summary>
    static void DemoThreadWithSleep()
    {
        Thread threadA = new Thread(SleepThread);
        Thread threadB = new Thread(BlockedBySleepThread);

        threadA.Name = "线程A(Sleep)";
        threadB.Name = "线程B(被阻塞)";

        threadA.Start();
        threadB.Start();

        // 等待两个线程结束
        threadA.Join();
        threadB.Join();
    }

    /// <summary>
    /// 线程A：拿到锁后 Sleep 3秒
    /// </summary>
    static void SleepThread()
    {
        lock (sharedLock)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ✅ 进入锁保护区");
            Console.WriteLine($"[{Thread.CurrentThread.Name}] 💤 开始 Sleep 3 秒（带着锁睡觉）...");
            Thread.Sleep(3000);  // 睡3秒，但不释放锁
            Console.WriteLine($"[{Thread.CurrentThread.Name}] 😃 Sleep 结束，准备释放锁");
        }
        Console.WriteLine($"[{Thread.CurrentThread.Name}] 🔓 已释放锁\n");
    }

    /// <summary>
    /// 线程B：尝试获取锁（会被阻塞）
    /// </summary>
    static void BlockedBySleepThread()
    {
        Thread.Sleep(100);  // 确保线程A先拿到锁

        Console.WriteLine($"[{Thread.CurrentThread.Name}] ⏳ 尝试获取锁...");
        lock (sharedLock)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ✅ 终于拿到锁了！（等了3秒）");
        }
    }

    /// <summary>
    /// 演示 Wait：线程A拿到锁后 Wait，主动释放锁，线程B可以执行
    /// </summary>
    static void DemoThreadWithWait()
    {
        Thread threadA = new Thread(WaitThread);
        Thread threadB = new Thread(NotifyThread);

        threadA.Name = "线程A(Wait)";
        threadB.Name = "线程B(通知者)";

        threadA.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();
    }

    /// <summary>
    /// 线程A：拿到锁后 Wait（释放锁并挂起）
    /// </summary>
    static void WaitThread()
    {
        lock (sharedLock)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ✅ 进入锁保护区");
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ⏸️ 调用 Monitor.Wait()，释放锁并挂起...");

            Monitor.Wait(sharedLock);  // 释放锁，自己挂起，等待通知

            Console.WriteLine($"[{Thread.CurrentThread.Name}] ⚡ 被唤醒了！重新获得锁，继续执行");
            Console.WriteLine($"[{Thread.CurrentThread.Name}] 😃 执行完毕");
        }
        Console.WriteLine($"[{Thread.CurrentThread.Name}] 🔓 释放锁\n");
    }

    /// <summary>
    /// 线程B：通知线程A继续执行
    /// </summary>
    static void NotifyThread()
    {
        Thread.Sleep(500);  // 让线程A先执行到 Wait

        Console.WriteLine($"[{Thread.CurrentThread.Name}] ⏳ 尝试获取锁...");
        lock (sharedLock)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ✅ 拿到了锁！（因为线程A释放了）");
            Console.WriteLine($"[{Thread.CurrentThread.Name}] 📢 调用 Monitor.Pulse() 通知等待的线程");

            Monitor.Pulse(sharedLock);  // 通知线程A：可以醒来了

            Console.WriteLine($"[{Thread.CurrentThread.Name}] 💤 睡1秒再释放锁（让线程A等着）");
            Thread.Sleep(1000);
            Console.WriteLine($"[{Thread.CurrentThread.Name}] 🔓 释放锁，线程A将重新获取");
        }
    }
}

