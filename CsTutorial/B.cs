namespace CsTutorial
{
	sealed class B : A
	{
		private double _b;
		public B()
		{
		}

		public B(int a, double b)
			: base(a)
		{
			_b = b;
		}
	}
}
