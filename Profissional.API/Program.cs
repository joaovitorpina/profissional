using System.Reflection;
using MediatR;
using Profissionais.App.Ports;
using Profissionais.App.QueryHandlers;
using Profissional.Infrastructure.Adapters.Queries;
using Profissional.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProfissionalContext>();
builder.Services.AddScoped<IBuscarProfissionaisQueryService, BuscarProfissionaisQueryService>();
builder.Services
    .AddScoped<IBuscarProfissionalPorUrlAmigavelQueryService, BuscarProfissionalPorUrlAmigavelQueryService>();
builder.Services.AddScoped<IBuscarProfissionalPorIdQueryService, BuscarProfissionalPorIdQueryService>();
builder.Services.AddMediatR(typeof(BuscarProfissionalPorIdQueryHandler).GetTypeInfo().Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();