using System;

namespace Delegate_Logger
{
    // Delegate declaration
    public delegate void LoggingOperation(string message);

    // Logger class with Info, Warning, and Error methods
    public class Logger
    {
        public void Info(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("[WARNING] " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("[ERROR] " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            // Using delegate to call the Info method
            LoggingOperation logOp = new LoggingOperation(logger.Info);
            logOp("This is an info message.");

            // Using delegate to call the Warning method
            logOp = new LoggingOperation(logger.Warning);
            logOp("This is a warning message.");

            // Using delegate to call the Error method
            logOp = new LoggingOperation(logger.Error);
            logOp("This is an error message.");

            // Using delegate to call an anonymous method for alert
            logOp = delegate (string message)
            {
                Console.WriteLine("[ALERT] " + message);
            };
            logOp("This is an alert message.");
        }
    }
}
