using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	// Concrete Product - Light Theme TextBox
	public class LightTextBox : ITextBox
	{
		public void ShowText()
		{
			Console.WriteLine("Displaying text in Light Theme TextBox");
		}
	}

}
