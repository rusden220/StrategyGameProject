using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StrategyGame.Render
{
	public class Animator
	{
		private Bitmap[] _bitmaps;
		private int _index;
		public Animator(Bitmap[] bitmaps)
		{
			_bitmaps = bitmaps;
			_index = 0;
		}
		public bool isAnimatedObject { get; set; }
		public  Bitmap GetNextAnimatedBitmap()
		{
			int i = GetNextIndex();
			return _bitmaps[i];
		}
		private int GetNextIndex()
		{
			if (isAnimatedObject)
			{
				if (_index == _bitmaps.Length)
					_index = 0;
				return _index++;
			}
			else
				return 0;
		}
	}
}
