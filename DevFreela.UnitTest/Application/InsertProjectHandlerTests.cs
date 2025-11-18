using DevFreela.Application.Commands.Project.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.UnitTest.Fakes;
using FluentAssertions;
using Moq;
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

            //var command = new InsertProjectCommand
            //{
            //    Title = "Test",
            //    Description = "Test", 
            //    TotalCost = 1000,
            //    IdClient = 1,
            //    IdFreelancer = 2,
            //};

            var command = FakeDataHelper.CreateFakeInsertProjectCommand();

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(ID);

            await repository.Received(1).Insert(Arg.Any<Project>());
        }

        [Fact]
        public async Task InputDataAreOk_Insert_Sucess_Moq()
        {
            // Arrange
            const int ID = 1;

            //var mock = new Mock<IProjectRepository>();
            //mock.Setup(r => r.Insert(It.IsAny<Project>())).ReturnsAsync(ID);

            var repository = Mock
                .Of<IProjectRepository>(r => r.Insert(It.IsAny<Project>()) == Task.FromResult(ID));

            //var command = new InsertProjectCommand
            //{
            //    Title = "Test",
            //    Description = "Test",
            //    TotalCost = 1000,
            //    IdClient = 1,
            //    IdFreelancer = 2,
            //};

            var command = FakeDataHelper.CreateFakeInsertProjectCommand();

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            //mock.Verify(m => m.Insert(It.IsAny<Project>()), Times.Once);

            Mock.Get(repository).Verify(m => m.Insert(It.IsAny<Project>()), Times.Once);
        }
    }
}
