using System;
using System.Windows.Forms;
using tsCore.Interfaces;
using tsWin;

namespace tsCore.Classes
{
	class UserActLogger : IBinaryIo, IXMLIo, IManaged
	{
		private readonly UserActivityHook _uActTracker;
		private readonly UserActLogStructure _uActLog;

		public UserActLogStructure UActLog
		{
			get { return _uActLog; }
		}

		public UserActLogger()
		{
			_uActTracker = new UserActivityHook();
			_uActLog = new UserActLogStructure();

			_uActTracker.OnMouseActivity += _uActTracker_OnMouseActivity;
			_uActTracker.KeyDown += _uActTracker_KeyDown;
		}

		private void _uActTracker_KeyDown(object sender, KeyEventArgs e)
		{
			Keys code = e.KeyCode;
			if (!_uActLog.KeyLog.ContainsKey(code))
				_uActLog.KeyLog.Add(code, 0);
			_uActLog.KeyLog[code]++;
		}

		private void _uActTracker_OnMouseActivity(object sender, MouseEventArgs e)
		{
			MouseButtons code = e.Button;
			if (!_uActLog.MouseLog.Clicks.ContainsKey(code))
				_uActLog.MouseLog.Clicks.Add(code, 0);
			_uActLog.MouseLog.Clicks[code] += e.Clicks;

			_uActLog.MouseLog.Delta += Math.Abs(e.Delta);

			if (!_uActLog.MouseLog.LastPoint.IsEmpty)
				_uActLog.MouseLog.Path += Math.Sqrt(
					(e.Y - _uActLog.MouseLog.LastPoint.Y) * (e.Y - _uActLog.MouseLog.LastPoint.Y) + 
					(e.X - _uActLog.MouseLog.LastPoint.X) * (e.X - _uActLog.MouseLog.LastPoint.X));

			_uActLog.MouseLog.LastPoint = e.Location;
		}

		public void ReadBinary(string filename)
		{
			throw new NotImplementedException();
		}

		public void WriteBinary(string filename)
		{
			throw new NotImplementedException();
		}

		public void ReadXml(string filename)
		{
			throw new NotImplementedException();
		}

		public void WriteXml(string filename)
		{
			throw new NotImplementedException();
		}

		public void Enable()
		{
			_uActTracker.Start();
		}

		public void Disable()
		{
			_uActTracker.Stop();
		}

		public void Manage(bool isEnable)
		{
			if (isEnable)
				Enable();
			else
				Disable();
		}
	}
}
