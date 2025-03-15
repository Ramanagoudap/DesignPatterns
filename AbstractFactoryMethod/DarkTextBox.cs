using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	// Concrete Product - Dark Theme TextBox
	public class DarkTextBox : ITextBox
	{
		public void ShowText()
		{
			Console.WriteLine("Displaying text in Dark Theme TextBox");
		}
	}

}
