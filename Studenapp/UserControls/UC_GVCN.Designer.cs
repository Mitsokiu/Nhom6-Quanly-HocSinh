namespace Studenapp.UserControls
{
    partial class UC_GVCN : UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(13, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1177, 78);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(17, 96);
            panel2.Name = "panel2";
            panel2.Size = new Size(1173, 562);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(121, 18);
            button1.Name = "button1";
            button1.Size = new Size(257, 34);
            button1.TabIndex = 0;
            button1.Text = "Xem Danh Sách Học Sinh";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(620, 23);
            button2.Name = "button2";
            button2.Size = new Size(232, 34);
            button2.TabIndex = 1;
            button2.Text = "Học Phí";
            button2.UseVisualStyleBackColor = true;
            // 
            // UC_GVCN
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_GVCN";
            Size = new Size(1193, 661);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Panel panel2;
    }
}
