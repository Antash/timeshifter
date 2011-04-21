using System;
using tsCoreStructures;
using tsCoreStructures.Base;
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
			((ITaskManagementModel)Model).NewApplication += ModelNewApplication;
			((ITaskManagementView)View).Save += ViewSave;
			((ITaskManagementView)View).NewTask += ViewAddNewTask;
			((ITaskManagementView)View).NewSettings += ViewAddNewSettings;
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

		void ModelNewApplication(object sender, TsApplication.NewApplicationHandlerArgs args)
		{
			((ITaskManagementView)View).AddNewApplication(args.App);
		}

		void ViewAddNewTask(object sender, TsTask.NewTaskHandlerArgs args)
		{
			((ITaskManagementModel)Model).AddNewTask(args.Task);
		}

		void ViewAddNewSettings(object sender, AssociativeBaseStruct.AssociativeHandlerArgs args)
		{
			((ITaskManagementModel)Model).AddNewSetting(args);
		}
	}
}
