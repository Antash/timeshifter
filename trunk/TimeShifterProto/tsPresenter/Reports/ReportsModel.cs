using System;
using System.Data;
using tsCore.Classes;

namespace tsPresenter.Reports
{
	public class ReportsModel : IReportsModel
	{
		private DataTable _repDs;

		public ReportsModel()
		{
			Update();
		}

		public DataTable ReportDataSet
		{
			get { return _repDs; }
		}

		public void Update()
		{
			_repDs = TsAppCore.Instance.CreateReport();
		}
	}
}
