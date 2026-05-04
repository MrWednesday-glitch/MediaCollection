using MediaCollection.Business.BusinessExtensions;
using MediaCollection.Data;
using MediaCollection.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.API;

[ExcludeFromCodeCoverage]
public sealed class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDataServices(builder.Configuration);
        builder.Services.AddBusinessServices(builder.Configuration);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(o => o.AddPolicy("myAllowSpecificOrigins", b =>
        {
            b.AllowAnyOrigin().WithExposedHeaders("X-Pagination")
             .AllowAnyMethod()
             .AllowAnyHeader();
        }));

        WebApplication app = builder.Build();

        using IServiceScope scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<MediaDbContext>()
            .Database.Migrate();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
