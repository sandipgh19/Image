using Foundation;
using System;
using UIKit;

namespace Image.iOS
{
    public partial class PhotoCollectionImageCell : UICollectionViewCell
    {
        public PhotoCollectionImageCell (IntPtr handle) : base (handle)
        {

        }

		public void SetImage(UIImage image)
		{
			cellImageView.Image = image;
		}
    }
}