using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency (typeof (TwoColumnsListView.Droid.DroidUtility))]
namespace TwoColumnsListView.Droid
{
	public class DroidUtility : IFormsUtility
	{
		public DroidUtility ()
		{
		}

		public Size DisplaySize()
		{
			var metrics = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics;
			var widthInDp = (int) ((metrics.WidthPixels)/ Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density);
			var heightInDp = (int) ((metrics.HeightPixels)/ Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density);
		
			return new Size (widthInDp, heightInDp);
		}
	}
}

