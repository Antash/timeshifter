using System;
using tsPresenter.Base;

namespace tsPresenter.TaskManagement
{
	public class TaskManagementPresenter : Presenter 
	{
		public TaskManagementPresenter(
			ITaskManagementModel model, 
			ITaskManagementView view) 
			: base(model, view)
		{
			Initialize();
		}

		protected override void WireUpEvents()
		{
			((ITaskManagementModel) Model).NewApplication += ModelNewApplication;
			((ITaskManagementView) View).Save += ViewSave;
		}

		protected override sealed void Initialize()
		{
			SetViewPropertiesFromModel();
			WireUpEvents();
		}

		void ViewSave(object sender, EventArgs e)
		{
			SetModelPropertiesFromView();
		}

		void ModelNewApplication(object sender, NewApplicationHandlerArgs args)
		{
			((ITaskManagementView)View).AddNewApplication(args.App);
		}
	}
}
