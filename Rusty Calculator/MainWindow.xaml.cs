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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Visibility = Visibility.Collapsed;
		}

		private void NewTB_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				App.MainItemList.Add(NewTB.Text);
				MainIC.Items.Refresh();

				NewTB.Text = "";
				NewTB.Focus();
			}
		}

		private void MainSV_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			MainSV.ScrollToBottom();
		}

		private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var lines = (sender as TextBox).Text.Split(new char[] { '\r', '\n' });

			var count = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				if (i == lines.Length - 1) count++;
				else if (lines[i] != "") count++;
			}

			(sender as TextBox).Height = 12 + (21 * (count == 0 ? 1 : count));
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

		private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 3)
			{
				(sender as TextBox).SelectAll();
			}
		}

		private void HeaderTB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Visibility = Visibility.Collapsed;
		}

		private void DeleteItemMenuItem_Click(object sender, RoutedEventArgs e)
		{
			var tag = (sender as MenuItem).Tag.ToString();

			App.MainItemList.RemoveById(Convert.ToInt32(tag));
			MainIC.Items.Refresh();

			NewTB.Text = "";
			NewTB.Focus();
		}

		private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
		{
			Clipboard.SetText((sender as MenuItem).Tag.ToString());
		}

		private void Window_Activated(object sender, EventArgs e)
		{
			NewTB.Focus();
		}
	}
}
