namespace tsPresenter.Base
{
	/// <summary>
	/// Base interface for Views (contains Form functions, properties and events)
	/// </summary>
	public interface IView
	{
		#region from class Form

		bool Visible { get; set; }
		void Show();
		void BringToFront();

		#endregion
	}
}
