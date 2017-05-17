using System;
using UIKit;
using Photos;
namespace Image.iOS
{
	public class PhotoCollectionDataSource :UICollectionViewDataSource
	{
		private static readonly string photoCellIdentifier = "ImageCellIdentifier";
		private PHFetchResult imageFetchResult;
		private PHImageManager imageManager;
		public PhotoCollectionDataSource()
		{
			imageFetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
			imageManager = new PHImageManager();
		}


		public override UICollectionViewCell GetCell(UICollectionView collectionView,
		NSIndexPath indexPath)
		{
			var imageCell = collectionView.DequeueReusableCell(photoCellIdentifier, indexPath)
			as PhotoCollectionImageCell;

			// 1
			var imageAsset = imageFetchResult[indexPath.Item] as PHAsset;

			// 2
			imageManager.RequestImageForAsset(imageAsset,
			new CoreGraphics.CGSize(100.0, 100.0), PHImageContentMode.AspectFill,
			new PHImageRequestOptions(),
			 // 3
		 	(UIImage image, NSDictionary info) =>
			{
				// 4
				imageCell.SetImage(image);
			});

			return imageCell;
		}

		public void ReloadPhotos()
		{
			imageFetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
		}
	}
}
