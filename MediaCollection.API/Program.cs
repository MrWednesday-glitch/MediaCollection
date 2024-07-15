using MediaCollection.Business.Services;
using MediaCollection.Data;
using MediaCollection.Domain.Interfaces;

namespace MediaCollection.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // TODO Learn how to make a service factory
        builder.Services.AddControllers();

        builder.Services.AddScoped<MockDatabase>();
        builder.Services.AddScoped<IGameService, GameService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
    }
}
