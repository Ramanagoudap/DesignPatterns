using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
    class Application
    {
		private readonly IButton _button;
		private readonly ITextBox _textBox;

		public Application(IUIFactory factory)
		{
			_button = factory.CreateButton();
			_textBox = factory.CreateTextBox();
		}

		public void Run()
		{
			_button.Render();
			_textBox.ShowText();
		}
	}
}
