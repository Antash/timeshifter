﻿using System;
using tsPresenter.Base;
using tsPresenter.Settings;

namespace tsPresenter.Reports
{
	public class ReportsPresenter : Presenter
	{
		public ReportsPresenter(
			IReportsModel model, 
			IReportsView view) 
			: base(model, view)
		{
			Initialize();
		}

		protected override void WireUpEvents()
		{
		}

		protected override sealed void Initialize()
		{
			SetViewPropertiesFromModel();
			WireUpEvents();
		}
	}
}
