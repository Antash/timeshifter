using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace tsCoreFW
{
	public class ErrorManager
	{
		[Serializable]
		struct ErrorLogItem
		{
			public DateTime Time { get; set; }
			public string Assembly { get; set; }
			public string Msg { get; set; }

			public ErrorLogItem(DateTime time, string assm, string message) : this()
			{
				Time = time;
				Assembly = assm;
				Msg = message;
			}
		}

		private static volatile ErrorManager _instance;
		private static readonly object SyncRoot = new Object();

		public static ErrorManager Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new ErrorManager();
					}
				}
				return _instance;
			}
		}

		StreamWriter _memoryStream;
		protected ErrorManager()
		{
			ShowErrors = false;
			
		}

		private FrmErr _errForm;
		private const string Path = "err.log";
		public bool ShowErrors { get; set; }

		public void RiseError(string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errMsg);
			_memoryStream = new StreamWriter(Path, true);
			_memoryStream.WriteLine(DateTime.Now + " " + errMsg);
			_memoryStream.Close();
			if (ShowErrors)
			{
				new Thread(() => _errForm.ShowDialog()).Start();
			}
		}

		public void RiseError(string errModule, string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errModule, errMsg);
			_memoryStream = new StreamWriter(Path, true);
			_memoryStream.WriteLine(DateTime.Now + " " + errModule + " " + errMsg);
			_memoryStream.Close();
			if (ShowErrors)
			{
				new Thread(() => _errForm.ShowDialog()).Start();
			}
		}
	}
}
