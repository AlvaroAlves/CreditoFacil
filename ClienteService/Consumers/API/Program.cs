using AnaliseDeCredito.AnaliseNovaProposta;
using Application;
using Application.AnaliseDeCredito;
using Application.Contratos.Ports;
using Application.Financiamentos.Ports;
using Application.Parcelas.Ports;
using Application.Ports;
using Data;
using Data.Clientes;
using Data.Financiamentos;
using Data.Parcelas;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ContratoManager));

#region IoC
builder.Services.AddScoped<IClienteManager, ClienteManager>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFinanciamentoManager, FinanciamentoManager>();
builder.Services.AddScoped<IFinanciamentoRepository, FinanciamentoRepository>();
builder.Services.AddScoped<IParcelaManager, ParcelaManager>();
builder.Services.AddScoped<IParcelaRepository, ParcelaRepository>();
builder.Services.AddScoped<IContratoManager, ContratoManager>();
builder.Services.AddScoped<IAnaliseDeCredito, NovaPropostaAdapter> ();
#endregion


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<Context>(
    options => options.UseSqlServer(connectionString)
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
