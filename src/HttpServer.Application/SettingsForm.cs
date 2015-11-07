using System;
using System.Windows.Forms;
using HttpServer.Properties;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;
using HttpServer.Utilities;

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
            var shouldEnable = !(authenticateCheckBox.Checked && (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text)));

            saveButton.Enabled = shouldEnable;
            resetButton.Enabled = shouldEnable;
        }

        private void ShowHelp() => Process.Start("http://hughbellamy.com/index.html#http-server-info");

        private void ChangeRootFolder(object sender, EventArgs e) => WillShowFolderBrowserDialog?.Invoke(this, new EventArgs());

        private void OpenLocalhost(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(ulrLinkLabel.Text);

        private void websiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://hughbellamy.com");
        
        private RegistryKey AppRegistryKey { get; } = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private void Reload(object sender, EventArgs e) => LoadSettings();
        private void Save(object sender, EventArgs e) => SaveSettings();

        public void LoadSettings()
        {
            rootTextBox.Text = Settings.Default.Root;
            portNumericUpDown.Value = Settings.Default.Port;

            ulrLinkLabel.Text = "http://localhost:" + Settings.Default.Port + "/";

            authenticateCheckBox.Checked = Settings.Default.ShouldAuthenticate;
            UpdateAuthenticateEnabled();

            startupCheckBox.Checked = AppRegistryKey.GetValue("HttpServer") != null;
            notifyCheckBox.Checked = Settings.Default.NotifyMe;
            updatesCheckBox.Checked = Settings.Default.CheckForUpdates;

            saveButton.Enabled = false;
            resetButton.Enabled = false;
        }

        private void SaveSettings()
        {
            Settings.Default.Port = (int)portNumericUpDown.Value;
            Settings.Default.Root = rootTextBox.Text;

            Settings.Default.ShouldAuthenticate = authenticateCheckBox.Checked;
            if (authenticateCheckBox.Checked)
            {
                Settings.Default.Username = usernameTextBox.Text;
                Settings.Default.Password = new TripleDesStringEncryptor().EncryptString(passwordTextBox.Text);
            }

            if (startupCheckBox.Checked)
            {
                AppRegistryKey.SetValue("HttpServer", Application.ExecutablePath);
            }
            else
            {
                AppRegistryKey.DeleteValue("HttpServer", false);
            }

            Settings.Default.NotifyMe = notifyCheckBox.Checked;
            Settings.Default.CheckForUpdates = updatesCheckBox.Checked;
            Settings.Default.Save();

            LoadSettings();
            DidSave?.Invoke(this, new EventArgs());
        }

        private void authenticateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Changed(sender, e);
            UpdateAuthenticateEnabled();
        }

        private void UpdateAuthenticateEnabled()
        {
            usernameLabel.Enabled = authenticateCheckBox.Checked;
            usernameTextBox.Enabled = authenticateCheckBox.Checked;

            passwordLabel.Enabled = authenticateCheckBox.Checked;
            passwordTextBox.Enabled = authenticateCheckBox.Checked;
        }
    }
}
