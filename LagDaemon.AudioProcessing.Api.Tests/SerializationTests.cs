using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using LagDaemon.AudioProcessing.Api.Services.Serialization;

namespace LagDaemon.AudioProcessing.Api.Tests
{
    public class SerializationTests
    {
        IWindsorContainer _container;


        public SerializationTests()
        {
            _container = new WindsorContainer();
        }


        [Fact] 
        public void TestSerialization() 
        {
            // Arrange
            var expectedJson = "{\"Name\":\"Test\",\"Description\":\"Description\",\"Version\":\"1.0.0\",\"Author\":\"Smith\",\"Copyright\":\"Some Copyright\",\"Path\":null,\"Files\":[],\"SubProjects\":[{\"Name\":\"Test 2\",\"Description\":\"Description\",\"Version\":\"1.0.0\",\"Author\":\"Smith\",\"Copyright\":\"Some Copyright\",\"Path\":null,\"Files\":[],\"SubProjects\":[],\"ProjectSettings\":{}}],\"ProjectSettings\":{\"name\":\"Test\"}}";


            _container.Register(Component.For<ISerializer, JsonSerializerImpl>());  
            _container.Register(Component.For<ISerializationService, SerializationService>());
            var serializer = _container.Resolve<ISerializationService>();
            var project = new Project()
            {
                 Name = "Test",
                 Author = "Smith",
                 Copyright = "Some Copyright",
                 Description = "Description",
                 Version = "1.0.0",
            };

            project.SubProjects.Add(new Project() {
                Name = "Test 2",
                Author = "Smith",
                Copyright = "Some Copyright",
                Description = "Description",
                Version = "1.0.0",
            });

            project.SetProjectSetting("name", "Test");

            // Act
            var json = serializer.Serialize(project);


            // Assert
            Assert.Equal(expectedJson, json);
            Console.WriteLine(json);
        }
    }
}
