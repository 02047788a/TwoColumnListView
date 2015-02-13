using System;
using Xamarin.Forms;
using UIKit;

[assembly: Xamarin.Forms.Dependency (typeof (TwoColumnsListView.iOS.iOSUtility))]
namespace TwoColumnsListView.iOS
{
	public class iOSUtility : IFormsUtility
	{
		public iOSUtility ()
		{
		}

		public Size DisplaySize()
		{
			return new Size (
				UIScreen.MainScreen.Bounds.Size.Width,
				UIScreen.MainScreen.Bounds.Size.Height);
		}
	}
}

