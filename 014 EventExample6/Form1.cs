﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _014_EventExample6 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e) {
            _textBox.Text = "Good Afternoon!";
        }
    }
}
