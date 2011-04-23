using System.Data;
using tsPresenter.Base;

namespace tsPresenter.Reports
{
	public interface IReportsView : IView
	{
		DataSet ReportDataSet { set; }
	}
}
