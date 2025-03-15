using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Select Theme: 1. Light  2. Dark");
			string choice = Console.ReadLine();

			IUIFactory factory = choice == "1" ? new LightThemeFactory() : new DarkThemeFactory();

			Application app = new Application(factory);
			app.Run();
		}
	}
}
