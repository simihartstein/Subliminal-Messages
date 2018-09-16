using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Subliminal_Messages
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public DispatcherTimer OnTimer;
		public DispatcherTimer OffTimer;

		private WpfScreen[] Screens = WpfScreen.AllScreens().ToArray();

		private Random Rand = new Random();

		public MainWindow()
		{
			InitializeComponent();
			OnTimer = new DispatcherTimer();
			OffTimer = new DispatcherTimer();

			OnTimer.Interval = TimeSpan.FromMilliseconds(20);
			OffTimer.Interval = TimeSpan.FromMilliseconds(500);

			OnTimer.Tick += OnTimer_Tick;
			OffTimer.Tick += OffTimer_Tick;

			OnTimer.Start();

			Microsoft.Win32.SystemEvents.DisplaySettingsChanged += (s, e) => { Screens = WpfScreen.AllScreens().ToArray(); };
		}

		private void OnTimer_Tick(object sender, EventArgs e)
		{
			Visibility = Visibility.Hidden;
			OnTimer.IsEnabled = false;
			OffTimer.Start();
		}

		private void OffTimer_Tick(object sender, EventArgs e)
		{
			var location = GetRandomScreenLocation();
			Left = location.X;
			Top = location.Y;
			
			Visibility = Visibility.Visible;
			OffTimer.IsEnabled = false;
			OnTimer.Start();
		}
		
		private void Window_SourceInitialized(object sender, EventArgs e)
		{
			var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			WindowsServices.SetWindowExTransparentExNoActivate(hwnd);


		}

		private Point GetRandomScreenLocation()
		{
			var screen = Screens[Rand.Next(Screens.Length)];
			var deviceBounds = screen.DeviceBounds;
			
			return new Point()
			{
				X = RandomDouble(deviceBounds.Left, deviceBounds.Right - ActualWidth),
				Y = RandomDouble(deviceBounds.Top, deviceBounds.Bottom - ActualHeight),
			};
		}

		private double RandomDouble(double min, double max)
		{
			return min + Rand.NextDouble() * (max - min);
		}
	}
}
