using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample {
    // 定义委托
    // 委托是一种类
    // 委托与所封装的方法必须“类型兼容"
    delegate double Calc(double a, double b);
     
    class Program {
        static void Main(string[] args) {
            Type t = typeof(Action);
            Console.WriteLine("Action type : " + t);

            Calculate calculate = new Calculate();

            Calc calc1 = new Calc(calculate.Add);
            Calc calc2 = new Calc(calculate.Sub);
            Calc calc3 = new Calc(calculate.Mul);
            Calc calc4 = new Calc(calculate.Div);


            double x = 100;
            double y = 200;

            Console.WriteLine("calc1 invoke(Add) " + calc1.Invoke(x, y));
            Console.WriteLine("calc1 invoke(Add) " + calc1(x, y));

            Console.WriteLine("calc2 invoke(Sub) " + calc2.Invoke(x, y));
            Console.WriteLine("calc2 invoke(Sub) " + calc2(x, y));

            Console.WriteLine("calc3 invoke(Add) " + calc3.Invoke(x, y));
            Console.WriteLine("calc3 invoke(Add) " + calc3(x, y));

            Console.WriteLine("calc4 invoke(Add) " + calc4.Invoke(x, y));
            Console.WriteLine("calc4 invoke(Add) " + calc4(x, y));

            Console.ReadKey();
        }
    }

    public class Calculate {
        public double Add(double a, double b) {
            return a + b;
        }

        public double Sub(double a, double b) {
            return a - b;
        }

        public double Mul(double a, double b) {
            return a * b;
        }

        public double Div(double a, double b) {
            return a / b;
        }
    }
}
