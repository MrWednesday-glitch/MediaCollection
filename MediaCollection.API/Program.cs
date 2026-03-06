using MediaCollection.Business;
using MediaCollection.Data;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDataServices(builder.Configuration);
        builder.Services.AddBusinessServices();

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

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
