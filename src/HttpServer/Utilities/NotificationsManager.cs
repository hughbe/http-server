using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notifications
{
    public class NotificationsManager : IDisposable
    {
        public NotifyIcon NotifyIcon { get; private set; } = new NotifyIcon();
        public ContextMenu ContextMenu { get; private set; } = new ContextMenu();

        public event EventHandler NotificationIconClicked;
        public event EventHandler NotificationClicked;

        public NotificationsManager(string text, Icon icon)
        {
            NotifyIcon.Text = text;
            NotifyIcon.Icon = icon;
            NotifyIcon.ContextMenu = ContextMenu;
            NotifyIcon.Visible = true;

            NotifyIcon.Click += (sender, e) => NotificationIconClicked?.Invoke(this, e);
            NotifyIcon.BalloonTipClicked += (sender, e) => NotificationClicked?.Invoke(this, e);
        }

        public void AddContextMenuItem(string text, EventHandler onClick) => ContextMenu.MenuItems.Add(new MenuItem(text, onClick));

        public void ShowBalloonToolTip(string title, string text = "", int duration = 1500, ToolTipIcon icon = ToolTipIcon.Info) => NotifyIcon.ShowBalloonTip(duration, title, text, icon);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (NotifyIcon != null)
                {
                    NotifyIcon.Visible = false;
                    NotifyIcon.Dispose();
                    NotifyIcon = null;
                }

                if (ContextMenu != null)
                {
                    ContextMenu.MenuItems.Clear();
                    ContextMenu.Dispose();
                    ContextMenu = null;
                }
            }
        }
    }
}
