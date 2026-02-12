using Microsoft.Data.SqlClient;
using Project_Recruitment.Business;
using Project_Recruitment.Interface;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IUserrepositery, UserBusiness>();
builder.Services.AddScoped<IUserEducationRepository, UserEducationBusines>();
builder.Services.AddScoped<IEducationLevelRepository, EducationLevelBusiness>();
builder.Services.AddScoped<IExperience, ExperienceBusiness>();
builder.Services.AddControllers();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
