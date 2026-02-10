using Microsoft.Data.SqlClient;
using System.Data;
using Project_Recruitment;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Add services
// ======================

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dapper DB Connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Dependency Injection
builder.Services.AddScoped<IUserrepositery, UserBusiness>();

// ======================
// Build app
// ======================

var app = builder.Build();

// ======================
// Middleware
// ======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
