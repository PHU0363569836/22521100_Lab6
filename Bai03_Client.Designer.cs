namespace _22521100_Lab6
{
    partial class Bai03_Client
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
            tb_name = new MaskedTextBox();
            label1 = new Label();
            btn_Connect = new Button();
            label2 = new Label();
            tb_Message = new TextBox();
            btn_send = new Button();
            lv_message = new ListView();
            SuspendLayout();
            // 
            // tb_name
            // 
            tb_name.Location = new Point(12, 43);
            tb_name.Margin = new Padding(3, 2, 3, 2);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(140, 23);
            tb_name.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "Your name ";
            // 
            // btn_Connect
            // 
            btn_Connect.BackColor = Color.Silver;
            btn_Connect.Location = new Point(174, 42);
            btn_Connect.Margin = new Padding(3, 2, 3, 2);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(82, 22);
            btn_Connect.TabIndex = 3;
            btn_Connect.Text = "Connect";
            btn_Connect.UseVisualStyleBackColor = false;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 4;
            label2.Text = "Message";
            // 
            // tb_Message
            // 
            tb_Message.Location = new Point(12, 90);
            tb_Message.Margin = new Padding(3, 2, 3, 2);
            tb_Message.Name = "tb_Message";
            tb_Message.Size = new Size(429, 23);
            tb_Message.TabIndex = 5;
            // 
            // btn_send
            // 
            btn_send.BackColor = Color.Silver;
            btn_send.Location = new Point(462, 88);
            btn_send.Margin = new Padding(3, 2, 3, 2);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(82, 22);
            btn_send.TabIndex = 6;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = false;
            btn_send.Click += btn_send_Click;
            // 
            // lv_message
            // 
            lv_message.Location = new Point(12, 157);
            lv_message.Margin = new Padding(3, 2, 3, 2);
            lv_message.Name = "lv_message";
            lv_message.Size = new Size(532, 207);
            lv_message.TabIndex = 7;
            lv_message.UseCompatibleStateImageBehavior = false;
            lv_message.View = View.List;
            // 
            // Bai03_Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(592, 389);
            Controls.Add(lv_message);
            Controls.Add(btn_send);
            Controls.Add(tb_Message);
            Controls.Add(label2);
            Controls.Add(btn_Connect);
            Controls.Add(label1);
            Controls.Add(tb_name);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bai03_Client";
            Text = "Bai03_Client";
            FormClosing += Bai03_Client_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaskedTextBox tb_name;
        private Label label1;
        private Button btn_Connect;
        private Label label2;
        private TextBox tb_Message;
        private Button btn_send;
        private ListView lv_message;
    }
}