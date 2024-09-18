using Xunit;
using Moq;
using InterviewTestMid;

namespace InterviewTestMid.Tests
{
    // Unit tests for the Logger class, focusing on the WriteLogMessage method.
    public class LoggerTests
    {
        // Test case: Verifies that WriteLogMessage is called successfully with a valid message.
        [Fact]
        public void WriteLogMessage_Success()
        {
            // Arrange: Set up a mock logger and a test log message.
            var mockLogger = new Mock<LoggerInterface>();
            string testMessage = "Test log message";

            // Act: Call the WriteLogMessage method on the mock object.
            mockLogger.Object.WriteLogMessage(testMessage);

            // Assert: Verify that the WriteLogMessage method was called exactly once with the test message.
            mockLogger.Verify(logger => logger.WriteLogMessage(testMessage), Times.Once);
        }

        // Test case: Verifies that WriteLogMessage throws an ArgumentException when provided with an empty message.
        [Fact]
        public void WriteLogMessage_ThrowsArgumentException()
        {
            // Arrange: Set up a mock logger and simulate an exception when an empty message is passed.
            var mockLogger = new Mock<LoggerInterface>();
            string emptyMessage = "";

            // Set up the mock to throw an ArgumentException when WriteLogMessage is called with an empty message.
            mockLogger
                .Setup(logger => logger.WriteLogMessage(emptyMessage))
                .Throws(new ArgumentException("Log message not provided", "LogMessage"));

            // Act & Assert: Verify that the method throws the expected ArgumentException when called with an empty message.
            Assert.Throws<ArgumentException>(() => mockLogger.Object.WriteLogMessage(emptyMessage));
        }
    }
}
