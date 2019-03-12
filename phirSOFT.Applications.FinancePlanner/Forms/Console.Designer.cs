namespace phirSOFT.Applications.FinancePlanner.Forms
{
    partial class Console
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.consoleTextBox1 = new phirSOFT.Applications.FinancePlanner.Controls.ConsoleTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.consoleTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // consoleTextBox1
            // 
            this.consoleTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.consoleTextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.consoleTextBox1.BackBrush = null;
            this.consoleTextBox1.CharHeight = 14;
            this.consoleTextBox1.CharWidth = 8;
            this.consoleTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.consoleTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.consoleTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleTextBox1.IsReadLineMode = true;
            this.consoleTextBox1.IsReplaceMode = false;
            this.consoleTextBox1.Location = new System.Drawing.Point(0, 0);
            this.consoleTextBox1.Name = "consoleTextBox1";
            this.consoleTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.consoleTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.consoleTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("consoleTextBox1.ServiceColors")));
            this.consoleTextBox1.Size = new System.Drawing.Size(284, 261);
            this.consoleTextBox1.TabIndex = 0;
            this.consoleTextBox1.Zoom = 100;
            this.consoleTextBox1.LineRead += new System.EventHandler<phirSOFT.Applications.FinancePlanner.Controls.LineReadEventArgs>(this.consoleTextBox1_LineRead);
            this.consoleTextBox1.Load += new System.EventHandler(this.consoleTextBox1_Load);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.consoleTextBox1);
            this.Name = "Console";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Console_Load);
            this.Shown += new System.EventHandler(this.Console_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.consoleTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ConsoleTextBox consoleTextBox1;
    }
}