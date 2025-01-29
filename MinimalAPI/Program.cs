using MinimalAPI;
using MinimalAPI.Application.Interface;
using MinimalAPI.Application.Service;
using MinimalAPI.Endpoint;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container
builder.Services.AddScoped<IMinimalService, MinimalService>();
builder.Services.AddOpenApi();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapCrudEndpoints();

app.Run();