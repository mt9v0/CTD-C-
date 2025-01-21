using Lab3.DB;
using Lab3.Repositories;
using Lab3.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Lab3Context>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Lab3"));
});

builder.Services.AddTransient<IEqService, EqService>();
builder.Services.AddTransient<IEqRep, EqRep>();

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
