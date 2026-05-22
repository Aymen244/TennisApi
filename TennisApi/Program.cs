using TennisApi.Application.Services;
using TennisApi.Application.Services.Interfaces;
using TennisApi.Repositories;
using TennisApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//DI
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddSingleton<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IStatsService, StatsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
