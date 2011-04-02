namespace tsCore.Interfaces
{
	interface IManaged
	{
		void Enable();
		void Disable();
		void Manage(bool isEnable);
	}
}
