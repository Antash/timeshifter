using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsPresenter.Reports;

namespace tsUI.Forms
{
	public partial class FrmReport : Form, IReportsView
	{
		public FrmReport()
		{
			InitializeComponent();
		}

		public DataTable ReportDataSet
		{
			set { gvReport.DataSource = value; }
		}
	}
}
