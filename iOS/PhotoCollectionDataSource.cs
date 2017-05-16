using System;
using UIKit;
namespace Image.iOS
{
	public class PhotoCollectionDataSource :UICollectionViewDataSource
	{
		private static readonly string photoCellIdentifier = "ImageCellIdentifier";
		public PhotoCollectionDataSource()
		{
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView,
		NSIndexPath indexPath)
		{
			var imageCell = collectionView.DequeueReusableCell(photoCellIdentifier, indexPath)
   							as PhotoCollectionImageCell;

			return imageCell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return 7;
		}
	}
}
