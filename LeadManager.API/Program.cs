using LeadManager.Application.Interfaces;
using LeadManager.Application.ApplicationService;
using LeadManager.Domain.Interfaces;
using LeadManager.Infrastructure.Databases;
using LeadManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using LeadManager.Infrastructure.EmailService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LeadManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") 
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
