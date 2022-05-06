using System.Reflection;
using MediatR;
using Profissionais.App.Ports;
using Profissionais.App.QueryHandlers;
using Profissional.Infrastructure.Adapters.Queries;
using Profissional.Infrastructure.Adapters.Repositories;
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
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<ITipoProfissionalRepository, TipoProfissionalRepository>();
builder.Services.AddScoped<IBuscarTiposProfissionalQueryService, BuscarTiposProfissionalQueryService>();
builder.Services.AddMediatR(typeof(BuscarProfissionalPorIdQueryHandler).GetTypeInfo().Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();