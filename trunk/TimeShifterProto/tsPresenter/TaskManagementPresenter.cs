using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace tsPresenter
{
	public class TaskManagementPresenter
	{
		private readonly ITaskManagementView _view;
		private readonly ITaskManagementModel _model;

		public TaskManagementPresenter(ITaskManagementView view, ITaskManagementModel model)
		{
			_view = view;
			_model = model;
		}

		private void WireUpViewEvents()
		{
			_model.rebing += new newapp(_model_rebing);
		}

		void _model_rebing(object sender, EventArgs args)
		{
			//SetViewPropertiesFromModel();
		}

		private void SetModelPropertiesFromView()
		{
			foreach (PropertyInfo viewProperty in _view.GetType().GetProperties())
			{
				if (viewProperty.CanRead)
				{
					PropertyInfo modelProperty = _model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
					{
						object valueToAssign = Convert.ChangeType(viewProperty.GetValue(_view, null), modelProperty.PropertyType);

						if (valueToAssign != null)
						{
							modelProperty.SetValue(_model, valueToAssign, null);
						}
					}
				}
			}
		}

		private void SetViewPropertiesFromModel()
		{
			foreach (PropertyInfo viewProperty in _view.GetType().GetProperties())
			{
				if (viewProperty.CanWrite)
				{
					PropertyInfo modelProperty = _model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
					{
						object modelValue = modelProperty.GetValue(_model, null);

						if (modelValue != null)
						{
							object valueToAssign = Convert.ChangeType(modelValue, viewProperty.PropertyType);

							if (valueToAssign != null)
							{
								viewProperty.SetValue(_view, valueToAssign, null);
							}
						}
					}
				}
			}
		}

		public void Initialize()
		{
			SetViewPropertiesFromModel();
			WireUpViewEvents();
		}
	}
}
