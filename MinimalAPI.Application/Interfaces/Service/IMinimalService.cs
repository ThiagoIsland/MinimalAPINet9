using MinimalAPI.Core.Entity;

namespace MinimalAPI.Application.Interface;

public interface IMinimalService
{
    Task<IEnumerable<Pessoa?>> GetAllUsersAsync();
    Task<Pessoa?> GetUserByIdAsync(int id);
    Task AddUserAsync(int idPessoa, string? name, string? email);
    Task<Pessoa?> UpdateUserAsync(int id, int idPessoa, string? name, string? email);
    Task<bool> DeleteUserAsync(int id);
}