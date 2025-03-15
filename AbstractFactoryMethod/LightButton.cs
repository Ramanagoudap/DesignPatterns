using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	// Concrete Product - Light Theme Button
	public class LightButton : IButton
	{
		public void Render()
		{
			Console.WriteLine("Rendering Light Theme Button");
		}
	}

}
