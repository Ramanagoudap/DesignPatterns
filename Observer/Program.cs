namespace Observer
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stock ntpcStock = new Stock("NTPC", 300);

			// Create investors (observers)
			Investor investor1 = new Investor("Ram");
			Investor investor2 = new Investor("Riyu");

			// Attach investors to the stock
			ntpcStock.Attach(investor1);
			ntpcStock.Attach(investor2);

			// Change stock price (this triggers notifications)
			ntpcStock.Price = 320;
			ntpcStock.Price = 340;

			// Detach an investor and change price again
			ntpcStock.Detach(investor1);
			ntpcStock.Price = 400;
		}
	}

	// Each observer (subscriber) must implement this interface.
	public interface IInvestor
	{
		void Update(string stockSymbol, double price);
	}

	//The subject maintains a list of observers and notifies them when its state (stock price) changes.


	public class Stock
	{
		private readonly List<IInvestor> _investors = new();
		private string _symbol;
		private double _price;

		public Stock(string symbol, double price)
		{
			_symbol = symbol;
			_price = price;
		}

		public void Attach(IInvestor investor)
		{
			_investors.Add(investor);
		}

		public void Detach(IInvestor investor)
		{
			_investors.Remove(investor);
		}

		public void Notify()
		{
			foreach (var investor in _investors)
			{
				investor.Update(_symbol, _price);
			}
		}

		public double Price
		{
			get => _price;
			set
			{
				if (_price != value)
				{
					_price = value;
					Notify();  // Notify all observers when price changes
				}
			}
		}
	}

	// Create Concrete Observers (Investors)

	public class Investor : IInvestor
	{
		private string _name;

		public Investor(string name)
		{
			_name = name;
		}

		public void Update(string stockSymbol, double price)
		{
			Console.WriteLine($"Investor {_name} notified: {stockSymbol} new price is {price:C}");
		}
	}


}
