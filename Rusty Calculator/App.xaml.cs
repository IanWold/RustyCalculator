using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Rusty_Calculator
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		private static ItemList mainItemList = new ItemList();
		public static ItemList MainItemList
		{
			get
			{
				return mainItemList;
			}
			set
			{
				MainItemList = value;
			}
		}

		NotifyIcon nIcon = new NotifyIcon();

		
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			SetUpNotifyIcon();
		}

		private void SetUpNotifyIcon()
		{
			nIcon.Icon =
			  new System.Drawing.Icon(@".\Icon.ico");
			nIcon.Visible = true;
			nIcon.Text = "Rusty Calculator";

			nIcon.Click += NIcon_Click;
		}

		private void NIcon_Click(object sender, System.EventArgs e)
		{
			if (Current.Windows[0].Visibility == Visibility.Collapsed)
			{
				Current.Windows[0].Visibility = Visibility.Visible;
				Current.Windows[0].Activate();
			}
			else
			{
				Current.Windows[0].Visibility = Visibility.Collapsed;
			}
		}
	}
}
