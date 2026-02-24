using Microsoft.Data.SqlClient;
using Project_Recruitment.Business;
using Project_Recruitment.Interface;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// =========================
// ADD SERVICES
// =========================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =========================
// DATABASE CONNECTION (Dapper)
// =========================
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =========================
// DEPENDENCY INJECTION
// =========================
builder.Services.AddScoped<IUserrepositery, UserBusiness>();
builder.Services.AddScoped<IRegisterRepository, UserRegisterBusiness>();

builder.Services.AddScoped<IUserEducationRepository, UserEducationBusiness>();
builder.Services.AddScoped<IEducationLevelRepository, EducationLevelBusiness>();
builder.Services.AddScoped<IExperience, ExperienceBusiness>();
builder.Services.AddScoped<IDocumentRepository, DocumentBusiness>();
builder.Services.AddScoped<IInterviewScheduleRepository, InterviewScheduleBusiness>();
builder.Services.AddScoped<ISkillRepository, SkillBussiness>();
builder.Services.AddScoped<IResultRepositry, ResultBussiness>();
builder.Services.AddScoped<IListrepositery, ListBusiness>();

// =========================
// BUILD APP
// =========================
var app = builder.Build();

// =========================
// MIDDLEWARE PIPELINE
// =========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔐 Future use (JWT)
// app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();