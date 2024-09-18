using System.Diagnostics;

namespace InterviewTestMid
{
    // This class implements the LoggerInterface and provides methods for logging messages, errors, and writing logs to CSV.
    internal class Logger : LoggerInterface
    {
        // Logs a standard message to the debug output.
        // Throws an exception if the message is null or empty.
        public void WriteLogMessage(string LogMessage)
        {
            if (string.IsNullOrEmpty(LogMessage))
                throw new ArgumentException("Log message not provided", "LogMessage");

            Debug.WriteLine(LogMessage); // Writes the log message to the debug output.
        }

        // Logs an error message to the debug output.
        // Throws an exception if the provided exception is null.
        public void WriteErrorMessage(Exception Ex)
        {
            if (Ex == null)
                throw new ArgumentException("Exception not provided", "Ex");

            Debug.WriteLine($"Error received:  {Ex.Message}"); // Logs the error message.
            Debug.WriteLine($"{Ex.StackTrace}");               // Logs the stack trace of the exception.
        }

        // Logs a message to the console with the current timestamp.
        public void LogMessage(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        // Logs a list of messages to a CSV file by concatenating the messages with commas.
        public void LogMessagesToCSV(List<string> messages)
        {
            var csv = string.Join(",", messages);
            File.WriteAllText("log.csv", csv); // Writes the concatenated messages to a CSV file.
        }
    }
}
