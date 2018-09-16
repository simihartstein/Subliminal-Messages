using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Subliminal_Messages
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private TaskbarIcon tb;

		public App()
		{
			
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			tb = (TaskbarIcon)FindResource("NotifyIcon");
		}

		private void ExitCommandHandler(object sender, ExecutedRoutedEventArgs e)
		{
			Shutdown();
		}

		private void ExitCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void ContextMenu_Opened(object sender, RoutedEventArgs e)
		{
			var timer = ((MainWindow)Current.MainWindow).OffTimer;
			timer.Stop();
		}

		private void ContextMenu_Closed(object sender, RoutedEventArgs e)
		{
			var timer = ((MainWindow)Current.MainWindow).OffTimer;
			timer.Start();
		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			Current.Shutdown();
		}
	}
}
