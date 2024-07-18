using MediaCollection.Business.Services;
using MediaCollection.Data;
using MediaCollection.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // TODO Learn how to make a service factory
        builder.Services.AddControllers();

        var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediaCollection;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        builder.Services.AddDbContext<MediaDbContext>((serviceProvider, options) =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);

        builder.Services.AddScoped<MockDatabase>();
        builder.Services.AddScoped<IGameService, GameService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(o => o.AddPolicy("myAllowSpecificOrigins", b =>
        {
            b.AllowAnyOrigin().WithExposedHeaders("X-Pagination")
             .AllowAnyMethod()
             .AllowAnyHeader();
        }));

        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<MediaDbContext>()
            .Database.Migrate();

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
    }
}
