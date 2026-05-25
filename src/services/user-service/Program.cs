using User.Services;
using User.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using User.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());

//pega as configurações do appsettings.[development ou production].json
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();           

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                allowedOrigins!
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
           
var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI(); // Abre a UI na rota /swagger/index.html
// }

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
