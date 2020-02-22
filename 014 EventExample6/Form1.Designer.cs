namespace _014_EventExample6 {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this._button = new System.Windows.Forms.Button();
            this._textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _button
            // 
            this._button.Location = new System.Drawing.Point(42, 63);
            this._button.Name = "_button";
            this._button.Size = new System.Drawing.Size(198, 23);
            this._button.TabIndex = 0;
            this._button.Text = "Say Hello";
            this._button.UseVisualStyleBackColor = true;
            this._button.Click += new System.EventHandler(this.ButtonClick);
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(13, 23);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(259, 21);
            this._textBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _button;
        private System.Windows.Forms.TextBox _textBox;
    }
}

