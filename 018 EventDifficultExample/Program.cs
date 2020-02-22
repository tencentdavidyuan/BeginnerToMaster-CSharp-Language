using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDifficultExample {
    class Program {
        static void Main(string[] args) {
            Customer customer = new Customer();

            Waiter waiter = new Waiter();
            customer.Order += waiter.ServeDish;



        }


    }
    /// <summary>
    /// 点菜委托类型
    /// 用于定义事件处理器的约束，只有满足定义的处理器才是合法处理器
    /// </summary>
    /// <param name="customer"></param>
    /// <param name="e"></param>
    public delegate void OrderEventHandle(Customer customer, OrderEventArgs e);

    /// <summary>
    /// 1. 事件类型参数定义由: 实际有意义的名称 + EventArgs 组成。
    /// 2. 需要继承C#给定的事件参数基类：EventArgs
    /// </summary>
    public class OrderEventArgs : EventArgs {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
        

    public class Customer {
        // 处理事件的约束条件
        private OrderEventHandle _orderEventHandler;

        /// <summary>
        /// 声明事件
        /// 1. 访问级别
        /// 2. event 关键字
        /// 3. 事件处理约束
        /// 4. 事件名称
        /// 5. 添加事件处理器的方法
        /// 6. 移除事件处理器的方法
        /// </summary>
        public event OrderEventHandle Order {
            add {
                _orderEventHandler += value;
            }

            remove {
                _orderEventHandler -= value;
            }
        }
        
        public double Bill { get; set; }

        public void PayTheBill() {
            Console.WriteLine("I will pay ${0}", Bill);
        }

        public void WalkIn() {
            Console.WriteLine("Walk into the restaurant.");
        }

        public void SitDown() {
            Console.WriteLine("Sit down.");
        }

        public void Think() {
            for (int i = 0; i < 5; ++i) {
                Console.WriteLine("Let me think.");
                Thread.Sleep(1000);
            }

            if (_orderEventHandler != null) {

            }
            
        }
    }

    public class Waiter {
        internal void ServeDish(Customer customer, OrderEventArgs e) {
            Console.WriteLine("I Will serve you the dish {0}", e.DishName);

            double price = 10;
            switch (e.Size) {
                case "small":
                    price = price * 0.5;
                    break;

                case "large":
                    price = price * 1.5;
                    break;
            }

            customer.Bill += price;
        }
    }

}
