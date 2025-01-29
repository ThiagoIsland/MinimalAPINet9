using MinimalAPI.Core.Entity;

namespace MinimalAPI.Application.Interface;

public interface IMinimalRepository
{
    Task<IEnumerable<Pessoa?>> GetAllUsersAsync();
    Task<Pessoa?> GetUserByIdAsync(int id);
    Task AddUserAsync(Pessoa pessoa);
    Task<Pessoa?> UpdateUserAsync(Pessoa pessoa);
    Task<bool> DeleteUserAsync(int id);
}