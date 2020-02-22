using System;
using System.Timers;

namespace EventBeginer {
    class Program {
        static void Main(string[] args) {
            // 事件的拥有者（事件的主体）
            // 事件的图标是一个小闪电

            // 属性：表示当前类或者对象处于什么状态
            // 方法：表示能做什么样的事情
            // 事件：表示在什么条件下通知他人
            Timer timer = new Timer();
            timer.Interval = 1000;

            Boy boy = new Boy();
            Girl girl = new Girl();

            // 事件订阅 。
            // 事件订阅的操作符号（+=)。
            // 事件订阅符号左边是事件主体（timer）和事件(Elapsed)，
            // 右边是事件订阅者（boy）和事件处理器（）。
            timer.Elapsed += boy.ElapsedHandler;
            timer.Elapsed += girl.ElapsedHandler;

            timer.Start();

            Console.ReadKey();
        }
    }

    class Boy {
        internal void ElapsedHandler(object sender, ElapsedEventArgs e) {
            Console.WriteLine("Body Jump!");
        }
    }

    class Girl {
        internal void ElapsedHandler(object sender, ElapsedEventArgs e) {
            Console.WriteLine("Girl Jump!");
        }
    }
}
