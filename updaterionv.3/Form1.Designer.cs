namespace updaterionv._3
{
    partial class Form1
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.driverCheckBox = new System.Windows.Forms.CheckBox();
            this.softwareCheckBox = new System.Windows.Forms.CheckBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.errorBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dibutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(13, 138);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(267, 214);
            this.checkedListBox1.TabIndex = 0;
            // 
            // driverCheckBox
            // 
            this.driverCheckBox.AutoSize = true;
            this.driverCheckBox.Location = new System.Drawing.Point(12, 13);
            this.driverCheckBox.Name = "driverCheckBox";
            this.driverCheckBox.Size = new System.Drawing.Size(97, 17);
            this.driverCheckBox.TabIndex = 1;
            this.driverCheckBox.Text = "Driver Updates";
            this.driverCheckBox.UseVisualStyleBackColor = true;
            this.driverCheckBox.CheckedChanged += new System.EventHandler(this.driverCheckBox_CheckedChanged);
            // 
            // softwareCheckBox
            // 
            this.softwareCheckBox.AutoSize = true;
            this.softwareCheckBox.Location = new System.Drawing.Point(12, 37);
            this.softwareCheckBox.Name = "softwareCheckBox";
            this.softwareCheckBox.Size = new System.Drawing.Size(111, 17);
            this.softwareCheckBox.TabIndex = 2;
            this.softwareCheckBox.Text = "Software Updates";
            this.softwareCheckBox.UseVisualStyleBackColor = true;
            this.softwareCheckBox.CheckedChanged += new System.EventHandler(this.softwareCheckBox_CheckedChanged);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(13, 60);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(266, 26);
            this.scanButton.TabIndex = 3;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(189, 7);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(90, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // errorBox1
            // 
            this.errorBox1.BackColor = System.Drawing.SystemColors.Control;
            this.errorBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorBox1.ForeColor = System.Drawing.Color.Red;
            this.errorBox1.Location = new System.Drawing.Point(47, 119);
            this.errorBox1.Name = "errorBox1";
            this.errorBox1.Size = new System.Drawing.Size(231, 13);
            this.errorBox1.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(189, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dibutton
            // 
            this.dibutton.Location = new System.Drawing.Point(13, 92);
            this.dibutton.Name = "dibutton";
            this.dibutton.Size = new System.Drawing.Size(267, 26);
            this.dibutton.TabIndex = 7;
            this.dibutton.Text = "Download and Install";
            this.dibutton.UseVisualStyleBackColor = true;
            this.dibutton.Click += new System.EventHandler(this.dibutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 366);
            this.Controls.Add(this.dibutton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.errorBox1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.softwareCheckBox);
            this.Controls.Add(this.driverCheckBox);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox driverCheckBox;
        private System.Windows.Forms.CheckBox softwareCheckBox;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox errorBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button dibutton;
    }
}

