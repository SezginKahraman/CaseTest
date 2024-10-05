using Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Countries;
using Application.Services.Draws;
using Application.Services.Groups;
using Application.Services.Teams;
using Core.Application.Pipelines.Validation;
using Application.Services.GroupTeams;
using Application.Services.Pickers;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<ICountriesService, CountriesManager>();
        services.AddScoped<IDrawsService, DrawsManager>();
        services.AddScoped<IGroupsService, GroupsManager>();
        services.AddScoped<ITeamsService, TeamsManager>();
        services.AddScoped<IGroupTeamsService, GroupTeamsManager>();
        services.AddScoped<IPickersService, PickersManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
