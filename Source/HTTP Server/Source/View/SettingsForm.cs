using System;
using System.Windows.Forms;
using HttpServer.Properties;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;

namespace HttpServer
{
    /// <summary>
    /// The class managing changing the settings of the server
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Creates the settings form
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The method called when the change settings form loads. It configures the root directory/port/link label to display the user's saved settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {            
            rootTextBox.Text = Settings.Default.Root;
            portNumericUpDown.Value = Settings.Default.Port;
            UpdateLocalhostLinkLabel();

            startupCheckBox.Checked = appRegistryKey.GetValue("HttpServer") != null;

            notifyCheckBox.Checked = Settings.Default.NotifyMe;
            updatesCheckBox.Checked = Settings.Default.CheckForUpdates;
        }

        /// <summary>
        /// The method called when the user requests help
        /// </summary>
        /// <param name="sender">The change settings form from which the help request originated</param>
        /// <param name="hlpevent">The arguments for the help request event</param>
        private void Form_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Process.Start("http://hughbellamy.com/httpserver.html");
        }

        /// <summary>
        /// The method called when the user clicks on the help button
        /// </summary>
        /// <param name="sender">The change settings form on which the help button was pressed</param>
        /// <param name="hlpevent">The arguments for the help button click event</param>
        private void Form_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start("http://hughbellamy.com/httpserver.html");
        }

        /// <summary>
        /// The method called when the user clicks on the button to change the root directory. It either displays a folder selector or updates user's settings if the user has typed in the new root directory
        /// </summary>
        /// <param name="sender">The change root folder button clicked</param>
        /// <param name="e">The arguments for the click event</param>
        private void ChangeRootFolder(object sender, EventArgs e)
        {
            if (rootTextBox.Text.Equals(Settings.Default.Root) || rootTextBox.Text.Replace(" ", "").Length == 0)
            {
                UserInterface.SharedUI.ShowSelectRootFolderDialog(true);
            }
            else
            {
                Settings.Default.Root = rootTextBox.Text;
                Settings.Default.Save();
                UserInterface.SharedUI.ShowBalloonToolTip("Updated Root Directory", "Restarting server...", 1500, false);
                HttpListenerServer.SharedServer.Restart(Settings.Default.Port, Settings.Default.Root);
                UpdateLocalhostLinkLabel();
            }
        }

        /// <summary>
        /// The method called when the user clicks on the button to save the port the server listens on
        /// </summary>
        /// <param name="sender">The save port button clicked</param>
        /// <param name="e">The arguments for the click event</param>
        private void ChangePort(object sender, EventArgs e)
        {
            Settings.Default.Port = (int)portNumericUpDown.Value;
            Settings.Default.Save();
            UserInterface.SharedUI.ShowBalloonToolTip("Updated Port", "Restarting server...", 1500, false);
            HttpListenerServer.SharedServer.Restart(Settings.Default.Port, Settings.Default.Root);
            UpdateLocalhostLinkLabel();
        }

        /// <summary>
        /// The method called when the user clicks on the server URL link label. It opens the user's default web browser to view the server
        /// </summary>
        /// <param name="sender">The link label clicked</param>
        /// <param name="e">The arguments for the link label clicked event</param>
        private void OpenLocalhost(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ulrLinkLabel.Text);
        }

        /// <summary>
        /// The method called when the user clicks on the Help, Support, Suggestions and Updates label. It opens the user's default web browser to view hughbellamy.com
        /// </summary>
        /// <param name="sender">The link label clicked</param>
        /// <param name="e">The arguments for the link label clicked event</param>
        private void websiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://hughbellamy.com");
        }

        /// <summary>
        /// Updates the server URL link label to the correct URL of the server depending on the saved listening port
        /// </summary>
        private void UpdateLocalhostLinkLabel()
        {
            ulrLinkLabel.Text = "http://localhost:" + Settings.Default.Port.ToString() + "/";
        }
        
        /// <summary>
        /// The location of entries for apps to open on startup
        /// </summary>
        RegistryKey appRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        /// <summary>
        /// Updates whether the server should run on startup
        /// </summary>
        /// <param name="sender">The checkbox the user toggled to update whether the server should run on startup</param>
        /// <param name="e">The toggle checkbox event arguments</param>
        private void ChangeOpenOnStartup(object sender, EventArgs e)
        {
            if (startupCheckBox.Checked)
            {
                appRegistryKey.SetValue("HttpServer", Application.ExecutablePath.ToString());
            }
            else
            {
                appRegistryKey.DeleteValue("HttpServer", false);
            }
        }

        /// <summary>
        /// Updates whether the app should notify the user when it launches etc.
        /// </summary>
        /// <param name="sender">The checkbox the user toggled to update whether the app should notify the user when it launches etc.</param>
        /// <param name="e">The toggle checkbox event arguments</param>
        private void ChangeNotifyMe(object sender, EventArgs e)
        {
            Settings.Default.NotifyMe = notifyCheckBox.Checked;
            Settings.Default.Save();
        }

        /// <summary>
        /// Updates whether the app should check for updates when it launches
        /// </summary>
        /// <param name="sender">The checkbox the user toggled to update whether the app should check for updates when it launches </param>
        /// <param name="e">The toggle checkbox event arguments</param>
        private void ChangeCheckForUpdates(object sender, EventArgs e)
        {
            Settings.Default.CheckForUpdates = updatesCheckBox.Checked;
            Settings.Default.Save();
        }
    }
}
