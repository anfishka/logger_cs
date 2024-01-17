
 public class Logger
    {
    protected readonly string logFilePath;
    protected bool isRunning;

    public Logger(string filePath)
    {
        logFilePath = filePath;
        isRunning = true;
    }

    public virtual void Start(string loggerName)
    {
        Console.WriteLine($"{loggerName} started. Logging to {logFilePath}");
    while(isRunning)
        {
            string timestamp = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
            string logMessage = $"{timestamp} - {loggerName} is on!\n ";

            File.AppendAllText(logFilePath, logMessage );

            Thread.Sleep(1000);
        }
    }

    public void Stop()
    {
        isRunning = false;
        Console.WriteLine("\nLogger stoped.\n");
    }
    }

namespace LoggerNamespace1
{
    public class Logger1: Logger
    {
       static private readonly string filePath = "..\\..\\..\\default_log.txt";
        public Logger1() : base(filePath) { }    
        public override void Start(string loggerName)
        {
            base.Start($"Logger1 - {loggerName}");
        }
    }
}

namespace LoggerNamespace2
{
    public class Logger2 : Logger
    {
        public Logger2(string customFilePath) : base(customFilePath) { }
        public override void Start(string loggerName)
            {
            base.Start($"Logger2 - {loggerName}");
        }
    }
}