namespace Adapter
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Using PayPal directly
			IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
			paypalProcessor.ProcessPayment(100);

			// Using Stripe through an Adapter
			StripePaymentProcessor stripeProcessor = new StripePaymentProcessor();
			IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeProcessor);
			stripeAdapter.ProcessPayment(200);
		}
	}

	public interface IPaymentProcessor
	{
		void ProcessPayment(decimal amount);
	}

	public class PayPalPaymentProcessor : IPaymentProcessor
	{
		public void ProcessPayment(decimal amount)
		{
			Console.WriteLine($"Processing payment of ${amount} via PayPal.");
		}
	}


	public class StripePaymentProcessor
	{
		public void MakePayment(decimal amount)
		{
			Console.WriteLine($"Processing payment of ${amount} via Stripe.");
		}
	}


	public class StripePaymentAdapter : IPaymentProcessor
	{
		private readonly StripePaymentProcessor _stripePaymentProcessor;

		public StripePaymentAdapter(StripePaymentProcessor stripePaymentProcessor)
		{
			_stripePaymentProcessor = stripePaymentProcessor;
		}

		public void ProcessPayment(decimal amount)
		{
			// Call the incompatible method inside the adapter
			_stripePaymentProcessor.MakePayment(amount);
		}
	}

}
