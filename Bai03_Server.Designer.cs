namespace _22521100_Lab6
{
    partial class Bai03_Server
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
            btn_Listen = new Button();
            lv_ListLog = new ListView();
            SuspendLayout();
            // 
            // btn_Listen
            // 
            btn_Listen.Location = new Point(414, 17);
            btn_Listen.Margin = new Padding(3, 2, 3, 2);
            btn_Listen.Name = "btn_Listen";
            btn_Listen.Size = new Size(82, 22);
            btn_Listen.TabIndex = 1;
            btn_Listen.Text = "Listen";
            btn_Listen.UseVisualStyleBackColor = true;
            btn_Listen.Click += btn_Listen_Click;
            // 
            // lv_ListLog
            // 
            lv_ListLog.Location = new Point(10, 51);
            lv_ListLog.Margin = new Padding(3, 2, 3, 2);
            lv_ListLog.Name = "lv_ListLog";
            lv_ListLog.Size = new Size(486, 261);
            lv_ListLog.TabIndex = 2;
            lv_ListLog.UseCompatibleStateImageBehavior = false;
            lv_ListLog.View = View.List;
            // 
            // Bai03_Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 326);
            Controls.Add(lv_ListLog);
            Controls.Add(btn_Listen);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bai03_Server";
            Text = "Bai03_Server";
            FormClosing += Bai03_Server_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Listen;
        private ListView lv_ListLog;
    }
}