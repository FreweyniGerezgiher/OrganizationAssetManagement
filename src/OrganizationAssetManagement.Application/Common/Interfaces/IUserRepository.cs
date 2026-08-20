using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);
}