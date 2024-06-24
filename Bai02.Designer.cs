namespace _22521100_Lab6
{
    partial class Bai02
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_encrypt = new Button();
            btn_decrypt = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tb_key = new TextBox();
            tb_input = new TextBox();
            tb_encrypt = new TextBox();
            tb_decrypt = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btn_encrypt
            // 
            btn_encrypt.Location = new Point(601, 88);
            btn_encrypt.Name = "btn_encrypt";
            btn_encrypt.Size = new Size(121, 109);
            btn_encrypt.TabIndex = 0;
            btn_encrypt.Text = "Mã hoá";
            btn_encrypt.UseVisualStyleBackColor = true;
            btn_encrypt.Click += btn_encrypt_Click;
            // 
            // btn_decrypt
            // 
            btn_decrypt.Location = new Point(601, 307);
            btn_decrypt.Name = "btn_decrypt";
            btn_decrypt.Size = new Size(121, 115);
            btn_decrypt.TabIndex = 1;
            btn_decrypt.Text = "Giải mã";
            btn_decrypt.UseVisualStyleBackColor = true;
            btn_decrypt.Click += btn_decrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 91);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 2;
            label1.Text = "Nhập Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 177);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 3;
            label2.Text = "Input";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 307);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 4;
            label3.Text = "Encrypt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 439);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 5;
            label4.Text = "Decrypt";
            // 
            // tb_key
            // 
            tb_key.Location = new Point(132, 88);
            tb_key.Name = "tb_key";
            tb_key.Size = new Size(359, 23);
            tb_key.TabIndex = 6;
            // 
            // tb_input
            // 
            tb_input.Location = new Point(131, 174);
            tb_input.Multiline = true;
            tb_input.Name = "tb_input";
            tb_input.Size = new Size(360, 103);
            tb_input.TabIndex = 7;
            // 
            // tb_encrypt
            // 
            tb_encrypt.Location = new Point(131, 304);
            tb_encrypt.Multiline = true;
            tb_encrypt.Name = "tb_encrypt";
            tb_encrypt.Size = new Size(360, 100);
            tb_encrypt.TabIndex = 8;
            // 
            // tb_decrypt
            // 
            tb_decrypt.Location = new Point(131, 436);
            tb_decrypt.Multiline = true;
            tb_decrypt.Name = "tb_decrypt";
            tb_decrypt.Size = new Size(360, 97);
            tb_decrypt.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 21);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 10;
            label5.Text = "MÃ HOÁ  VIGENERE";
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(label5);
            Controls.Add(tb_decrypt);
            Controls.Add(tb_encrypt);
            Controls.Add(tb_input);
            Controls.Add(tb_key);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_decrypt);
            Controls.Add(btn_encrypt);
            Name = "Bai02";
            Text = "Bai02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_encrypt;
        private Button btn_decrypt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_key;
        private TextBox tb_input;
        private TextBox tb_encrypt;
        private TextBox tb_decrypt;
        private Label label5;
    }
}