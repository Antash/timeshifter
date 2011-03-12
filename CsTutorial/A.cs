namespace CsTutorial
{
	public class A
	{
		public event DelegateA AEvent;

		protected void InvokeAEvent(DelegateAArgs args)
		{
			DelegateA handler = AEvent;
			if (handler != null) handler(this, args);
		}

		private int _privV;
		protected int ProtV;
		public int PubV;
		public static int PubStatV;

		public A()
		{
			_privV = 0;
			ProtV = 0;
		}

		public A(int a)
		{
			_privV = a;
			ProtV = a;
		}

		public int PrivV
		{
			get { return _privV; }
			set { _privV = value; }
		}

		internal void EInvoke()
		{
			InvokeAEvent(new DelegateAArgs());
		}

		protected int FProtected()
		{
			return _privV / 10;
		}

		protected static void FStatic()
		{
		}
	}

	public class DelegateAArgs
	{
		public int E;
		public DelegateAArgs()
		{
		}
		public DelegateAArgs(int e)
		{
			E = e;
		}
	}

	public delegate void DelegateA(object sender, DelegateAArgs args);
}
