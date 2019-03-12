namespace phirSOFT.Applications.FinancePlanner.Forms
{
    partial class Logger
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
            textBox1 = new System.Windows.Forms.RichTextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox1.Location = new System.Drawing.Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(284, 261);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
            // 
            // Logger
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(284, 261);
            Controls.Add(textBox1);
            Name = "Logger";
            Text = "Logger";
            Load += new System.EventHandler(Logger_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox textBox1;
    }
}