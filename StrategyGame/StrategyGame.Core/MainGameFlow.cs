using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

using StrategyGame.Render;
using StrategyGame.Core.GameObjects;
using StrategyGame.Core.Menu;
using StrategyGame.Core.ContentProvider;
using StrategyGame.Engine;


namespace StrategyGame.Core
{
	public class MainGameFlow
	{
		private class FpsCounter
		{
			private int _previousFps;

			private int _count;
			private long _time;
			private long _timeP;


			public void SetTime(long time)
			{
				_time += time - _timeP;
				_timeP = time;
				_count++;
			}
			public int GetFps()
			{
				if (_time > 500)
				{
					_previousFps = _count * 2;
					_count = 0;
					_time = 0;					
				}
				return _previousFps;
			}
		}

		private const int AMOUNT_FPS = 1000 / 100;//should be 1000/60, but fps will be 40

		private FpsCounter _fpsCounter;

		private System.Windows.Forms.Timer _timer;
		private Stopwatch _stopwatch;
		private RenderFlow _render;
		private EngineFlow _gameEngine;
		private GameObject[] _gameObjects;
		//private GameMenu _gameMenu;
		

		public MainGameFlow(IRenderableFom form)
		{
			_timer = new System.Windows.Forms.Timer();
			_timer = new System.Windows.Forms.Timer() { Interval = AMOUNT_FPS };
			_timer.Tick += TimerTick;

			_stopwatch = new Stopwatch();
			var renderSize = form.GetRenderSize();
			_render = new RenderFlow(form, new RenderFlowSettings() {
				MainRenderSize = renderSize, GameLayerSize = new Size(), MenuLayerSize = new Size() });
			_gameObjects = new GameObject[1] { new Building() };
			_fpsCounter = new FpsCounter();
		}
		public void LoadContent()
		{
			ContentLoader cl = new ContentLoader();
			
			//_gameEngine.LoadContent();
			//var content = cl.LoadGameData();

		}
		public void StartGame()
		{
			_stopwatch.Start();
			_timer.Start();
		}

		private void MainGameLoop()
		{
			_render.DrawGameObjects(_gameObjects);
			//_render.DrawMenuLayer(_gameMenu);
			_render.Render();
#if DEBUG
			UpdateFpsCounter();
#endif
		}		
		
		private void TimerTick(object sender, EventArgs e)
		{
			MainGameLoop();
		}
		private void UpdateFpsCounter()
		{
			_fpsCounter.SetTime(_stopwatch.ElapsedMilliseconds);
			_render.DrawFps(_fpsCounter.GetFps());
		}
		public void MouseUp(MouseEventArgs e)
		{
			MainGameLoop();
		}
		public void MouseDown(MouseEventArgs e)
		{
			MainGameLoop();
		}
	}
}
