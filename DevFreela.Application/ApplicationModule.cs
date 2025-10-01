using DevFreela.Application.Commands.Project.InsertComment;
using DevFreela.Application.Commands.Project.InsertProject;
using DevFreela.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidation();
        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

        services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();

        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
              .AddFluentValidationAutoValidation()
              .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();

        return services;
    }

}
