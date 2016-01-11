using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rusty_Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Height = SystemParameters.WorkArea.Height - 12;
			Left = SystemParameters.PrimaryScreenWidth - Width - 6;

			NewTB.Focus();

			DataContext = App.MainItemList;
		}

		private void NewTB_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				App.MainItemList.Add(new Item(NewTB.Text));
				MainIC.Items.Refresh();

				NewTB.Text = "";
				NewTB.Focus();
			}
		}

		private void MainSV_LayoutUpdated(object sender, EventArgs e)
		{
		}

		private void MainSV_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			MainSV.ScrollToBottom();
		}

		private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var lines = (sender as TextBox).Text.Split(new char[] { '\r', '\n' });

			var count = 0;
			foreach (var l in lines)
			{
				if (l != "") count++;
			}

			(sender as TextBox).Height = 12 + (21 * count);
		}

		private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
			{
				isCtrlPressed = false;
			}
		}

		bool isCtrlPressed = false;
		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
			{
				isCtrlPressed = true;
			}

			if ((e.Key == Key.Enter || e.Key == Key.OemPlus) && isCtrlPressed)
			{
				var target = ((sender as TextBox).Parent as StackPanel).Children[2] as TextBox;
				target.Focus();
				target.SelectAll();

				isCtrlPressed = false;
			}
		}
	}
}
