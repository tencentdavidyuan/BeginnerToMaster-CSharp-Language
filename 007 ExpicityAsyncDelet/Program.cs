using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExpicityAsyncDelegate {
    class Program {
        static void Main(string[] args) {
            Method_B();

            Console.ReadKey();
        }

        static void Method_A() {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            // 显示启动分支线程，运行委托
            Thread workThreadA = new Thread(new ThreadStart(action1));
            Thread workThreadB = new Thread(new ThreadStart(action2));
            Thread workThreadC = new Thread(new ThreadStart(action3));

            workThreadA.Start();
            workThreadB.Start();
            workThreadC.Start();

            // 在异步运行时，action1，action2，action3对Console.ForegroundColor形成
            // 资源竞争。需要加锁解决问题。

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 10; ++i) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main Thread " + i);
                Thread.Sleep(1000);
            }
        }

        static void Method_B() {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            // 显示启动分支线程，运行委托
            Task taskA = new Task(new Action(stu1.DoHomework));
            Task taskB = new Task(new Action(stu2.DoHomework));
            Task taskC = new Task(new Action(stu3.DoHomework));

            taskA.Start();
            taskB.Start();
            taskC.Start();

            // 在异步运行时，action1，action2，action3对Console.ForegroundColor形成
            // 资源竞争。需要加锁解决问题。

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 10; ++i) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main Thread " + i);
                Thread.Sleep(1000);
            }
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
