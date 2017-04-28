using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using StrategyGame.Render;
using StrategyGame.Core.ContentProvider;


namespace StrategyGame.Core.Menu
{

	public interface IGameMenuArea
	{
		bool isMouseInMenu(Point point);
	}
	public abstract class GameMenuItem : IRenderableObject
	{
		protected Point _renderPoint;
		protected Bitmap _bitmap;
		public Point GetRenderPoint()
		{
			return _renderPoint;
		}
		public Bitmap GetCurrentBitmap()
		{
			return _bitmap;
		}
		bool isMouseInMenu(Point point)
		{
			return false;
		}
	}
	public class GameMenu: GameMenuItem, IGameMenuArea
	{
		private const int START_INDEX_TO_GET_MOUSE_POSITION = 1;

		private List<IGameMenuArea> _gameMenu;
		private Size _mainMenuRanderSize;

		public GameMenu(Size mainRanderSize)
		{
			_renderPoint = new Point(mainRanderSize.Height * 2 / 3, 0);
			_mainMenuRanderSize = new Size(mainRanderSize.Width, mainRanderSize.Height - _renderPoint.Y);
			_gameMenu = new List<IGameMenuArea>() { this };// START_INDEX_TO_GET_MOUSE_POSITION = 1 because of this
		}
		public void LoadContent(FileContent fc)
		{

		}
		public bool isMouseInMenu(Point point)
		{
			var result = false;
			for (int i = START_INDEX_TO_GET_MOUSE_POSITION; i < _gameMenu.Count; i++)
			{

			}
			return result;
		}
		public Size GetMenuSize()
		{
			return _mainMenuRanderSize;
		}
		
				
	}
}
