using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tsPresenter
{
	public class TaskManagementPresenter
	{
		private readonly ITaskManagementView _view;
		private readonly ITaskManagementService _service;

		public TaskManagementPresenter(ITaskManagementView view,
									ITaskManagementService service)
		{
			_view = view;
			_service = service;
		}
	}
}
