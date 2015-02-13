using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace TwoColumnsListView
{
	public class Product
	{
		public Product ()
		{
			this.TapPhotoEvent = new Command<int> (productId => {
				System.Diagnostics.Debug.WriteLine("Touch Product Photo ID:{0}", this.ID);
			});
		}

		public int ID { get; set; }
		public string Name { get; set;}
		public double Price { get; set;}
		public string PhotoURL { get; set;}
		public ICommand TapPhotoEvent { get; set; }
	}
}

