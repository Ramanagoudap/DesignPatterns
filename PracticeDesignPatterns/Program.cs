namespace PracticeDesignPatterns
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			ILogger logger = LoggerFactory.GetLogger("file");
			logger.Log("This is a log message.");

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
			Console.WriteLine(message);
		}
	}

	public class DatabaseLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}

	public class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}

	public static class LoggerFactory
	{
		public static ILogger GetLogger(string LogType)
		{
			if (LogType == "file") { 
				return new FileLogger();
			}
			if (LogType == "db")
			{
				return new FileLogger();
			}
			if (LogType == "console")
			{
				return new FileLogger();
			}
			else
			{
				throw new ArgumentException("Invalid Logger Type");
			}
		}
	}
}
