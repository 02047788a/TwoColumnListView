using System;

using Xamarin.Forms;
using System.Windows.Input;

namespace TwoColumnsListView
{
	public class TwoColumnsViewCell : ViewCell
	{
		public TwoColumnsViewCell ()
		{
			this.SetBinding (TwoColumnsViewCell.ProductAIDProperty, "ProductA.ID");
			this.SetBinding (TwoColumnsViewCell.ProductANameProperty, "ProductA.Name");
			this.SetBinding (TwoColumnsViewCell.ProductAPhotoProperty, "ProductA.PhotoURL");
			this.SetBinding (TwoColumnsViewCell.ProductAPriceProperty, "ProductA.Price");

			this.SetBinding (TwoColumnsViewCell.ProductBIDProperty, "ProductB.ID");
			this.SetBinding (TwoColumnsViewCell.ProductBNameProperty, "ProductB.Name");
			this.SetBinding (TwoColumnsViewCell.ProductBPhotoProperty, "ProductB.PhotoURL");
			this.SetBinding (TwoColumnsViewCell.ProductBPriceProperty, "ProductB.Price");
		}

		public static readonly BindableProperty ProductAIDProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductAID, 0);

		public int ProductAID {
			get {
				return (int)GetValue (ProductAIDProperty);
			}
			set {
				SetValue (ProductAIDProperty, value);
			}
		}

		public static readonly BindableProperty ProductANameProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductAName, "N/A");

		public string ProductAName {
			get {
				return (string)GetValue (ProductANameProperty);
			}
			set {
				SetValue (ProductANameProperty, value);
			}
		}

		public static readonly BindableProperty ProductAPhotoProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductAPhoto, "download.jpg");

		public string ProductAPhoto {
			get {
				return (string)GetValue (ProductAPhotoProperty);
			}
			set {
				SetValue (ProductAPhotoProperty, value);
			}
		}
			
		public static readonly BindableProperty ProductAPriceProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductAPrice, 0.0);

		public double ProductAPrice {
			get {
				return (double)GetValue (ProductAPriceProperty);
			}
			set {
				SetValue (ProductAPriceProperty, value);
			}
		}

		public static readonly BindableProperty ProductBIDProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductBID, 0);

		public int ProductBID {
			get {
				return (int)GetValue (ProductBIDProperty);
			}
			set {
				SetValue (ProductBIDProperty, value);
			}
		}

		public static readonly BindableProperty ProductBNameProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductBName, "N/A");

		public string ProductBName {
			get {
				return (string)GetValue (ProductBNameProperty);
			}
			set {
				SetValue (ProductBNameProperty, value);
			}
		}

		public static readonly BindableProperty ProductBPhotoProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductBPhoto, "download.jpg");

		public string ProductBPhoto {
			get {
				return (string)GetValue (ProductBPhotoProperty);
			}
			set {
				SetValue (ProductBPhotoProperty, value);
			}
		}

		public static readonly BindableProperty ProductBPriceProperty = 
			BindableProperty.Create ((TwoColumnsViewCell c) => c.ProductBPrice, 0.0);

		public double ProductBPrice {
			get {
				return (double)GetValue (ProductBPriceProperty);
			}
			set {
				SetValue (ProductBPriceProperty, value);
			}
		}
	}
}


