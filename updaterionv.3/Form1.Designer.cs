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
            this.components = new System.ComponentModel.Container();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.driverCheckBox = new System.Windows.Forms.CheckBox();
            this.softwareCheckBox = new System.Windows.Forms.CheckBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.errorBox1 = new System.Windows.Forms.TextBox();
            this.dibutton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.automateButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(13, 138);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(709, 364);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
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
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(558, 13);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(130, 20);
            this.usernameTextBox.TabIndex = 8;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(558, 39);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(130, 20);
            this.passwordTextBox.TabIndex = 9;
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Location = new System.Drawing.Point(497, 17);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(55, 13);
            this.usernamelbl.TabIndex = 10;
            this.usernamelbl.Text = "Username";
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Location = new System.Drawing.Point(499, 42);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(53, 13);
            this.passwordlbl.TabIndex = 11;
            this.passwordlbl.Text = "Password";
            // 
            // automateButton
            // 
            this.automateButton.Location = new System.Drawing.Point(558, 65);
            this.automateButton.Name = "automateButton";
            this.automateButton.Size = new System.Drawing.Size(130, 23);
            this.automateButton.TabIndex = 12;
            this.automateButton.Text = "Automate";
            this.automateButton.UseVisualStyleBackColor = true;
            this.automateButton.Click += new System.EventHandler(this.automateButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 516);
            this.Controls.Add(this.automateButton);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.usernamelbl);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.dibutton);
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
        private System.Windows.Forms.Button dibutton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Button automateButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

