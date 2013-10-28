using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using tsCore.Interfaces;
using tsCoreStructures;
using tsWin;
using Timer = System.Threading.Timer;

namespace tsCore.Classes
{
	class UserActLogger : IBinaryIo, IManaged
	{
		internal delegate void SnapshotReadyHandler(object sender, SnapshotReadyHandlerArgs args);

		internal class SnapshotReadyHandlerArgs
		{
			public UserActLog UActLog { get; set; }

			public SnapshotReadyHandlerArgs(UserActLog uActLog)
			{
				UActLog = uActLog;
			}
		}

		public event SnapshotReadyHandler SnapshotReady;

		public void InvokeSnapshotReady(SnapshotReadyHandlerArgs args)
		{
			SnapshotReadyHandler handler = SnapshotReady;
			if (handler != null) handler(this, args);
		}

		private readonly UserActivityHook _uActTracker;
		
		private Timer _t1;
		private const long TickPeriod = 10000;

		public UserActLog UActLog { get; set; }

		public UserActLogger()
		{
			_uActTracker = new UserActivityHook(false, false);
			UActLog = new UserActLog();

			_uActTracker.OnMouseActivity += _uActTracker_OnMouseActivity;
			_uActTracker.KeyDown += UActTrackerKeyDown;
		}

		private void UActTrackerKeyDown(object sender, KeyEventArgs e)
		{
			Keys code = e.KeyCode;
			if (!UActLog.KeyLog.ContainsKey(code))
				UActLog.KeyLog.Add(code, 0);
			UActLog.KeyLog[code]++;
		}

		private void _uActTracker_OnMouseActivity(object sender, MouseEventArgs e)
		{
			MouseButtons code = e.Button;
			if (!UActLog.MouseLog.Clicks.ContainsKey(code))
				UActLog.MouseLog.Clicks.Add(code, 0);
			UActLog.MouseLog.Clicks[code] += e.Clicks;

			UActLog.MouseLog.Delta += Math.Abs(e.Delta);

			if (!UActLog.MouseLog.LastPoint.IsEmpty)
				UActLog.MouseLog.Path += Math.Sqrt(
					(e.Y - UActLog.MouseLog.LastPoint.Y) * (e.Y - UActLog.MouseLog.LastPoint.Y) + 
					(e.X - UActLog.MouseLog.LastPoint.X) * (e.X - UActLog.MouseLog.LastPoint.X));

			UActLog.MouseLog.LastPoint = e.Location;
		}

		public void ReadBinary(string filename)
		{
			using (Stream stream = File.Open(filename, FileMode.Open))
			{
				var bin = new BinaryFormatter();
				var tmp = (UserActLog)bin.Deserialize(stream);
				UActLog = tmp;
			}
		}

		public void WriteBinary(string filename)
		{
			using (Stream stream = File.Open(filename, FileMode.Create))
			{
				var bin = new BinaryFormatter();
				bin.Serialize(stream, UActLog);
			}
		}

		private void TimerTick(object state)
		{
			InvokeSnapshotReady(new SnapshotReadyHandlerArgs(UActLog));
		}

		public void Enable()
		{
			var autoEvent = new AutoResetEvent(false);
			_t1 = new Timer(TimerTick, autoEvent, TickPeriod, TickPeriod);
			_uActTracker.Start();
		}

		public void Disable()
		{
			_uActTracker.Stop();
			_t1.Dispose();
		}
	}
}
