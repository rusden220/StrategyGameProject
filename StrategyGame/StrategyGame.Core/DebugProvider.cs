using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StrategyGame.Core
{
	public class DebugProvider
	{
		private static long previousTime;
		public static void WriteTimeInterval(string str, long time)
		{			
			WriteLine(str + " " + (time - previousTime).ToString());
			previousTime = time;
		}
		public static void WriteLine(string str)
		{
			Debug.WriteLine(str);
		}
	}
}
