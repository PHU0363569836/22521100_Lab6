namespace _22521100_Lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_bai01 = new Button();
            btn_bai02 = new Button();
            btn_bai03 = new Button();
            SuspendLayout();
            // 
            // btn_bai01
            // 
            btn_bai01.Location = new Point(66, 108);
            btn_bai01.Name = "btn_bai01";
            btn_bai01.Size = new Size(101, 73);
            btn_bai01.TabIndex = 0;
            btn_bai01.Text = "Bài 01";
            btn_bai01.UseVisualStyleBackColor = true;
            btn_bai01.Click += btn_bai01_Click;
            // 
            // btn_bai02
            // 
            btn_bai02.Location = new Point(260, 108);
            btn_bai02.Name = "btn_bai02";
            btn_bai02.Size = new Size(101, 73);
            btn_bai02.TabIndex = 1;
            btn_bai02.Text = "Bài 02";
            btn_bai02.UseVisualStyleBackColor = true;
            btn_bai02.Click += btn_bai02_Click;
            // 
            // btn_bai03
            // 
            btn_bai03.Location = new Point(451, 108);
            btn_bai03.Name = "btn_bai03";
            btn_bai03.Size = new Size(101, 73);
            btn_bai03.TabIndex = 2;
            btn_bai03.Text = "Bài 03";
            btn_bai03.UseVisualStyleBackColor = true;
            btn_bai03.Click += btn_bai03_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 296);
            Controls.Add(btn_bai03);
            Controls.Add(btn_bai02);
            Controls.Add(btn_bai01);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_bai01;
        private Button btn_bai02;
        private Button btn_bai03;
    }
}
