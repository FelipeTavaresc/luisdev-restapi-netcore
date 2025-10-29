using DevFreela.Application.Commands.Project.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTest.Application
{
    public class InsertProjectHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Sucess_NSubstitute()
        {
            // Arrange
            const int ID = 1;
            var repository = Substitute.For<IProjectRepository>();
            repository.Insert(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Test",
                Description = "Test", 
                TotalCost = 1000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);
            await repository.Received(1).Insert(Arg.Any<Project>());
        }
    }
}
