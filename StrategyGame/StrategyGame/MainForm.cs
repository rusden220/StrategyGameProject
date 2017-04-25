using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StrategyGame.Render;
using StrategyGame.Core;

namespace StrategyGame
{
	public partial class MainForm : Form, IRenderableFom
	{
		private Bitmap _mainBitmap;
		private MainGameFlow _mainGameFlow;
		public MainForm()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			_mainGameFlow = new MainGameFlow(this);
			_mainGameFlow.StartGame();
			_mainBitmap = new Bitmap(10,10);
		}

		public void Redraw(Bitmap bitmap)
		{
			_mainBitmap = bitmap;
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(_mainBitmap, 0, 0);
			base.OnPaint(e);
		}
		public Size GetRenderSize()
		{
			return this.ClientRectangle.Size;
		}
		public void DrawFps(int fps)
		{
			this.Text = fps.ToString();
		}
	}
}
