using System;
using System.Reflection;

namespace tsPresenter.Base
{
	/// <summary>
	/// Base class for presenters, must be inherited
	/// </summary>
	public abstract class Presenter
	{
		/// <summary>
		/// Contains View
		/// </summary>
		protected readonly IView View;
		/// <summary>
		/// Contains Model
		/// </summary>
		protected readonly IModel Model;

		/// <summary>
		/// Creates new instance of Presenter
		/// </summary>
		/// <param name="model">Related model</param>
		/// <param name="view">Related view</param>
		protected Presenter(IModel model, IView view)
		{
			Model = model;
			View = view;
		}

		/// <summary>
		/// Put in this metod initialisation of Model & Veiw events
		/// </summary>
		protected abstract void WireUpEvents();

		/// <summary>
		/// Put any initializations here
		/// </summary>
		protected abstract void Initialize();

		/// <summary>
		/// This function sets Model properties from suitable View properties via reflection
		/// </summary>
		protected void SetModelPropertiesFromView()
		{
			foreach (PropertyInfo viewProperty in View.GetType().GetProperties())
			{
				if (viewProperty.CanRead)
				{
					PropertyInfo modelProperty = Model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType == viewProperty.PropertyType)
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

		/// <summary>
		/// This function sets View properties from suitable Model properties via reflection 
		/// </summary>
		protected void SetViewPropertiesFromModel()
		{
			foreach (PropertyInfo viewProperty in View.GetType().GetProperties())
			{
				if (viewProperty.CanWrite)
				{
					PropertyInfo modelProperty = Model.GetType().GetProperty(viewProperty.Name);

					if (modelProperty != null && modelProperty.PropertyType == viewProperty.PropertyType)
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
