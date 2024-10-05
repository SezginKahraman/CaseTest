using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
                                                    options.UseSqlServer(
                                                        configuration.GetConnectionString("AdessoCaseDb")));


        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDrawRepository, DrawRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        return services;
    }
}
