using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid
{
    public interface LoggerInterface
    {
        // Method to log a simple message
        void WriteLogMessage(string logMessage);

        // Method to log an error message along with exception details
        void WriteErrorMessage(Exception ex);

        // Method to log a list of messages to a CSV file
        void LogMessagesToCSV(List<string> messages);

        // Method to log a message with a timestamp
        void LogMessage(string message);

        
    }
}
