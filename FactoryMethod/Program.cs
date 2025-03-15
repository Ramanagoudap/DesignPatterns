namespace FactoryMethod
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter Logger Type (File/Database/Console): ");
        string loggerType = Console.ReadLine();

        ILogger logger = LoggerFactory.GetLogger(loggerType);
        logger.Log("Factory Method Pattern Example");
		}
	}

	public interface ILogger
	{
		void Log(string message);
	}

	public class FileLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine($"Logging to File: {message}");
		}
	}

	public class DatabaseLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine($"Logging to Database: {message}");
		}
	}

	public class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine($"Logging to Console: {message}");
		}
	}


	public static class LoggerFactory
	{
		public static ILogger GetLogger(string loggerType)
		{
			return loggerType.ToLower() switch
			{
				"file" => new FileLogger(),
				"database" => new DatabaseLogger(),
				"console" => new ConsoleLogger(),
				_ => throw new ArgumentException("Invalid Logger Type")
			};
		}
	}


}
