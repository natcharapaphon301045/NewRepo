using Microsoft.EntityFrameworkCore;
using Week5.Infrastructure_Layer.Persistence;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Repositories;
using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Week5.Application_Layer.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add Database Context
builder.Services.AddDbContext<Week5DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IBehaviorScoreRepository, BehaviorScoreRepository>();
builder.Services.AddScoped<IStudentClassRepository, StudentClassRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();

// Register Services
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddHttpClient<StudentDTO>();

// Add Controllers
builder.Services.AddControllers();

// Add Razor Pages services
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

// Enable CORS (Allow Any Origin for Testing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll"); // Enable CORS
app.UseAuthorization();

// Map Endpoints
app.MapControllers();
app.MapRazorPages();

app.Run();
