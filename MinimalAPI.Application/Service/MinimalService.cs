using MinimalAPI.Core.Entity;
using MinimalAPI.Application.Interface;

namespace MinimalAPI.Application.Service;

public class MinimalService : IMinimalService
{
    private readonly IMinimalRepository _genericRepository;

    public MinimalService(IMinimalRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<Pessoa?>> GetAllUsersAsync()
    {
        return await _genericRepository.GetAllUsersAsync();
    }

    public async Task<Pessoa?> GetUserByIdAsync(int id)
    {
        return await _genericRepository.GetUserByIdAsync(id);
    }

    public async Task AddUserAsync(int idPessoa, string? name, string? email)
    {
        var pessoa = new Pessoa
        {
            IdPessoa = idPessoa,
            Name = name,
            Email = email,
            CreatedAt = DateTime.UtcNow
        };

        await _genericRepository.AddUserAsync(pessoa);
    }

    public async Task<Pessoa?> UpdateUserAsync(int id, int idPessoa, string? name, string? email)
    {
        var pessoa = new Pessoa
        {
            IdPessoa = idPessoa,
            Name = name,
            Email = email
        };
            
        return await _genericRepository.UpdateUserAsync(pessoa);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _genericRepository.DeleteUserAsync(id);
    }
}