using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.IO;

using StrategyGame.Core.GameObjects;


namespace StrategyGame.Core.ContentProvider
{
	public class ContentLoader
	{
		private Bitmap _emptyBitmap;
		public ContentLoader()
		{
			_emptyBitmap = GetEmptyBitmap();
		}		
		public FileContent LoadData(string name)
		{
			var result = new FileContent();
			result.Bitmap = GetBitmapFromFile(name + @"/image.png");
			result.Settings = GetSettingFromFile(name + @"/settings.txt");
			return result;
		}
		private Bitmap GetBitmapFromFile(string name)
		{
			try
			{
				return (Bitmap)Bitmap.FromFile(name);
			}
			catch (Exception ex)
			{
				Debug.Fail(ex.Message);
				return new Bitmap(_emptyBitmap);				
			}
			
		}
		private string GetSettingFromFile(string name)
		{
			try
			{
				using (StreamReader sr = new StreamReader(name))
					return sr.ReadToEnd();
			}
			catch (Exception ex)
			{
				Debug.Fail(ex.Message);
				return "";
			}			
		}
		private Bitmap GetEmptyBitmap()
		{
			var result = new Bitmap(10, 10);
			Graphics.FromImage(result).Clear(Color.Red);
			return result;
		}
	}
	[Obsolete]
	public class BitmapContentLoader
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
