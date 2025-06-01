using LeadManagement.Application.Handlers;
using LeadManagement.Domain.Repositories;
using LeadManagement.Infrastructure.Repositories;
using LeadManagement.Infrastructure.Repositories.Contexts;
using LeadManagement.Infrastructure.Services;
using LeadManagement.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<LeadDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ILeadRepository, LeadRepository>();
        builder.Services.AddScoped<IEventStoreService, EventStoreService>();
        builder.Services.AddScoped<IEmailService, EmailService>();

        builder.Services.AddMediatR(typeof(CreateLeadHandler).Assembly);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<LeadDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error ocurred while migrating the database.");
            }
        }

        app.UseRouting();
        app.UseCors("policy");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}