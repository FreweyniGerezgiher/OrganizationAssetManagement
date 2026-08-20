using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Infrastructure.Persistence;
using OrganizationAssetManagement.Infrastructure.Repositories;
using OrganizationAssetManagement.Infrastructure.Services;

namespace OrganizationAssetManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IAssetAssignmentRepository,AssetAssignmentRepository>();

        services.AddScoped<IAssetHistoryRepository, AssetHistoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganizationUnitRepository, OrganizationUnitRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}