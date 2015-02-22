using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace TwoColumnsListView
{
	public partial class MainPage : ContentPage
	{
		private static readonly MainPage instance = new MainPage();
		public static MainPage GetInstance()
		{
			return instance;
		}

	 	MainPage ()
		{
			InitializeComponent ();

			MessagingCenter.Subscribe<MainPage, int> (this, "PtoductPhoto_Tapped", (sender, productId)=>{
				Debug.WriteLine("Product ID:{0}", productId);
			});

			MessagingCenter.Subscribe<MainPage, int> (this, "FavoriteIcon_Tapped", (sender, productId)=>{
				Debug.WriteLine("Product ID:{0}", productId);

			});

		}
			
		List<TwoProducts> LoadDataSource()
		{
			List<Product> Dresses = new List<Product> ();
			for(int i=1; i<=33; i++ ){
				Dresses.Add (new Product () {
					ID = i,
					Name = "Dress_" + i.ToString ().PadLeft (3, '0'),
					Price = 59.0,
					PhotoURL  = "COAT_" + i.ToString ().PadLeft (3, '0') + "_disp.jpg",
				});
			}

			List<TwoProducts> dataSource = new List<TwoProducts> ();
			for (int i = 0; i <= Dresses.Count - 1; i += 2) {
				TwoProducts tp = new TwoProducts ();
				tp.ProductA = Dresses [i];
				if (i + 1 <= Dresses.Count - 1)
					tp.ProductB = Dresses [i + 1];
				else
					tp.ProductB = new Product ();
				dataSource.Add (tp);
			}
			return dataSource;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			Size display = DependencyService.Get<IFormsUtility> ().DisplaySize ();
			listView.RowHeight = Convert.ToInt16(display.Width) / 2 + 60;
			listView.HeightRequest = display.Height;
			listView.ItemsSource = LoadDataSource ();
		}
	}
}

