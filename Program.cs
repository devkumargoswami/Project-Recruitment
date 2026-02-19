using Microsoft.Data.SqlClient;
using Project_Recruitment.Business;
using Project_Recruitment.Interface;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Add services
// ======================

// Controllers
builder.Services.AddControllers();
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
builder.Services.AddScoped<IUserEducationRepository, UserEducationBusines>();
builder.Services.AddScoped<IEducationLevelRepository, EducationLevelBusiness>();
builder.Services.AddScoped<IExperience, ExperienceBusiness>();
builder.Services.AddScoped<IDocumentRepository, DocumentBusiness>();
builder.Services.AddScoped<IInterviewScheduleRepository, InterviewScheduleRepository>();
builder.Services.AddScoped<IRegisterRepository, UserRegisterBusiness>();
builder.Services.AddScoped<ISkillRepository, SkillBussiness>();
builder.Services.AddScoped<IResultRepositry, ResultBussiness>();
builder.Services.AddScoped<IListrepositery, ListBusiness>();



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
