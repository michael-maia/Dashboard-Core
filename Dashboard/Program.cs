using Microsoft.EntityFrameworkCore;
using Dashboard.Data;
using System.Data.SqlClient;
using Dashboard.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Adiciona as classes da camada de Serviços que serão usados na API (https://stackoverflow.com/questions/62210000/problem-registering-services-for-di-in-net-core-3)
builder.Services.AddApplicationServices();

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
