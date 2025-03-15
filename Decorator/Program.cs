namespace Decorator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IFileReader fileReader = new FileReader();
			fileReader.ReadFile();

			Console.WriteLine("\nApplying Logging Decorator...\n");

			// File reading with logging
			IFileReader loggedFileReader = new LoggingFileReader(fileReader);
			loggedFileReader.ReadFile();
		}
	}

	public interface IFileReader
	{
		void ReadFile();
	}

	// This is the base implementation that performs the actual file reading.
	public class FileReader : IFileReader
	{
		public void ReadFile()
		{
			Console.WriteLine("Reading file contents...");
		}
	}

	// The decorator class implements the same interface and holds a reference to an IFileReader instance.
	public class FileReaderDecorator : IFileReader
	{
		protected IFileReader _fileReader;

		public FileReaderDecorator(IFileReader fileReader)
		{
			_fileReader = fileReader;
		}

		public virtual void ReadFile()
		{
			_fileReader.ReadFile();
		}
	}

	// This decorator adds logging behavior before and after reading the file.
	public class LoggingFileReader : FileReaderDecorator
	{
		public LoggingFileReader(IFileReader fileReader) : base(fileReader)
		{
		}

		public override void ReadFile()
		{
			Console.WriteLine("Logging: File reading started...");
			base.ReadFile();
			Console.WriteLine("Logging: File reading finished...");
		}
	}

}
