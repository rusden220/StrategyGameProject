using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using StrategyGame.Render;


namespace StrategyGame.Core.GameObjects
{
	public class BitmapGameContentContainer
	{
		public Animator Animation { get; set; }
	}
	public class BitmapMenuContentContainer
	{
		/// <summary>
		/// button is available
		/// </summary>
		public Bitmap Available { get; set; }
		/// <summary>
		/// button is disable
		/// </summary>
		public Bitmap Disable { get; set; }
		/// <summary>
		/// button is pushed
		/// </summary>
		public Bitmap Push { get; set; }
	}
	public class BitmapContentContainer
	{
		public BitmapGameContentContainer GameBitmap { get; set; }
		public BitmapMenuContentContainer MenuBitmap { get; set; }
		public string Name { get; set; }
	}
}
