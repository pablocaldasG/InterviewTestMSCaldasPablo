using Xunit;
using Moq;
using InterviewTestMid;

namespace InterviewTestMid.Tests
{
    public class LoggerTests
    {
        // Mock for a successful log message
        [Fact]
        public void WriteLogMessage_Success()
        {
            // Arrange
            var mockLogger = new Mock<LoggerInterface>();
            string testMessage = "Test log message";

            // Act
            mockLogger.Object.WriteLogMessage(testMessage);

            // Assert
            mockLogger.Verify(logger => logger.WriteLogMessage(testMessage), Times.Once);
        }

        // Mock for an exception being thrown by the method
        [Fact]
        public void WriteLogMessage_ThrowsArgumentException()
        {
            // Arrange
            var mockLogger = new Mock<LoggerInterface>();
            string emptyMessage = "";

            mockLogger
                .Setup(logger => logger.WriteLogMessage(emptyMessage))
                .Throws(new ArgumentException("Log message not provided", "LogMessage"));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mockLogger.Object.WriteLogMessage(emptyMessage));
        }
    }
}
