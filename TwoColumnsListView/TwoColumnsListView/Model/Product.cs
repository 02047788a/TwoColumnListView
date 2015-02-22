using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace TwoColumnsListView
{
	public class Product
	{
		public Product ()
		{
		}

		public int ID { get; set; }
		public string Name { get; set;}
		public double Price { get; set;}
		public string PhotoURL { get; set;}
	}
}

