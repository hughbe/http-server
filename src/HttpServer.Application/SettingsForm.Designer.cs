namespace HttpServer
{
    partial class SettingsForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.browseButton = new System.Windows.Forms.Button();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.notifyCheckBox = new System.Windows.Forms.CheckBox();
            this.updatesCheckBox = new System.Windows.Forms.CheckBox();
            this.websiteLabel = new System.Windows.Forms.LinkLabel();
            this.ulrLinkLabel = new System.Windows.Forms.LinkLabel();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.authenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.authenticateCheckBox = new System.Windows.Forms.CheckBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.rootLabel = new System.Windows.Forms.Label();
            this.rootTextBox = new System.Windows.Forms.TextBox();
            this.applicationGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.authenticationGroupBox.SuspendLayout();
            this.serverGroupBox.SuspendLayout();
            this.applicationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.browseButton.AutoSize = true;
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(274, 26);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(72, 30);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.ChangeRootFolder);
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portNumericUpDown.Location = new System.Drawing.Point(63, 62);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(283, 26);
            this.portNumericUpDown.TabIndex = 3;
            this.portNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.portNumericUpDown.ValueChanged += new System.EventHandler(this.Changed);
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startupCheckBox.Location = new System.Drawing.Point(13, 36);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(143, 24);
            this.startupCheckBox.TabIndex = 6;
            this.startupCheckBox.Text = "Open on startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // notifyCheckBox
            // 
            this.notifyCheckBox.AutoSize = true;
            this.notifyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyCheckBox.Location = new System.Drawing.Point(13, 66);
            this.notifyCheckBox.Name = "notifyCheckBox";
            this.notifyCheckBox.Size = new System.Drawing.Size(94, 24);
            this.notifyCheckBox.TabIndex = 8;
            this.notifyCheckBox.Text = "Notify Me";
            this.notifyCheckBox.UseVisualStyleBackColor = true;
            this.notifyCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // updatesCheckBox
            // 
            this.updatesCheckBox.AutoSize = true;
            this.updatesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatesCheckBox.Location = new System.Drawing.Point(13, 96);
            this.updatesCheckBox.Name = "updatesCheckBox";
            this.updatesCheckBox.Size = new System.Drawing.Size(158, 24);
            this.updatesCheckBox.TabIndex = 10;
            this.updatesCheckBox.Text = "Check for updates";
            this.updatesCheckBox.UseVisualStyleBackColor = true;
            this.updatesCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // websiteLabel
            // 
            this.websiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteLabel.Location = new System.Drawing.Point(375, 182);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(309, 34);
            this.websiteLabel.TabIndex = 12;
            this.websiteLabel.TabStop = true;
            this.websiteLabel.Text = "Help and Updates";
            this.websiteLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.websiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLabel_LinkClicked);
            // 
            // ulrLinkLabel
            // 
            this.ulrLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulrLinkLabel.Location = new System.Drawing.Point(375, 148);
            this.ulrLinkLabel.Name = "ulrLinkLabel";
            this.ulrLinkLabel.Size = new System.Drawing.Size(309, 34);
            this.ulrLinkLabel.TabIndex = 13;
            this.ulrLinkLabel.TabStop = true;
            this.ulrLinkLabel.Text = "http://localhost:8000";
            this.ulrLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ulrLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenLocalhost);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 257);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(62, 34);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // resetButton
            // 
            this.resetButton.AutoSize = true;
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.Enabled = false;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(80, 257);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(68, 34);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reload);
            // 
            // authenticationGroupBox
            // 
            this.authenticationGroupBox.Controls.Add(this.passwordLabel);
            this.authenticationGroupBox.Controls.Add(this.passwordTextBox);
            this.authenticationGroupBox.Controls.Add(this.usernameLabel);
            this.authenticationGroupBox.Controls.Add(this.authenticateCheckBox);
            this.authenticationGroupBox.Controls.Add(this.usernameTextBox);
            this.authenticationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationGroupBox.Location = new System.Drawing.Point(375, 12);
            this.authenticationGroupBox.Name = "authenticationGroupBox";
            this.authenticationGroupBox.Size = new System.Drawing.Size(309, 129);
            this.authenticationGroupBox.TabIndex = 16;
            this.authenticationGroupBox.TabStop = false;
            this.authenticationGroupBox.Text = "Authentication";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(11, 92);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(82, 20);
            this.passwordLabel.TabIndex = 20;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(99, 89);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(195, 26);
            this.passwordTextBox.TabIndex = 19;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.Changed);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(6, 60);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(87, 20);
            this.usernameLabel.TabIndex = 18;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authenticateCheckBox
            // 
            this.authenticateCheckBox.AutoSize = true;
            this.authenticateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticateCheckBox.Location = new System.Drawing.Point(6, 30);
            this.authenticateCheckBox.Name = "authenticateCheckBox";
            this.authenticateCheckBox.Size = new System.Drawing.Size(191, 24);
            this.authenticateCheckBox.TabIndex = 0;
            this.authenticateCheckBox.Text = "Require Authentication";
            this.authenticateCheckBox.UseVisualStyleBackColor = true;
            this.authenticateCheckBox.CheckedChanged += new System.EventHandler(this.authenticateCheckBox_CheckedChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(99, 57);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(195, 26);
            this.usernameTextBox.TabIndex = 17;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.Changed);
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Controls.Add(this.portLabel);
            this.serverGroupBox.Controls.Add(this.rootLabel);
            this.serverGroupBox.Controls.Add(this.rootTextBox);
            this.serverGroupBox.Controls.Add(this.browseButton);
            this.serverGroupBox.Controls.Add(this.portNumericUpDown);
            this.serverGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverGroupBox.Location = new System.Drawing.Point(12, 12);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(357, 98);
            this.serverGroupBox.TabIndex = 21;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "Server";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(15, 64);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(42, 20);
            this.portLabel.TabIndex = 20;
            this.portLabel.Text = "Port:";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rootLabel
            // 
            this.rootLabel.AutoSize = true;
            this.rootLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootLabel.Location = new System.Drawing.Point(9, 31);
            this.rootLabel.Name = "rootLabel";
            this.rootLabel.Size = new System.Drawing.Size(48, 20);
            this.rootLabel.TabIndex = 18;
            this.rootLabel.Text = "Root:";
            this.rootLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rootTextBox
            // 
            this.rootTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootTextBox.Location = new System.Drawing.Point(63, 28);
            this.rootTextBox.Name = "rootTextBox";
            this.rootTextBox.Size = new System.Drawing.Size(205, 26);
            this.rootTextBox.TabIndex = 17;
            this.rootTextBox.TextChanged += new System.EventHandler(this.Changed);
            // 
            // applicationGroupBox
            // 
            this.applicationGroupBox.Controls.Add(this.startupCheckBox);
            this.applicationGroupBox.Controls.Add(this.notifyCheckBox);
            this.applicationGroupBox.Controls.Add(this.updatesCheckBox);
            this.applicationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationGroupBox.Location = new System.Drawing.Point(12, 116);
            this.applicationGroupBox.Name = "applicationGroupBox";
            this.applicationGroupBox.Size = new System.Drawing.Size(357, 135);
            this.applicationGroupBox.TabIndex = 22;
            this.applicationGroupBox.TabStop = false;
            this.applicationGroupBox.Text = "Application";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 299);
            this.Controls.Add(this.applicationGroupBox);
            this.Controls.Add(this.serverGroupBox);
            this.Controls.Add(this.authenticationGroupBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ulrLinkLabel);
            this.Controls.Add(this.websiteLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "HTTP Server Settings";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.authenticationGroupBox.ResumeLayout(false);
            this.authenticationGroupBox.PerformLayout();
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.applicationGroupBox.ResumeLayout(false);
            this.applicationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.CheckBox notifyCheckBox;
        private System.Windows.Forms.CheckBox updatesCheckBox;
        private System.Windows.Forms.LinkLabel websiteLabel;
        private System.Windows.Forms.LinkLabel ulrLinkLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox authenticationGroupBox;
        private System.Windows.Forms.CheckBox authenticateCheckBox;
        private System.Windows.Forms.Label passwordLabel;
        public System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameLabel;
        public System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label rootLabel;
        public System.Windows.Forms.TextBox rootTextBox;
        private System.Windows.Forms.GroupBox applicationGroupBox;
    }
}

