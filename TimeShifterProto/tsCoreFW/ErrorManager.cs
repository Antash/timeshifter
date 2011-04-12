using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
		}

		private FrmErr _errForm;

		public void RiseError(string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errMsg);
			Application.Run(_errForm);
			//_errForm.Show();
		}

		public void RiseError(string errModule, string errMsg)
		{
			_errForm = new FrmErr();
			_errForm.Init(errModule, errMsg);
			Application.Run(_errForm);
			//_errForm.Show();
		}
	}
}
