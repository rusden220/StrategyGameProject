using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StrategyGame.Render
{
    public class RenderFlow
    {
		private IRenderableFom _renderForm;
		private Bitmap _mainBitmap;
		public RenderFlow(IRenderableFom form)
		{
			_renderForm = form;
			_mainBitmap = new Bitmap(form.GetRenderSize().Width, form.GetRenderSize().Height);
		}
		public void Draw(IRenderableObject[] objects)
		{
			DrawRenderableObject(objects);
			_renderForm.Redraw(_mainBitmap);
		}
		public void DrawFps(int fps)
		{
			_renderForm.DrawFps(fps);
		}
		private void DrawRenderableObject(IRenderableObject[] objects)
		{
			var g = Graphics.FromImage(_mainBitmap);
			g.Clear(Color.White);
			foreach (var obj in objects)
				g.DrawImage(obj.GetCurrentBitmap(), obj.GetBitmapPoint());
		}

	}
}
