using System;
using System.Drawing;
using System.Windows.Forms;

namespace HttpServer
{
    public class NotificationsManager : IDisposable
    {
        private NotifyIcon NotifyIcon { get; set; } = new NotifyIcon();
        private ContextMenu ContextMenu { get; set; } = new ContextMenu();

        public NotificationsManager(string text, Icon icon, EventHandler onClick)
        {
            NotifyIcon.Text = text;
            NotifyIcon.Icon = icon;
            NotifyIcon.ContextMenu = ContextMenu;
            NotifyIcon.Click += onClick;
            NotifyIcon.Visible = true;
        }

        public void AddContextMenuItem(string text, EventHandler onClick) => ContextMenu.MenuItems.Add(new MenuItem(text, onClick));

        public void ShowBalloonToolTip(string title, string text, int duration)
        {
            NotifyIcon.BalloonTipTitle = title;
            NotifyIcon.BalloonTipText = text;
            NotifyIcon.ShowBalloonTip(duration);
        }

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
