using System.Diagnostics;

namespace LagDaemon.AudioProcessing.Api.Tests
{
    public class DataStorageTests
    {
        [Fact]
        public void SystemPaths_returns_correct_path()
        {
            // Arrange
            var filename = "test.json";
            var expected = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}LagDaemon{Path.DirectorySeparatorChar}AudioProcessing{Path.DirectorySeparatorChar}{filename}";

            // Act
            var path = SystemPaths.GetPath(filename);

            Debug.WriteLine(path);

            // Assert
            Assert.Equal(expected, path);
        }
        
    }
}