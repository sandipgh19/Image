using System;

using UIKit;
using Photos;

namespace Image.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;
		private PhotoCollectionDataSource photoDataSource;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			/*// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				var title = string.Format("{0} clicks!", count++);
				Button.SetTitle(title, UIControlState.Normal);
			};*/

			photoDataSource = new PhotoCollectionDataSource();
			collectionView.DataSource = photoDataSource;

			// 1
			PHPhotoLibrary.SharedPhotoLibrary.RegisterChangeObserver((changeObserver) =>
			{
				//2
				InvokeOnMainThread(() =>
    			{
      				  // 3
       				 photoDataSource.ReloadPhotos();
        				collectionView.ReloadData();
    			});
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
