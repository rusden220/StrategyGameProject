using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StrategyGame.Render
{
	public class RenderFlowSettings
	{
		public Size GameLayerSize { get; set; }
		public Size MenuLayerSize { get; set; }
		public Point MenuLayerPointRendering { get; set; }
		public Size MainRenderSize { get; set; }
	}
    public class RenderFlow
    {
		private IRenderableFom _renderForm;
		private Bitmap _gameLayerBitmap;
		private Bitmap _menuLayerBitmap;
		private Bitmap _mainBitmap;
		private RenderFlowSettings _renderFlowSettings;
		public RenderFlow(IRenderableFom form, RenderFlowSettings rfs)
		{
			_renderForm = form;
			_renderFlowSettings = rfs;
			_mainBitmap = new Bitmap(rfs.MainRenderSize.Width, rfs.MainRenderSize.Height);
			_gameLayerBitmap = new Bitmap(rfs.GameLayerSize.Width, rfs.GameLayerSize.Height);
			_menuLayerBitmap = new Bitmap(rfs.MenuLayerSize.Width, rfs.MenuLayerSize.Height);
		}
		public void DrawGameObjects(IRenderableObject[] objects)
		{
			DrawRenderableObject(objects);			
		}
		public void DrawMenuLayer(IRenderableObject[] objects)
		{

		}
		public void Render()
		{
			_renderForm.Redraw(_gameLayerBitmap);
		}
		public void DrawFps(int fps)
		{
			_renderForm.DrawFps(fps);
		}
		private void DrawRenderableObject(IRenderableObject[] objects)
		{
			var g = Graphics.FromImage(_gameLayerBitmap);
			g.Clear(Color.White);
			foreach (var obj in objects)
				g.DrawImage(obj.GetCurrentBitmap(), obj.GetRenderPoint());
			g.DrawImage(_menuLayerBitmap, 10, 10);		
		}
	}
}
