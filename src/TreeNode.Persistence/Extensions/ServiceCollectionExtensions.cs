using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("postgres");

        services.AddDbContext<TreeNodeDbContext>(context => context
            .UseNpgsql(connectionString)
            .UseLazyLoadingProxies());

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
}