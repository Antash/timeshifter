using System;
using System.Reflection;

namespace tsPresenter.Base
{
	public abstract class Presenter
	{
		protected readonly IView View;
		protected readonly IModel Model;

		protected Presenter(IModel model, IView view)
		{
			Model = model;
			View = view;
		}

		protected abstract void WireUpEvents();

		protected abstract void Initialize();

		protected void SetModelPropertiesFromView()
		{
			foreach (PropertyInfo viewProperty in View.GetType().GetProperties())
			{
				if (viewProperty.CanRead)
				{
					PropertyInfo modelProperty = Model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
					{
						object valueToAssign = Convert.ChangeType(viewProperty.GetValue(View, null), modelProperty.PropertyType);

						if (valueToAssign != null)
						{
							modelProperty.SetValue(Model, valueToAssign, null);
						}
					}
				}
			}
		}

		protected void SetViewPropertiesFromModel()
		{
			foreach (PropertyInfo viewProperty in View.GetType().GetProperties())
			{
				if (viewProperty.CanWrite)
				{
					PropertyInfo modelProperty = Model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
					{
						object modelValue = modelProperty.GetValue(Model, null);

						if (modelValue != null)
						{
							object valueToAssign = Convert.ChangeType(modelValue, viewProperty.PropertyType);

							if (valueToAssign != null)
							{
								viewProperty.SetValue(View, valueToAssign, null);
							}
						}
					}
				}
			}
		}
	}
}
