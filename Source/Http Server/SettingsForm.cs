﻿using System;
using System.Windows.Forms;
using HttpServer.Properties;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;

namespace HttpServer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(EventHandler didSave, EventHandler willShowFolderBrowser)
        {
            DidSave = didSave;
            WillShowFolderBrowserDialog = willShowFolderBrowser;
            InitializeComponent();
            var textBox = portNumericUpDown.Controls[1];
            textBox.TextChanged += Changed;
        }

        private EventHandler DidSave { get; }
        private EventHandler WillShowFolderBrowserDialog { get; }

        private void Form_Load(object sender, EventArgs e) => LoadSettings();

        private void Form_HelpRequested(object sender, HelpEventArgs helpevent) => ShowHelp();
        
        private void Form_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ShowHelp();
        }

        public void Changed(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            resetButton.Enabled = true;
        }

        private void ShowHelp() => Process.Start("http://hughbellamy.com/index.html#http-server-info");

        private void ChangeRootFolder(object sender, EventArgs e) => WillShowFolderBrowserDialog?.Invoke(this, new EventArgs());

        private void OpenLocalhost(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(ulrLinkLabel.Text);

        private void websiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://hughbellamy.com");
        
        private RegistryKey appRegistryKey { get; } = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private void Reload(object sender, EventArgs e) => LoadSettings();
        private void Save(object sender, EventArgs e) => SaveSettings();

        public void LoadSettings()
        {
            rootTextBox.Text = Settings.Default.Root;
            portNumericUpDown.Value = Settings.Default.Port;

            ulrLinkLabel.Text = "http://localhost:" + Settings.Default.Port.ToString() + "/";

            startupCheckBox.Checked = appRegistryKey.GetValue("HttpServer") != null;

            notifyCheckBox.Checked = Settings.Default.NotifyMe;
            updatesCheckBox.Checked = Settings.Default.CheckForUpdates;

            saveButton.Enabled = false;
            resetButton.Enabled = false;
        }

        private void SaveSettings()
        {
            Settings.Default.Root = rootTextBox.Text;
            Settings.Default.Port = (int)portNumericUpDown.Value;

            if (startupCheckBox.Checked)
            {
                appRegistryKey.SetValue("HttpServer", Application.ExecutablePath.ToString());
            }
            else
            {
                appRegistryKey.DeleteValue("HttpServer", false);
            }

            Settings.Default.NotifyMe = notifyCheckBox.Checked;
            Settings.Default.CheckForUpdates = updatesCheckBox.Checked;
            Settings.Default.Save();

            LoadSettings();
            DidSave?.Invoke(this, new EventArgs());
        }
    }
}