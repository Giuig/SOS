using Microsoft.EntityFrameworkCore;
using SOS.Infrastructure.Database;
using AutoMapper;
using SOS.Mapper;
using SOS.Infrastructure.Mapper;
using SOS.Infrastructure.Interfaces;
using SOS.Infrastructure.DAO;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITeamMemberDAO, TeamMemberDAO>();
builder.Services.AddScoped<ITeamDAO, TeamDAO>();
builder.Services.AddScoped<IMissionDAO, MissionDAO>();


   // builder.Services.AddDbContext<SOSContext>(builder =>
   // builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<SOSContext>(builder =>
    builder.UseNpgsql(configuration.GetConnectionString("TestConnection")));

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddAutoMapper(cfg => cfg.AddProfiles(new List<Profile>()
            {
                new UIProfile(),
                new InfrastructureProfile()
            }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }