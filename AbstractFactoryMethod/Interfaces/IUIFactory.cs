namespace AbstractFactoryMethod.Interfaces
{
    public interface IUIFactory
    {
		IButton CreateButton();
		ITextBox CreateTextBox();
	}
}
