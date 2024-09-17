using System.Diagnostics;

namespace InterviewTestMid
{
    internal class Logger : LoggerInterface
    {

        public void WriteLogMessage(string LogMessage)
        {
            if (string.IsNullOrEmpty(LogMessage))
                throw new ArgumentException("Log message not provided", "LogMessage");

            Debug.WriteLine(LogMessage);
        }

        public void WriteErrorMessage(Exception Ex)
        {
            if (Ex == null)
                throw new ArgumentException("Exception not provided", "Ex");

            Debug.WriteLine($"Error recieved: {Ex.Message}");
            Debug.WriteLine($"{Ex.StackTrace}");
        }
        public void LogMessage(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        public void LogMessagesToCSV(List<string> messages)
        {
            var csv = string.Join(",", messages);
            File.WriteAllText("log.csv", csv); // Example writing to a CSV file
        }
    }
}
