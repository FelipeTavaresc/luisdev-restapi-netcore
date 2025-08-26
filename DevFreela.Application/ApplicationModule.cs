using DevFreela.Application.Commands.Project.InsertProject;
using DevFreela.Application.Services.Project;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddService();
        services.AddHandlers();
        return services;
    }
        

    private static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

        return services;
    }

}
