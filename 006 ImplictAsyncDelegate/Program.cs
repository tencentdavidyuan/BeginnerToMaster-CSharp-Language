using System;
using System.Threading;


namespace ImplictAsyncDelegate {
    class Program {
        static void Main(string[] args) {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            // Action.BeginInvoke会启动分支线程，运行委托
            action1.BeginInvoke(null, null);
            action2.BeginInvoke(null, null);
            action3.BeginInvoke(null, null);
            // 在异步运行时，action1，action2，action3对Console.ForegroundColor形成
            // 资源竞争。需要加锁解决问题。

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 10; ++i) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main Thread " + i);
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }

    class Student {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework() {
            
            for (int i = 0; i < 5; ++i) {
                Console.ForegroundColor = PenColor;
                Console.WriteLine("Student {0} doing homework {1} hour(s).", ID, i);
                Thread.Sleep(1000);
            }
        }
    }
}
