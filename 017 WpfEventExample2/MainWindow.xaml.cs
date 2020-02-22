using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _017_WpfEventExample2 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // 与System.Windows.Form不同的委托
            // wpf使用更新的路由事件委托作为事件处理器类型
            button.Click += new RoutedEventHandler(ButtonClick);

            button.Click += (sender, e) => {
                textBox.Text += "Button 2 Message!";
            };
        }

        private void ButtonClick(object sender, EventArgs e) {
            textBox.Text = "Button 1 Message!";
        }
    }
}
