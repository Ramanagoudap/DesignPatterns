using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	class DarkThemeFactory : IUIFactory
	{
		public IButton CreateButton()
		{
			return new DarkButton();
		}
		public ITextBox CreateTextBox()
		{
			return new DarkTextBox();
		}
	}
}
