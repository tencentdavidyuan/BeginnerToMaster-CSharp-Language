using System;
using System.Windows.Forms;

namespace EventExample3 {
    /// <summary>
    /// 事件的拥有者和响应者是同一个对象
    /// </summary>
    class Program {
        static void Main(string[] args) {
            //Form form = new Form();
            //form.Click += form.CustomHandler;

            // 1. 事件的拥有者（form）
             
            MyForm form = new MyForm();
            // 2. 事件 （Click）
            // 3. 事件的响应者（form）和事件拥有者是同一个对象
            // 5. 事件的订阅
            form.Click += form.CustomHandler;

            form.ShowDialog();
        }
    }

    class MyForm : Form {
        // 4. 事件的处理器
        internal void CustomHandler(object sender, EventArgs e) {
            Text = DateTime.Now.ToString();
        }
    }
}

