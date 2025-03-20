namespace Facade
{
	internal class Program
	{
		static void Main(string[] args)
		{
			OrderFacade orderFacade = new OrderFacade();
			// Place an order
			orderFacade.PlaceOrder("P123", "ACC456", 100.50, "customer@example.com");
			Console.ReadLine();
		}
	}

	public class InventoryService
	{
		public bool CheckStock(string productId)
		{
			Console.WriteLine($"Checking stock for product {productId}...");
			return true; // Assume product is available
		}
	}


	public class PaymentService
	{
		public bool MakePayment(string accountNumber, double amount)
		{
			Console.WriteLine($"Processing payment of {amount} from account {accountNumber}...");
			return true; // Assume payment is successful
		}
	}

	public class NotificationService
	{
		public void SendOrderConfirmation(string email)
		{
			Console.WriteLine($"Sending order confirmation email to {email}...");
		}
	}

	public class OrderFacade
	{
		private InventoryService _inventory;
		private PaymentService _payment;
		private NotificationService _notification;

		public OrderFacade()
		{
			_inventory = new InventoryService();
			_payment = new PaymentService();
			_notification = new NotificationService();
		}

		public void PlaceOrder(string productId, string accountNumber, double amount, string email)
		{
			Console.WriteLine("Placing order...");

			if (!_inventory.CheckStock(productId))
			{
				Console.WriteLine("Product is out of stock.");
				return;
			}

			if (!_payment.MakePayment(accountNumber, amount))
			{
				Console.WriteLine("Payment failed.");
				return;
			}

			_notification.SendOrderConfirmation(email);
			Console.WriteLine("Order placed successfully.");
		}
	}

}
