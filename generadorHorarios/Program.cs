using GeneradorHorarios.Application.Interfaces;
using GeneradorHorarios.Application.Services;
using GeneradorHorarios.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Inyecci�n de dependencias:

builder.Services.AddSingleton<IGeneradorHorarioService, GeneradorHorarioService>();
builder.Services.AddSingleton<RepositorioEnMemoria>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
