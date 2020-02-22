using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiCastDelegate {
    class Program {
        static void Main(string[] args) {
            MultiCast();

            Console.ReadKey();
        }

        static void SingleCast() {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            // 单播
            action1.Invoke();
            action2.Invoke();
            action3.Invoke();
        }

        static void MultiCast() {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            // 多播（action1先合并action2 ，然后合并action3
            action1 += action2; 
            action1 += action3;


            action1.Invoke();
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
