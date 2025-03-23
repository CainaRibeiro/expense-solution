using ExpenseSolution.Data;
using ExpenseSolution.Interfaces;
using ExpenseSolution.Users;
using ExpenseSolution.Users.Interfaces;
using ExpenseSolution.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// BANCO
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BancoTeste"));

// DEPENDENCY INJECTION
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHash, Hash>();
builder.Services.AddScoped<IJwt, Jwt>();


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
