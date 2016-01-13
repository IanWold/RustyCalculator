using System;
using System.ComponentModel;

namespace Rusty_Calculator
{
	public class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		public string Title
		{
			get
			{
				var output = " = " + Output;

				var newInput = "";
				foreach (var i in input.Split(new char[] { '\r', '\n' }))
				{
					newInput += i;
				}

				var toReturn = newInput + output;

				if (toReturn.Length > 38)
				{
					toReturn = newInput.Substring(0, (38 - output.Length - 3)) + "..." + output;
				}

				return toReturn;
			}
			set { }
		}

		private string input;
		public string Input
		{
			get
			{
				return input;
			}
			set
			{
				input = value;
				NotifyPropertyChanged("Input");
				NotifyPropertyChanged("Output");
				NotifyPropertyChanged("Title");
			}
		}

		private string lastOutput;
		public string Output
		{
			get
			{
				try
				{
					var output = ExpressionParser.ParseExpression(Input).Compile()().ToString();
					lastOutput = output;
					return output;
				}
				catch (Exception ex)
				{
					return lastOutput;
				}
			}
			set { }
		}

		private int id;
		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
				NotifyPropertyChanged("ID");
			}
		}

		public Item(string _input, int _id)
		{
			input = _input;
			id = _id;
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
