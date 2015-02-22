using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using UIKit;

[assembly:ExportRenderer(typeof(TwoColumnsListView.TwoColumnsViewCell), typeof(TwoColumnsListView.iOS.TwoColumnsViewCellRenderer))]
namespace TwoColumnsListView.iOS
{
	public class TwoColumnsViewCellRenderer : ViewCellRenderer
	{
		public TwoColumnsViewCellRenderer ()
		{
		}

		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			TwoColumnsViewCell customViewCell = item as TwoColumnsViewCell;

			var cell = base.GetCell(item, reusableCell, tv);
			if (cell != null) {

				var grid = cell.Subviews [1];
				var leftColumn = grid.Subviews [0];
				UIImageView productAImage = leftColumn.Subviews [0].Subviews [0] as UIImageView;
				productAImage.Image = UIImage.FromFile ("download.jpg");
				productAImage.UserInteractionEnabled = true;
				productAImage.AddGestureRecognizer(new UITapGestureRecognizer(tap=>{
					MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "PtoductPhoto_Tapped", customViewCell.ProductAID);
				}));
				Task.Factory.StartNew<string> ((state) => {
					return GetImageFile ("http://182.254.167.182/ProductImages/", state.ToString ());
				}, customViewCell.ProductAPhoto).
				ContinueWith ((task, state) => {
					UIImageView imageview = state as UIImageView;
					imageview.Image = UIImage.FromFile (task.Result);
				}, productAImage, TaskScheduler.FromCurrentSynchronizationContext ());
				UIImageView favoriteAIcon = leftColumn.Subviews [1].Subviews [2].Subviews [0] as UIImageView;
				favoriteAIcon.UserInteractionEnabled = true;
				favoriteAIcon.AddGestureRecognizer(new UITapGestureRecognizer(tap=>{
					MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "FavoriteIcon_Tapped", customViewCell.ProductAID);
				}));

				if (!string.IsNullOrEmpty (customViewCell.ProductBName)) {
					var rightColumn = grid.Subviews [1];
					UIImageView productBImage = rightColumn.Subviews [0].Subviews [0] as UIImageView;
					productBImage.Image = UIImage.FromFile ("download.jpg");
					productBImage.UserInteractionEnabled = true;
					productBImage.AddGestureRecognizer(new UITapGestureRecognizer(tap=>{
						MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "PtoductPhoto_Tapped", customViewCell.ProductBID);
					}));

					Task.Factory.StartNew<string> ((state) => {
						return GetImageFile ("http://182.254.167.182/ProductImages/", state.ToString ());
					}, customViewCell.ProductBPhoto).
					ContinueWith ((task, state) => {
						UIImageView imageview = state as UIImageView;
						imageview.Image = UIImage.FromFile (task.Result);
					}, productBImage, TaskScheduler.FromCurrentSynchronizationContext ());
						
					UIImageView favoriteBIcon = rightColumn.Subviews [1].Subviews [2].Subviews [0] as UIImageView;
					favoriteBIcon.UserInteractionEnabled = true;
					favoriteBIcon.AddGestureRecognizer(new UITapGestureRecognizer(tap=>{
						MessagingCenter.Send<MainPage, int> (MainPage.GetInstance(), "FavoriteIcon_Tapped", customViewCell.ProductBID);
					}));

				} else {
					UIImageView productBImage = cell.Subviews [1].Subviews [1].Subviews [0].Subviews [0] as UIImageView;
					productBImage.Image = null;
				}
			}
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
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
	}
}

