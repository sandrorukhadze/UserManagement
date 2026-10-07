using Application.Interfaces;
using Application.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "DefaultConnection არ არის მითითებული.");

builder.Services.AddScoped<IUserRepository>(_ =>
    new UserRepository(connectionString));

builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

// HTTP-ზე ადგილობრივი ტესტისთვის დატოვე დაკომენტარებული.
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();