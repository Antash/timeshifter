using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using tsCore.Interfaces;
using tsCoreStructures;
using tsWin;

namespace tsCore.Classes
{
	class UserActLogger : IBinaryIo, IManaged
	{
		private readonly UserActivityHook _uActTracker;

		public UserActLogStructure UActLog { get; set; }

		public UserActLogger()
		{
			_uActTracker = new UserActivityHook();
			UActLog = new UserActLogStructure();

			_uActTracker.OnMouseActivity += _uActTracker_OnMouseActivity;
			_uActTracker.KeyDown += _uActTracker_KeyDown;
		}

		private void _uActTracker_KeyDown(object sender, KeyEventArgs e)
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
				var tmp = (UserActLogStructure)bin.Deserialize(stream);
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

		public void Enable()
		{
			_uActTracker.Start();
		}

		public void Disable()
		{
			_uActTracker.Stop();
		}
	}
}
