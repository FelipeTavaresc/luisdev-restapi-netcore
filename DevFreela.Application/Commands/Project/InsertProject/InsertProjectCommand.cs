using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Project.InsertProject
{
    public class InsertProjectCommand : IRequest<ResultViewModel<int>>
    {
        public InsertProjectCommand()
        {
            
        }

        public InsertProjectCommand(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }

        public Core.Entities.Project ToEntity() => new(Title, Description, IdClient, IdFreelancer, TotalCost);
    }
}
