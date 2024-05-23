using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyTe.WebApi.Models.Contexts;
using MyTe.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<MyTeContext>(options =>
    options.UseSqlServer(config.GetConnectionString("MyTeConnection")));

//Habilitando o serviço WBSService para injeção de dependência
builder.Services.AddScoped<WBSsService>();
builder.Services.AddScoped<HorasService>();
builder.Services.AddScoped<FuncionariosService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var context = provider.GetRequiredService<MyTeContext>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
