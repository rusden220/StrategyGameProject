using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace StrategyGame.Core.ContentLoader
{
	public class BitmapProvider
	{
		public static Bitmap[] LoadBitmaps(string name)
		{			
			return GetBitmapSample();
		}

#if DEBUG
		private static Bitmap[] GetBitmapSample()
		{
			var _bitmaps = new Bitmap[20];
			Size size = new Size(50, 50);
			int len = 10;
			int shift = 1;
			int y = 3;
			for (int i = 0; i < _bitmaps.Length; i++)
			{
				_bitmaps[i] = new Bitmap(size.Width, size.Height);
				GetGraphicsForBitmap(_bitmaps[i]).DrawLine(new Pen(Color.Blue, 3), shift * (i + 1), y, shift * (i + 1) + len, y);
			}
			return _bitmaps;
		}
		private static Graphics GetGraphicsForBitmap(Bitmap bitmap)
		{
			var g = Graphics.FromImage(bitmap);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			return g;
		}
#endif


	}
}
