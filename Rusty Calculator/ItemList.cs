using System.Collections.Generic;
using System.ComponentModel;

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

		public ItemList()
		{
			items = new List<Item>();
		}

		public void Add(Item toAdd)
		{
			Items.Add(toAdd);
			NotifyPropertyChanged("Items");
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
