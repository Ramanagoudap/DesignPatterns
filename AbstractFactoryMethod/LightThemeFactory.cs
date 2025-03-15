using AbstractFactoryMethod.Interfaces;

namespace AbstractFactoryMethod
{
	class LightThemeFactory : IUIFactory
	{
		public IButton CreateButton()
		{
			return new LightButton();
		}

		public ITextBox CreateTextBox()
		{
			return new LightTextBox();
		}
	}
}
