using Microsoft.EntityFrameworkCore;
using Dashboard.Models;
using Dashboard.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Incluindo no appsettings.json as informações de User e Password do banco de dados
var connectionStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DashboardContext"));
connectionStrBuilder.Password = builder.Configuration["DbPassword"];
connectionStrBuilder.UserID = builder.Configuration["DbUser"];
var connection = connectionStrBuilder.ConnectionString;

// Contexto para se comunicar com o banco de dados (ConnectionString está no arquivo appsettings.json)
builder.Services.AddDbContext<DashboardContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DashboardContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
