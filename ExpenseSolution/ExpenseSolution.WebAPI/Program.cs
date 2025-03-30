using ExpenseSolution.Repositories;
using ExpenseSolution.Repositories.Expenses;
using ExpenseSolution.Repositories.Users;
using ExpenseSolution.Services.Expenses;
using ExpenseSolution.Services.Users;
using ExpenseSolution.Utils;
using ExpenseSolution.Utils.Interfaces;
using ExpenseSolution.WebAPI.Controllers.middlwares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Expense Solution API", Version = "v1" });

    // Configuração do esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/swagger"))
    {
        await next();
        return;
    }
    await next();
});

app.UseMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
