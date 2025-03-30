using ExpenseSolution.Repositories;
using ExpenseSolution.Repositories.Expenses;
using ExpenseSolution.Repositories.Users;
using ExpenseSolution.Services.Expenses;
using ExpenseSolution.Services.Users;
using ExpenseSolution.Utils;
using ExpenseSolution.Utils.Interfaces;
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
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// EXPENSES
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
// USER
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// UTILS
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
