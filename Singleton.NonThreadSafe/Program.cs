namespace Singleton.NonThreadSafe
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Singleton s1 = Singleton.GetInstance();
			Singleton s2 = Singleton.GetInstance();

			if (s1 == s2)
			{
				Console.WriteLine("Singleton works, both variables contain the same instance.");
			}
			else
			{
				Console.WriteLine("Singleton failed, variables contain different instances.");
			}
		}

		public sealed class Singleton
		{
			// The Singleton's constructor should always be private to prevent direct construction calls with the `new` operator.

			private Singleton() { }

			// The Singleton's instance is stored in a static field.

			private static Singleton _instance;

			// This is the static method that controls the access to the singleton instance. On the first run, it creates a singleton object and places it into the static field.
			// On subsequent runs, it returns the client existing object stored in the static field.

			public static Singleton GetInstance()
			{
				if (_instance == null)
				{
					_instance = new Singleton();
				}
				return _instance;
			}

			// Finally, any singleton should define some business logic, which can be executed on its instance.
			public void someBusinessLogic()
			{
				// ...
			}
		}
	}
}
