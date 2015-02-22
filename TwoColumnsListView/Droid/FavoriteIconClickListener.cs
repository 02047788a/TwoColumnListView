
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
	[Activity (Label = "FavoriteIconClickListener")]			
	public class FavoriteIconClickListener : Activity, global::Android.Views.View.IOnClickListener
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
		}

		public int ProductID { get; set;}
		public void OnClick (global::Android.Views.View v)
		{
			(v as ImageView).SetImageResource (Resource.Drawable.heart2);
			MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "FavoriteIcon_Tapped", this.ProductID);
		}
	}
}

