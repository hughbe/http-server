using HttpServer.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HttpServer
{
    /// <summary>
    /// The class managing displaying notifications, the settings page and the folder selector to the user
    /// </summary>
    public class UserInterface : IDisposable
    {
        #region Singleton

        private static UserInterface instance;
        private UserInterface() { }

        /// <summary>
        /// The user interface object is shown as a singleton - we only want one taskbar icon at a time
        /// </summary>
        public static UserInterface SharedUI
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInterface();
                }
                return instance;
            }
        }

        #endregion

        #region Notifications
        
        /// <summary>
        /// The notifyIcon in charge of displaying notifications to the user
        /// </summary>
        private NotifyIcon _notificationManager = new NotifyIcon();
        private NotifyIcon NotificationManager
        {
            get { return _notificationManager; }
        }

        /// <summary>
        /// The contextMenu in charge of providing permenant exit functionality to the user
        /// </summary>
        private ContextMenu _notificationContextMenu = new ContextMenu();
        private ContextMenu NotifactionContextMenu
        {
            get { return _notificationContextMenu; }
        }

        /// <summary>
        /// The exit menuItem that the user clicks on to exit the applications
        /// </summary>
        private MenuItem _exitMenuItem = new MenuItem();
        private MenuItem ExitMenuItem
        {
            get { return _exitMenuItem; }
        }

        /// <summary>
        /// The icon to show in the notifyIcon in the tasbar
        /// </summary>
        public Icon NotificationIcon
        {
            get { return NotificationManager.Icon; }
            set { NotificationManager.Icon = value; }
        }
        
        /// <summary>
        /// The text shown when the user hovers over the notifyIcon in the tasbar
        /// </summary>
        public string NotificationText
        {
            get { return NotificationManager.Text; }
            set { NotificationManager.Text = value; }
        }

        /// <summary>
        /// Sets up the tasbar icon and the right click and notification functionality of the notify icon
        /// </summary>
        public void SetupNotifications()
        {
            NotificationIcon = Resources.Icon;
            NotificationText = "HTTP Server";

            ExitMenuItem.Text = "Exit";
            ExitMenuItem.Click += new EventHandler(Exit_Clicked);

            NotifactionContextMenu.MenuItems.Add(ExitMenuItem);

            NotificationManager.ContextMenu = NotifactionContextMenu;
            NotificationManager.Click += new EventHandler(Notification_Clicked);

            NotificationManager.Visible = true;
        }

        /// <summary>
        /// Shows a customized notification to the user
        /// </summary>
        /// <param name="title">The title of the notification</param>
        /// <param name="text">The more detailed notification message</param>
        /// <param name="duration">The amount of time the notification should remain before being automatically dismissed</param>
        public void ShowBalloonToolTip(string title, string text, int duration, bool ignoreNotificationsSetting)
        {
            if (!Settings.Default.NotifyMe && !ignoreNotificationsSetting)
            {
                return;
            }
            NotificationManager.BalloonTipTitle = title;
            NotificationManager.BalloonTipText = text;
            NotificationManager.ShowBalloonTip(duration);
        }

        /// <summary>
        /// The method called when the user clicks on the exit button when right clicking on the notifyIcon in the taskbar. It exits the app
        /// </summary>
        /// <param name="sender">The menuItem clicked</param>
        /// <param name="e">The arguments for the click event</param>
        private void Exit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// The method called when the user clicks on the notifyIcon in the taskbar. It toggles the visibility of the settings form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_Clicked(object sender, EventArgs e)
        {
            if (!ChangeSettingsForm.Visible)
            {
                ChangeSettingsForm.ShowDialog();
            }
            else
            {
                ChangeSettingsForm.Hide();
            }
        }

        #endregion

        #region Change Settings

        /// <summary>
        /// The form presented to the user to change the root directory and port of the server
        /// </summary>
        private SettingsForm _changeSettingsForm = new SettingsForm();
        private SettingsForm ChangeSettingsForm
        {
            get { return _changeSettingsForm; }
        }

        #endregion

        #region

        /// <summary>
        /// Shows the folder selector to choose the root directory of the server
        /// </summary>
        /// <param name="usedBefore">A value indicating whether the user has used the application before - if they haven't then they cannot dismiss the folder selector</param>
        public void ShowSelectRootFolderDialog(bool usedBefore)
        {
            FolderBrowserExtended folderPicker = new FolderBrowserExtended
            {
                Description = "Select a folder as your root directory",
                ShowNewFolderButton = true,
                ShowEditBox = true,
                SelectedPath = Settings.Default.Root,
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowFullPathInEditBox = true
            };

            if (folderPicker.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.Root = folderPicker.SelectedPath;
                Settings.Default.UsedBefore = true;
                Settings.Default.Save();

                if (usedBefore)
                {
                    ShowBalloonToolTip("Updated Root Directory", "Restarting server...", 1500, false);
                }
                HttpListenerServer.SharedServer.Restart(Settings.Default.Port, Settings.Default.Root);
            }
            else if (!usedBefore)
            {
                MessageBox.Show("You need to select a root directory to use the server. Please try again.");
                Environment.Exit(0);
            }
        }

        #endregion

        #region Disposing

        /// <summary>
        /// Method called when the UserInterface object is disposed
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The method called when the UserInterface is disposed
        /// </summary>
        /// <param name="disposing">A value indicating whether managed objects should be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_notificationManager != null)
                {
                    _notificationManager.Dispose();
                    _notificationManager = null;
                }
                if (_exitMenuItem != null)
                {
                    _exitMenuItem.Dispose();
                    _exitMenuItem = null;
                }
                if (_notificationContextMenu != null)
                {
                    _notificationContextMenu.Dispose();
                    _notificationContextMenu = null;
                }
                if (_changeSettingsForm != null)
                {
                    _changeSettingsForm.Dispose();
                    _changeSettingsForm = null;
                }
            }

        }

        #endregion

    }
}
