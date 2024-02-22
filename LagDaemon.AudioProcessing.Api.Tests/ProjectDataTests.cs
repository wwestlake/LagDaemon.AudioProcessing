using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Tests
{
    public class ProjectDataTests
    {

        [Fact]
        public void Project_stores_and_returns_settings()
        {
            // Arrange

            var project = new Project();
            var value = 10;

            // Act
            project.SetProjectSetting<int>("MaxSomething", value);
            var result = project.GetProjectSetting<int>("MaxSomething");


            // Assert
            Assert.Equal(value, result);

        }
    }
}
