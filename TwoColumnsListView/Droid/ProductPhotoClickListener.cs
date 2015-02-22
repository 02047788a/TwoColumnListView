
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace TwoColumnsListView.Droid
{
	[Activity (Label = "ProductPhotoClickListener")]			
	public class ProductPhotoClickListener : Activity, global::Android.Views.View.IOnClickListener
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
		}
			
		//int productId;
		public int ProductID { get; set;}
		public void OnClick (global::Android.Views.View v)
		{
			MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "PtoductPhoto_Tapped", this.ProductID);
		}
	}
}

