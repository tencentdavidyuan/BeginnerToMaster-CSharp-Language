using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _015_EventExample7 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // button1 和 button2可以绑定同一个事件处理器
            // 是因为他们有相同的约束。

            // 通过New一个委托来定义Click事件
            // 这个委托就是事件处理的约定
            button3.Click += new EventHandler(ButtonClick);

            // 目前比较流行的方法是λ表达式
            button4.Click += (object sender, EventArgs e) => {
                textBox1.Text = "Button 4 Sender Message!";
            };

            // 编译器可以自动推断参数的类型，所以可以省略掉参数的类型
            button5.Click += (sender, e) => {
                textBox1.Text = "Button 5 Sender Message!";
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">事件拥有者（该事件拥有多个事件拥有者）</param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, EventArgs e) {
            
            if (sender == button1) {
                textBox1.Text = "Button 1 Sender Message!";
            }

            if (sender == button2) {
                textBox1.Text = "Button 2 Sender Message!";
            }

            if (sender == button3) {
                textBox1.Text = "Button 3 Sender Message!";
            }
        }
    }
}
