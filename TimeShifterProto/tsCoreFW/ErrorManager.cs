using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tsCoreFW
{
	public class ErrorManager
	{
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

		protected ErrorManager()
		{
			ShowErrors = true;
		}

		private FrmErr _errForm;
		public bool ShowErrors { get; set; }

		public void RiseError(string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errMsg);
			
			if (ShowErrors)
			{
				new Thread(() => _errForm.ShowDialog()).Start();
			}
		}

		public void RiseError(string errModule, string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errModule, errMsg);

			if (ShowErrors)
			{
				new Thread(() => _errForm.ShowDialog()).Start();
			}
		}
	}
}
