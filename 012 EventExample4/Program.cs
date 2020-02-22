using System;
using System.Windows.Forms;

namespace EventExample4 {
    class Program {
        static void Main(string[] args) {
            MyForm form = new MyForm();
            form.ShowDialog();

            Console.ReadKey();
        }
    }

    class MyForm : Form {
        private TextBox _textBox;
        // 1. 事件拥有者
        private Button _button;

        public MyForm() {
            _textBox = new TextBox();
            _button = new Button();
            _textBox.Top = 40;
            _textBox.Left = 20;
            _button.Top = 70;
            _button.Left = 20;
            _button.Text = "Button";

            Controls.Add(_textBox);
            Controls.Add(_button);

            // 2. 事件是Click
            // 3. 事件的响应者是this
            // 5. 事件的
            _button.Click += this.ButtonCliked;
        }

        /// <summary>
        /// 4. 事件处理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCliked(object sender, EventArgs e) {
            _textBox.Text = "Hello World";
        }
    }
}
