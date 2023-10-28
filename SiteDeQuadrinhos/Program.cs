using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios;
using SiteDeQuadrinhos.Repositorios.Interfaces;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<SiteDeQuadrinhosDBContex>(
        options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );
builder.Services.AddIdentityCore<UsuarioModel>()
    .AddEntityFrameworkStores<SiteDeQuadrinhosDBContex>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IQuadrinhoRepositorio, QuadrinhoRepositorio>();

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
