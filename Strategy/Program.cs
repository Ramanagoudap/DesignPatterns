namespace Strategy
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var paymentContext = new PaymentContext(new CreditCardPayment());
			paymentContext.ProcessPayment(1000);

			paymentContext.SetStrategy(new PayPalPayment());
			paymentContext.ProcessPayment(500);

			paymentContext.SetStrategy(new BitcoinPayment());
			paymentContext.ProcessPayment(750);
		}
	}

	public interface IPaymentStrategy
	{
		void Pay(decimal amount);
	}

	public class CreditCardPayment : IPaymentStrategy
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Paid {amount} using Credit Card.");
		}
	}

	public class PayPalPayment : IPaymentStrategy
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Paid {amount} using PayPal.");
		}
	}

	public class BitcoinPayment : IPaymentStrategy
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Paid {amount} using Bitcoin.");
		}
	}

	public class PaymentContext
	{
		private IPaymentStrategy _paymentStrategy;

		public PaymentContext(IPaymentStrategy paymentStrategy)
		{
			_paymentStrategy = paymentStrategy;
		}

		public void SetStrategy(IPaymentStrategy strategy)
		{
			_paymentStrategy = strategy;
		}

		public void ProcessPayment(decimal amount)
		{
			_paymentStrategy.Pay(amount);
		}
	}

}
