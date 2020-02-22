using System;
using System.Windows.Forms;

namespace EventExample2 {
    /// <summary>
    /// 事件的五个部分
    /// 1. 拥有者
    /// 2. 事件
    /// 3. 响应者
    /// 4. 事件处理器
    /// 4. 事件订阅
    /// </summary>
    class Program {
        static void Main(string[] args) {
            // 1. 事件拥有者
            Form form = new Form();
            // 3. 事件响应者
            Controller ctrl = new Controller(form);
            form.ShowDialog();

            Console.ReadKey();
        }
    }

    class Controller {
        private Form _form;

        public Controller(Form form) {
            if (form == null)
                return;
            _form = form;
             // 2. 事件（Click）
             // 5. 事件订阅
            _form.Click += this.FormClickHandle;
        }

        /// <summary>
        /// 4.事件处理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">事件约定</param>
        private void FormClickHandle(object sender, EventArgs e) {
            _form.Text = DateTime.Now.ToString();
        }
    }
}
