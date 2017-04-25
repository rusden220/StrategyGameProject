using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StrategyGame.Render;
using StrategyGame.Core.ContentLoader;

namespace StrategyGame.Core.GameObjects
{
	public abstract class GameObject : IRenderableObject
	{
		private Animator _animator;
		private Point _currentBitmapPoint;
		
		public GameObject()
		{
			_animator = new Animator(BitmapProvider.LoadBitmaps("")) { isAnimatedObject = true };
			_currentBitmapPoint = new Point(10, 0);
		}
		public Bitmap GetCurrentBitmap()
		{
			return _animator.GetNextAnimatedBitmap();
		}
		public Point GetBitmapPoint()
		{
			return _currentBitmapPoint;
		}


		

	}
}
