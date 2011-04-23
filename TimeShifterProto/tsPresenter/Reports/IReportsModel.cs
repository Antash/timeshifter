using System.Data;
using tsPresenter.Base;

namespace tsPresenter.Reports
{
	public interface IReportsModel : IModel
	{
		DataSet ReportDataSet { get; }
	}
}
