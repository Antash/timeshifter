using System;

namespace CsTutorial
{
	// этот класс наследует класс A и больше не может быть наследован
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

		protected override int AbstractF()
		{
			throw new NotImplementedException();
		}

		// таким образом мы переопределили реализацию интерфейсного метода из класса- родителя
		public new void If1()
		{
		}
	}
}
