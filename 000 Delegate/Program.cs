using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample {
    class Program {
        static void Main(string[] args) {
            Calulator calu = new Calulator();

            Action action = new Action(calu.Report);

            // 直接调用
            calu.Report();
            // 间接调用(两种方式)
            action.Invoke();
            action();

            Console.WriteLine("Calulator Add 方法的调用：");
            Console.WriteLine(calu.Add(100, 50));
            Func<int, int, int> addFunc = new Func<int, int, int>(calu.Add);
            Console.WriteLine(addFunc.Invoke(100, 50));
            Console.WriteLine(addFunc(100, 50));


            Console.WriteLine("Calulator Sub 方法的调用：");
            Console.WriteLine(calu.Sub(100, 50));
            Func<int, int, int> subFunc = new Func<int, int, int>(calu.Sub);
            Console.WriteLine(subFunc.Invoke(100, 50));
            Console.WriteLine(subFunc(100, 50));

            Console.ReadKey();
        }
    }

    class Calulator {
        public void Report() {
            Console.WriteLine("I have 3 methods");
        }

        public int Add(int a, int b) {
            return a + b;
        }
        public int Sub(int a, int b) {
            return a - b;
        }
    }
}
