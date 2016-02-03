using System.Windows;
using System.Windows.Forms;
using System.IO;
using System;
using SpracheJSON;

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

			//try
			//{
			//	using (StreamReader reader = new StreamReader("RustyItems.db"))
			//	{
			//		MainItemList = JSON.Map<ItemList>(reader.ReadToEnd());
			//	}
			//}
			//catch { }
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{
			//if (MainItemList.Items.Count > 0)
			//{
			//	using (StreamWriter writer = new StreamWriter("RustyItems.db"))
			//	{
			//		writer.Write(JSON.Write(MainItemList));
			//	}
			//}

			nIcon.Visible = false;
		}

		private void SetUpNotifyIcon()
		{
			nIcon.Icon = new System.Drawing.Icon(@".\Icon.ico");
			nIcon.Visible = true;
			nIcon.Text = "Rusty Calculator";

			var contextMenu = new ContextMenu();

			var menuOpen = new MenuItem("Rusty Calculator");
			menuOpen.Click += (sender, e) => {
				Current.Windows[0].Visibility = Visibility.Visible;
				Current.Windows[0].Activate();
			};

			var menuDeleteAll = new MenuItem("Delete All");
			menuDeleteAll.Click += (sender, e) => {
				MainItemList.RemoveAll();
				Current.Windows[0].Visibility = Visibility.Visible;
				Current.Windows[0].Activate();
			};

			var menuExit = new MenuItem("Exit");
			menuExit.Click += (sender, e) => { Shutdown(); };

			contextMenu.MenuItems.Add(menuOpen);
			contextMenu.MenuItems.Add(menuDeleteAll);
			contextMenu.MenuItems.Add(menuExit);

			nIcon.ContextMenu = contextMenu;

			nIcon.Click += (sender, e) => {
				if (Current.Windows[0].Visibility == Visibility.Collapsed)
				{
					Current.Windows[0].Visibility = Visibility.Visible;
					Current.Windows[0].Activate();
				}
				else
				{
					Current.Windows[0].Visibility = Visibility.Collapsed;
				}
			};
		}
	}
}
