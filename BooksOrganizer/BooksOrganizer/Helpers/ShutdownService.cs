// ****************************************************************************
// <copyright file="ShutdownService.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************


using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace BooksOrganizer.Helpers
{
    public static class ShutdownService
    {
        public static void RequestShutdown()
        {
            var shouldAbortShutdown = false;

            Messenger.Default.Send(new NotificationMessageAction<bool>(
                                       Notifications.ConfirmShutdown,
                                       shouldAbort => shouldAbortShutdown |= shouldAbort));

            if (!shouldAbortShutdown)
            {
                // This time it is for real
                Messenger.Default.Send(new NotificationMessage(Notifications.NotifyShutdown));

                Application.Current.Shutdown();
            }
        }
    }

    public static class DragMoveService
    {
        public static void RequestDragMove()
        {
            Application.Current.MainWindow.DragMove();
        }
    }


}
