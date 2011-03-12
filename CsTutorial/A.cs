using System;

namespace CsTutorial
{
	// Класс для внутренноего использования (внутри сборки)
	// Он реализует интерфейс
	internal class A : C, I
	{
		// Событие (DelegateA - делегатный тип)
		public event DelegateA AEvent;
		// Функция вызова события
		protected void InvokeAEvent(DelegateAArgs args)
		{
			DelegateA handler = AEvent;
			if (handler != null) handler(this, args);
		}

		private int _privV;
		private string _privS;
		protected int ProtV;
		public int PubV;

		//Статичная переменная 
		// Едина для всех экземпляров класса (для доступа не обязательно создавать экземпляр класса)
		public static int PubStatV;
		// Конструктор без параметров
		public A()
		{
			_privV = 0;
			ProtV = 0;
			_privS = "Hello!";
		}
		// Конструктор с параметрами
		public A(int a)
			: this() // Перед вызовом этого конструктора вызовется конструктор без параметров
		{
			_privV = a;
			ProtV = a;
		}

		// Конструктор с параметрами
		public A(int a, string s)
			: this(a) // Перед вызовом этого конструктора вызовется другой конструктор
		{
			_privV = a;
			ProtV = a;
		}
		// Свойство
		public int PrivV
		{
			// Геттер(возвращает значение)
			get { return _privV; }
			// Сеттер(устанавливает значение)
			set { _privV = value; }
			// Геттера или сеттера может не быть и тогда свойство будет только для чтения или записи
		}

		internal void EInvoke()
		{
			InvokeAEvent(new DelegateAArgs());
		}

		protected int FProtected()
		{
			return _privV / 10;
		}

		protected virtual int AbstractF()
		{
			throw new NotImplementedException();
		}

		protected static void FStatic()
		{
		}

		public int If1()
		{
			throw new NotImplementedException();
		}
		// определение абстрактного метода
		protected override void Am()
		{
			throw new NotImplementedException();
		}
	}
	// Аргументы события
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
	// Объявление делегатного типа (он определяет сигнатуру функции-обработчика события)
	// Сигнатура может быть любой, но принято так:(sender - обыект, вызвавший событие)
	public delegate void DelegateA(object sender, DelegateAArgs args);
}
