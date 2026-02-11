using Microsoft.Data.SqlClient;
using Project_Recruitment.Business;
using Project_Recruitment.Interface;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register IDbConnection for Dapper
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register UserBusiness as implementation of IUserrepositery
builder.Services.AddScoped<IUserrepositery, UserBusiness>();

builder.Services.AddControllers();

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
