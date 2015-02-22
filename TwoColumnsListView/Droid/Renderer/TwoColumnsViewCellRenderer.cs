using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.Views;
using Android;

[assembly:ExportRenderer(typeof(TwoColumnsListView.TwoColumnsViewCell), typeof(TwoColumnsListView.Droid.TwoColumnsViewCellRenderer))]
namespace TwoColumnsListView.Droid
{
	public class TwoColumnsViewCellRenderer : ViewCellRenderer
	{ 
		public TwoColumnsViewCellRenderer ()
		{
		}
			
		protected override global::Android.Views.View GetCellCore (
			Xamarin.Forms.Cell item,
			global::Android.Views.View convertView, 
			global::Android.Views.ViewGroup parent, 
			global::Android.Content.Context context)
		{
			TwoColumnsViewCell customViewCell = item as TwoColumnsViewCell;

			var cell = base.GetCellCore (item, convertView, parent, context) as ViewGroup;
			if (cell != null) {

				var grid = (cell.GetChildAt (0) as ViewGroup); // 2 columns

				var leftColumn = grid.GetChildAt (0) as ViewGroup; // Image + Text + Text
				var productAImage = (leftColumn.GetChildAt (0)  as ViewGroup).GetChildAt(0) as ImageView;
				productAImage.SetImageResource (TwoColumnsListView.Droid.Resource.Drawable.download);
				productAImage.SetOnClickListener (new ProductPhotoClickListener(){ ProductID = customViewCell.ProductAID});

				Task.Factory.StartNew<string> ((state) => {
					return GetImageFile ("http://182.254.167.182/ProductImages/", state.ToString());
				}, customViewCell.ProductAPhoto).
				ContinueWith ((task, state)=> {
					ImageView imageview = state as ImageView;
					using (Bitmap bitmapToDisplay = BitmapFactory.DecodeFile (task.Result)) {
						imageview.SetImageBitmap (bitmapToDisplay);
					}
				}, productAImage, TaskScheduler.FromCurrentSynchronizationContext ());

				var favoriteAIcon = ((leftColumn.GetChildAt (1) as ViewGroup).GetChildAt (2) as ViewGroup).GetChildAt (0) as ImageView;
				favoriteAIcon.SetOnClickListener (new FavoriteIconClickListener(){ ProductID = customViewCell.ProductAID});


				if (!string.IsNullOrEmpty (customViewCell.ProductBName)) {
					var rightColumn = grid.GetChildAt (1) as ViewGroup; // Image + Text + Text
					var productBImage = (rightColumn.GetChildAt (0)  as ViewGroup).GetChildAt (0) as ImageView;
					productBImage.SetImageResource (TwoColumnsListView.Droid.Resource.Drawable.download);
					productBImage.SetOnClickListener (new ProductPhotoClickListener(){ ProductID = customViewCell.ProductBID});

					Task.Factory.StartNew<string> ((state) => {
						return GetImageFile ("http://182.254.167.182/ProductImages/", state.ToString ());
					}, customViewCell.ProductBPhoto).
					ContinueWith ((task, state) => {
						ImageView imageview = state as ImageView;
						using (Bitmap bitmapToDisplay = BitmapFactory.DecodeFile (task.Result)) {
							imageview.SetImageBitmap (bitmapToDisplay);
						}
					}, productBImage, TaskScheduler.FromCurrentSynchronizationContext ());
						
					var favoriteBIcon = ((rightColumn.GetChildAt (1) as ViewGroup).GetChildAt (2) as ViewGroup).GetChildAt (0) as ImageView;
					favoriteBIcon.SetOnClickListener (new FavoriteIconClickListener(){ ProductID = customViewCell.ProductBID});

				} else {
					var rightColumn = grid.GetChildAt (1) as ViewGroup;
					var productPhoto = (rightColumn.GetChildAt (0)  as ViewGroup).GetChildAt (0) as ImageView;
					productPhoto.SetImageBitmap (null);
				}
			}

			cell.SetBackgroundColor (global::Android.Graphics.Color.White);
			return cell;
		}

		public string GetImageFile(string url, string fileName)
		{
			string path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			path = System.IO.Path.Combine (path, "ImageCache");
			if (!Directory.Exists (path))
				Directory.CreateDirectory (path);

			string filePath = System.IO.Path.Combine (path, fileName);
			if (!File.Exists (filePath)) {
				using (var webClient = new WebClient ()) {
					webClient.DownloadFile (url + fileName, filePath);
				}
			}

			if (File.ReadAllBytes (filePath).Length == 0)
				Console.WriteLine ("{0} size is 0", fileName);

			return filePath;
		}

		public void OnClick (global::Android.Views.View v)
		{
			Console.WriteLine ("Image OnClick");
		}
	}
}

