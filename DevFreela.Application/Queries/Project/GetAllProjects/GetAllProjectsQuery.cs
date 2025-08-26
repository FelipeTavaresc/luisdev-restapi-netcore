using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {
    }
}
