using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	// Concrete Product - Dark Theme Button
	public class DarkButton : IButton
	{
		public void Render()
		{
			Console.WriteLine("Rendering Dark Theme Button");
		}
	}

}
