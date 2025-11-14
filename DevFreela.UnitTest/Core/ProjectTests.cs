using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTest.Core;

public class ProjectTests
{
    [Fact]
    public void ProjectIsCreated_Start_Success()
    {
        // Arrange
        var project = new Project("Project", "Project Description", 1, 2, 1000);

        // Act
        project.Start();

        // Assert
        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);

        project.Status.Should().Be(ProjectStatusEnum.InProgress);
        project.StartedAt.Should().NotBeNull();

        Assert.True(project.Status == ProjectStatusEnum.InProgress);
        Assert.False(project.StartedAt is null);
    }

    [Fact]
    public void ProjectIsInInvalidState_Start_ThrowsException()
    {
        // Arrange
        var project = new Project("Project", "Project Description", 1, 2, 1000);
        project.Start();

        // Act + Assert
        Action start = project.Start;

        var exception = Assert.Throws<InvalidOperationException>(start);
        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);

        start.Should()
            .Throw<InvalidOperationException>()
            .WithMessage(Project.INVALID_STATE_MESSAGE);
    }

    [Fact]
    public void ProjectUpdated_ShouldReturn_Success()
    {
        // Arrange
        var project = new Project("Project", "Project Description", 1, 2, 1000);

        // Act
        var titleExpected = "Title";
        var descriptionExpected = "Description";
        var totalCostExpected = 1500;
        project.Update(titleExpected, descriptionExpected, totalCostExpected);

        // Assert
        Assert.Equal(project.Title, titleExpected);
        Assert.Equal(project.Description, descriptionExpected);
        Assert.Equal(project.TotalCost, totalCostExpected);
    }

    [Fact]
    public void ProjectIsInPaymentPending_Complete_Success()
    {
        // Arrange
        var project = new Project("Project", "Project Description", 1, 2, 1000);

        // Act
        project.Start();
        project.SetPaymentPending();
        project.Complete();

        // Assert
        Assert.Equal(ProjectStatusEnum.Completed, project.Status);
        Assert.NotNull(project.CompletedAt);

        Assert.True(project.Status == ProjectStatusEnum.Completed);
        Assert.False(project.CompletedAt is null);
    }
}
