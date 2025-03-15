namespace Singleton.Lazy
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Logger.Instance.Log("Application Started");

			Console.WriteLine("Hello, World!");
		}

		public class Logger
		{
			// Lazy<T> ensures thread-safe lazy initialization
			private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

			private Logger() { }

			// Public property to access the singleton instance
			public static Logger Instance => _instance.Value;

			public void Log(string message)
			{
				Console.WriteLine($"Log: {message}");
			}
		}
	}
}
