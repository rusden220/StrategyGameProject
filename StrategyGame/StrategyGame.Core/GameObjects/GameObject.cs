using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StrategyGame.Render;
using StrategyGame.Core.ContentProvider;

namespace StrategyGame.Core.GameObjects
{
	public abstract class GameObject : IRenderableObject
	{
		private Animator _animator;
		private Point _currentBitmapPoint;	
		
		public GameObject()
		{
			_animator = new Animator(BitmapContentLoader.LoadBitmaps("")) { isAnimatedObject = true };
			_currentBitmapPoint = new Point(10, 0);
		}
		public Bitmap GetCurrentBitmap()
		{			
			return _animator.GetNextAnimatedBitmap();			
		}
		public Point GetRenderPoint()
		{
			return _currentBitmapPoint;
		}
		public bool isActive { get; set; }

		

	}
}
