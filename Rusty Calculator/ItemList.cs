using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Rusty_Calculator
{
	public class ItemList: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private List<Item> items;
		public List<Item> Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
			}
		}

		public Visibility ScrollViewerVisibility
		{
			get
			{
				if (items.Count > 0) return Visibility.Visible;
				else return Visibility.Collapsed;
			}
			set { }
		}

		public ItemList()
		{
			items = new List<Item>();
		}

		public void Add(string input)
		{
			Items.Add(new Item(input, items.Count));
			NotifyPropertyChanged("Items");
			NotifyPropertyChanged("ScrollViewerVisibility");
		}

		public void RemoveById(int toRemove)
		{
			foreach (var i in Items)
			{
				if (i.ID == toRemove)
				{
					Items.Remove(i);
					break;
				}
			}
			
			NotifyPropertyChanged("Items");
			NotifyPropertyChanged("ScrollViewerVisibility");
		}

		public void RemoveAll()
		{
			Items.Clear();
			NotifyPropertyChanged("Items");
			NotifyPropertyChanged("ScrollViewerVisibility");
		}

		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
