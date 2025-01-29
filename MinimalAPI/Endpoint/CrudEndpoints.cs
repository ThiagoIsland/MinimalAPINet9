using MinimalAPI.Application.Interface;
using MinimalAPI.Core.Entity;
namespace MinimalAPI.Endpoint;

public static class CrudEndpoints
{
    public static void MapCrudEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/pessoas", async (IMinimalService minimalService) =>
            {
                var pessoas = await minimalService.GetAllUsersAsync();
                return Results.Ok(pessoas);
            })
            .WithName("GetTodasPessoas");

        app.MapGet("/api/pessoas/{id:int}", async (int id, IMinimalService minimalService) =>
            {
                var pessoa = await minimalService.GetUserByIdAsync(id);
                return pessoa != null
                    ? Results.Ok(pessoa)
                    : Results.NotFound("Sem usuário com esse ID");
            })
            .WithName("GetPessoaById");

        app.MapPost("/api/pessoas", async (Pessoa pessoa, IMinimalService minimalService) =>
            {
                await minimalService.AddUserAsync(pessoa.IdPessoa, pessoa.Name, pessoa.Email);
                return Results.Content("Usuário Adicionado com Sucesso");
            })
            .WithName("AdicionarPessoa");

        app.MapPut("/api/pessoas/{id:int}", async (int id, Pessoa pessoa, IMinimalService minimalService) =>
            {
                var updatedUser = await minimalService.UpdateUserAsync(id, pessoa.IdPessoa, pessoa.Name, pessoa.Email);
                return updatedUser != null
                    ? Results.Ok(updatedUser)
                    : Results.NotFound($"The ID: {id} was not found.");
            })
            .WithName("UpdatePessoa");

        app.MapDelete("/api/pessoas/{id:int}", async (int id, IMinimalService minimalService) =>
            {
                var isDeleted = await minimalService.DeleteUserAsync(id);
                return isDeleted
                    ? Results.NoContent()
                    : Results.NotFound($"User with ID {id} not found.");
            })
            .WithName("DeletarPessoa");
    }
}