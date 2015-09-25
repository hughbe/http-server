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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.browseButton = new System.Windows.Forms.Button();
            this.rootTextBox = new System.Windows.Forms.TextBox();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.portLabel = new System.Windows.Forms.Label();
            this.rootDirectoryLabel = new System.Windows.Forms.Label();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.startupLabel = new System.Windows.Forms.Label();
            this.notifyLabel = new System.Windows.Forms.Label();
            this.notifyCheckBox = new System.Windows.Forms.CheckBox();
            this.checkForUpdatesCheckBox = new System.Windows.Forms.Label();
            this.updatesCheckBox = new System.Windows.Forms.CheckBox();
            this.websiteLabel = new System.Windows.Forms.LinkLabel();
            this.ulrLinkLabel = new System.Windows.Forms.LinkLabel();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(408, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(110, 31);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.ChangeRootFolder);
            // 
            // rootTextBox
            // 
            this.rootTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootTextBox.Location = new System.Drawing.Point(75, 12);
            this.rootTextBox.Name = "rootTextBox";
            this.rootTextBox.Size = new System.Drawing.Size(327, 31);
            this.rootTextBox.TabIndex = 1;
            this.rootTextBox.TextChanged += new System.EventHandler(this.Changed);
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portNumericUpDown.Location = new System.Drawing.Point(75, 49);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(443, 31);
            this.portNumericUpDown.TabIndex = 3;
            this.portNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.portNumericUpDown.ValueChanged += new System.EventHandler(this.Changed);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(12, 51);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(57, 25);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port:";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rootDirectoryLabel
            // 
            this.rootDirectoryLabel.AutoSize = true;
            this.rootDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootDirectoryLabel.Location = new System.Drawing.Point(12, 12);
            this.rootDirectoryLabel.Name = "rootDirectoryLabel";
            this.rootDirectoryLabel.Size = new System.Drawing.Size(63, 25);
            this.rootDirectoryLabel.TabIndex = 4;
            this.rootDirectoryLabel.Text = "Root:";
            this.rootDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startupCheckBox.Location = new System.Drawing.Point(190, 90);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(15, 14);
            this.startupCheckBox.TabIndex = 6;
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // startupLabel
            // 
            this.startupLabel.AutoSize = true;
            this.startupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startupLabel.Location = new System.Drawing.Point(12, 83);
            this.startupLabel.Name = "startupLabel";
            this.startupLabel.Size = new System.Drawing.Size(172, 25);
            this.startupLabel.TabIndex = 7;
            this.startupLabel.Text = "Open on startup:";
            this.startupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyLabel
            // 
            this.notifyLabel.AutoSize = true;
            this.notifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyLabel.Location = new System.Drawing.Point(13, 120);
            this.notifyLabel.Name = "notifyLabel";
            this.notifyLabel.Size = new System.Drawing.Size(108, 25);
            this.notifyLabel.TabIndex = 9;
            this.notifyLabel.Text = "Notify me:";
            this.notifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyCheckBox
            // 
            this.notifyCheckBox.AutoSize = true;
            this.notifyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyCheckBox.Location = new System.Drawing.Point(127, 127);
            this.notifyCheckBox.Name = "notifyCheckBox";
            this.notifyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.notifyCheckBox.TabIndex = 8;
            this.notifyCheckBox.UseVisualStyleBackColor = true;
            this.notifyCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // checkForUpdatesCheckBox
            // 
            this.checkForUpdatesCheckBox.AutoSize = true;
            this.checkForUpdatesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkForUpdatesCheckBox.Location = new System.Drawing.Point(13, 160);
            this.checkForUpdatesCheckBox.Name = "checkForUpdatesCheckBox";
            this.checkForUpdatesCheckBox.Size = new System.Drawing.Size(193, 25);
            this.checkForUpdatesCheckBox.TabIndex = 11;
            this.checkForUpdatesCheckBox.Text = "Check for updates:";
            this.checkForUpdatesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updatesCheckBox
            // 
            this.updatesCheckBox.AutoSize = true;
            this.updatesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatesCheckBox.Location = new System.Drawing.Point(212, 168);
            this.updatesCheckBox.Name = "updatesCheckBox";
            this.updatesCheckBox.Size = new System.Drawing.Size(15, 14);
            this.updatesCheckBox.TabIndex = 10;
            this.updatesCheckBox.UseVisualStyleBackColor = true;
            this.updatesCheckBox.CheckedChanged += new System.EventHandler(this.Changed);
            // 
            // websiteLabel
            // 
            this.websiteLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.websiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteLabel.Location = new System.Drawing.Point(0, 274);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(530, 34);
            this.websiteLabel.TabIndex = 12;
            this.websiteLabel.TabStop = true;
            this.websiteLabel.Text = "Help, Suggestions, Support, Updates";
            this.websiteLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.websiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLabel_LinkClicked);
            // 
            // ulrLinkLabel
            // 
            this.ulrLinkLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ulrLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulrLinkLabel.Location = new System.Drawing.Point(0, 240);
            this.ulrLinkLabel.Name = "ulrLinkLabel";
            this.ulrLinkLabel.Size = new System.Drawing.Size(530, 34);
            this.ulrLinkLabel.TabIndex = 13;
            this.ulrLinkLabel.TabStop = true;
            this.ulrLinkLabel.Text = "http://localhost:8000";
            this.ulrLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ulrLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenLocalhost);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(18, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 36);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(99, 196);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 36);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reload);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 308);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ulrLinkLabel);
            this.Controls.Add(this.websiteLabel);
            this.Controls.Add(this.checkForUpdatesCheckBox);
            this.Controls.Add(this.updatesCheckBox);
            this.Controls.Add(this.notifyLabel);
            this.Controls.Add(this.notifyCheckBox);
            this.Controls.Add(this.startupLabel);
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.rootDirectoryLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portNumericUpDown);
            this.Controls.Add(this.rootTextBox);
            this.Controls.Add(this.browseButton);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label rootDirectoryLabel;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.Label startupLabel;
        private System.Windows.Forms.Label notifyLabel;
        private System.Windows.Forms.CheckBox notifyCheckBox;
        private System.Windows.Forms.Label checkForUpdatesCheckBox;
        private System.Windows.Forms.CheckBox updatesCheckBox;
        private System.Windows.Forms.LinkLabel websiteLabel;
        private System.Windows.Forms.LinkLabel ulrLinkLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        public System.Windows.Forms.TextBox rootTextBox;
    }
}

