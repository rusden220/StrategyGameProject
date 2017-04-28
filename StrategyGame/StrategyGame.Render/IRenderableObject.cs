using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StrategyGame.Render
{
	public interface IRenderableObject
	{
		Bitmap GetCurrentBitmap();
		Point GetRenderPoint();
	}
}
