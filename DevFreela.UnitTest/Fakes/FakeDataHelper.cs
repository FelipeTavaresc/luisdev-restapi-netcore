using Bogus;
using DevFreela.Application.Commands.Project.InsertProject;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTest.Fakes
{
    public class FakeDataHelper
    {
        public static readonly Faker _faker = new();
        public static Project CreateFakeProjectV1()
        {
            return new Project(
                _faker.Commerce.ProductName(),
                _faker.Lorem.Sentence(),
                _faker.Random.Int(1, 100),
                _faker.Random.Int(1, 100),
                _faker.Random.Decimal(1, 10000)
            );
        }

        private static readonly Faker<Project> _projectFaker = new Faker<Project>()
            .CustomInstantiator(f => new Project(
                f.Commerce.ProductName(),
                _faker.Lorem.Sentence(),
                f.Random.Int(1, 100),
                f.Random.Int(1, 100),
                f.Random.Decimal(1, 10000)
             ));

        public static readonly Faker<InsertProjectCommand> _insertProjectCommand = new Faker<InsertProjectCommand>()
            .RuleFor(c => c.Title, f => f.Commerce.ProductName())
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(c => c.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(c => c.TotalCost, f => f.Random.Decimal(1000, 10000));

        public static Project CreateFakeProject() => _projectFaker.Generate();

        public static List<Project> CreateFakeProjectList => _projectFaker.Generate(5);

        public static InsertProjectCommand CreateFakeInsertProjectCommand()
            => _insertProjectCommand.Generate(); 

    }
}
