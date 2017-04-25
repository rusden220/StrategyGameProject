using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using StrategyGame.Render;
using StrategyGame.Core.GameObjects;


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

		private const int AMOUNT_FPS = 1000 / 100;

		private System.Windows.Forms.Timer _timer;
		private Stopwatch _stopwatch;
		private RenderFlow _render;
		private GameObject[] _gameObjects;

		private FpsCounter _fpsCounter;

		public MainGameFlow(IRenderableFom form)
		{
			_timer = new System.Windows.Forms.Timer();
			_timer = new System.Windows.Forms.Timer() { Interval = AMOUNT_FPS };
			_timer.Tick += TimerTick;

			_stopwatch = new Stopwatch();

			_render = new RenderFlow(form);

			_gameObjects = new GameObject[1] { new Building() };

			_fpsCounter = new FpsCounter();
		}

		public void StartGame()
		{
			_stopwatch.Start();
			_timer.Start();			
		}


		private void TimerTick(object sender, EventArgs e)
		{
			MainGameLoop(_stopwatch.ElapsedMilliseconds);
		}

		private void MainGameLoop(long time)
		{			
			_render.Draw(_gameObjects);
			_fpsCounter.SetTime(_stopwatch.ElapsedMilliseconds);
			_render.DrawFps(_fpsCounter.GetFps());
		}
	}
}
